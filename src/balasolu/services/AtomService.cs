using balasolu.contexts;
using balasolu.models.abstractions;
using balasolu.models.entries;
using balasolu.models.enums;
using balasolu.models.feeds;
using balasolu.services.interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;
using System.Xml;
using Tweetinvi;
using Tweetinvi.Models.V2;
using Tweetinvi.Parameters.V2;

namespace balasolu.services
{
    public class AtomService : IAtomService
    {
        readonly IDbContextFactory<DefaultDbContext> _defaultDbContextFactory;
        readonly TwitterClient _twitterClient;

        public AtomService(
            IDbContextFactory<DefaultDbContext> defaultDbContextFactory,
            TwitterClient twitterClient)
        {
            _defaultDbContextFactory = defaultDbContextFactory;
            _twitterClient = twitterClient;
        }

        public async Task UpdateDefaultFeedsAsync()
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var feeds = context.Feeds!.Include(x => x.Entries);
            if (await feeds.AnyAsync(x => x.FeedType == FeedType.Default))
            {
                foreach (var feed in feeds)
                {
                    if (DateTimeOffset.UtcNow > feed.Fetched.AddMinutes(30))
                    {
                        if (feed.FeedType == FeedType.Default)
                            await UpdateDefaultFeed(((DefaultFeed)feed));
                    }
                }
                await context.SaveChangesAsync();
            }
            else
                await SeedFeedsAsync(context);
        }

        public async Task UpdateTwitterFeedsAsync()
        {
            try
            {
                using var context = await _defaultDbContextFactory.CreateDbContextAsync();
                if (context.Feeds != null)
                {
                    var feeds = await context.Feeds.Where(x => x.FeedType == FeedType.Twitter).ToListAsync();
                    feeds.Sort((x, y) => DateTimeOffset.Compare(x.Updated, y.Updated));
                    var ids = feeds.Take(100).Select(x => x.Id).ToArray();
                    if (ids != null && ids.Any())
                    {
                        var usersParameters = new GetUsersByIdV2Parameters(ids)
                        {
                            Expansions = UserResponseFields.Expansions.ALL,
                            TweetFields = UserResponseFields.Tweet.ALL,
                            UserFields = UserResponseFields.User.ALL
                        };
                        var usersResponse = await _twitterClient.UsersV2.GetUsersByIdAsync(usersParameters);
                        if (usersResponse != null)
                        {
                            foreach (var user in usersResponse.Users)
                            {
                                var feed = await context.Feeds.FirstOrDefaultAsync(x => x.Id == user.Id);
                                if (feed != null)
                                {
                                    var twitterFeed = (TwitterFeed)feed;
                                    twitterFeed.Title = user.Name;
                                    twitterFeed.Link = user.Url;
                                    twitterFeed.Username = user.Username;
                                    twitterFeed.Updated = DateTimeOffset.UtcNow;
                                    twitterFeed.Fetched = DateTimeOffset.UtcNow;
                                    var result = await _twitterClient.Execute.RequestAsync<TweetsV2Response>(request =>
                                    {
                                        request.Url = $"https://api.twitter.com/2/users/{user.Id}/tweets?max_results=10&tweet.fields=id,created_at,text";
                                        request.HttpMethod = Tweetinvi.Models.HttpMethod.GET;
                                    });
                                    if (result.Response.IsSuccessStatusCode)
                                    {
                                        var tweets = result.Model.Tweets;
                                        if (tweets != null && tweets.Any())
                                        {
                                            foreach (var tweet in tweets)
                                            {
                                                if (context.Entries != null)
                                                {
                                                    var entry = (TwitterEntry?)await context.Entries.FirstOrDefaultAsync(x => x.Id == tweet.Id.ToString());
                                                    if (entry != null)
                                                    {
                                                        entry.Content = tweet.Text;
                                                        entry.Updated = tweet.CreatedAt;
                                                    }
                                                    else
                                                    {
                                                        await context.Entries.AddAsync(new TwitterEntry()
                                                        {
                                                            Id = tweet.Id.ToString(),
                                                            EntryType = EntryType.Twitter,
                                                            Title = user.Name,
                                                            Content = tweet.Text,
                                                            Updated = tweet.CreatedAt,
                                                            AuthorId = user.Id
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    await context.Feeds.AddAsync(
                                        new TwitterFeed()
                                        {
                                            Id = user.Id,
                                            FeedType = FeedType.Twitter,
                                            Title = user.Name,
                                            Link = user.Url,
                                            Username = user.Username,
                                            Entries = new Collection<Entry>(),
                                            Updated = DateTimeOffset.UtcNow,
                                            Fetched = DateTimeOffset.UtcNow
                                        });
                                }
                                await context.SaveChangesAsync();
                            }
                        }
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Log.Error("error updating twitter entries");
                Log.Error(e.Message);
            }
        }

        public async Task UpdateDefaultFeed(DefaultFeed feed)
        {
            using var reader = XmlReader.Create(feed.Link!);
            var syndicationFeed = SyndicationFeed.Load(reader);
            if (syndicationFeed.LastUpdatedTime > feed.Updated)
            {
                feed.Title = syndicationFeed.Title.Text;
                feed.Updated = syndicationFeed.LastUpdatedTime;
                feed.Fetched = DateTimeOffset.UtcNow;
                var entries = feed.Entries!.ToList();
                entries.Sort((x, y) => DateTimeOffset.Compare(x.Updated, y.Updated));
                var lastEntry = entries.LastOrDefault();
                if (lastEntry != null)
                {
                    var syndicationItems = syndicationFeed.Items.Where(x => UpdatedTime(x) > lastEntry.Updated);
                    foreach (var syndicationItem in syndicationItems)
                    {
                        var entry = new DefaultEntry()
                        {
                            Title = syndicationItem.Title.Text,
                            Summary = syndicationItem.Summary.Text,
                            Updated = await UpdatedTimeAsync(syndicationItem)
                        };
                        feed.Entries!.Add(entry);
                    }
                }
            }
        }

        public async Task SeedFeedsAsync(DefaultDbContext? context)
        {
            foreach (var url in urls)
            {
                using var reader = XmlReader.Create(url);
                var syndicationFeed = SyndicationFeed.Load(reader);
                var feed = new DefaultFeed()
                {
                    Link = url,
                    Title = syndicationFeed.Title.Text,
                    Entries = new Collection<Entry>(),
                    Updated = syndicationFeed.LastUpdatedTime,
                    Fetched = DateTimeOffset.UtcNow
                };
                foreach (var item in syndicationFeed.Items)
                {
                    var entry = new DefaultEntry()
                    {
                        Title = item.Title.Text,
                        Summary = item.Summary.Text,
                        Updated = await UpdatedTimeAsync(item)
                    };
                    feed.Entries.Add(entry);
                }
                await context!.Feeds!.AddAsync(feed);
                await context!.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Entry>> GetAllEntriesAsync()
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var entries = await context.Entries!.ToListAsync();
            entries.Sort((x, y) => DateTimeOffset.Compare(y.Updated, x.Updated));
            return entries;
        }

        public async Task<ICollection<Entry>> GetPagedEntriesAsync(int page, int items)
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var entries = await context.Entries!.ToListAsync();
            entries.Sort((x, y) => DateTimeOffset.Compare(y.Updated, x.Updated));
            return entries.Skip((page - 1) * items).Take(items).ToArray();
        }

        public async Task<ICollection<Entry>> GetPagedDefaultEntriesAsync(int page, int items)
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var entries = await context.Entries!.Where(x => x.EntryType == EntryType.Default).ToListAsync();
            entries.Sort((x, y) => DateTimeOffset.Compare(y.Updated, x.Updated));
            return entries.Skip((page - 1) * items).Take(items).ToArray();
        }

        public async Task<ICollection<Entry>> GetPagedTwitterEntriesAsync(int page, int items)
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var entries = await context.Entries!.Where(x => x.EntryType == EntryType.Twitter).ToListAsync();
            entries.Sort((x, y) => DateTimeOffset.Compare(y.Updated, x.Updated));
            return entries.Skip((page - 1) * items).Take(items).ToArray();
        }

        public async Task<int> GetLastTwitterEntryPageNumberAsync()
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var entries = await context.Entries!.Where(x => x.EntryType == EntryType.Twitter).ToListAsync();
            entries.Sort((x, y) => DateTimeOffset.Compare(y.Updated, x.Updated));
            var pages = entries.Count() / 25;
            return pages % 25 != 0 ? pages + 1 : pages;
        }

        Task<DateTimeOffset> UpdatedTimeAsync(SyndicationItem? syndicationItem)
        {
            if (syndicationItem!.LastUpdatedTime != DateTimeOffset.MinValue)
                return Task.FromResult(syndicationItem!.LastUpdatedTime);
            return Task.FromResult(syndicationItem!.PublishDate);
        }

        public async Task<string> GetTwitterUsernameFromId(string id)
        {
            using var context = await _defaultDbContextFactory.CreateDbContextAsync();
            var feed = await context.Feeds!.Where(x => x.FeedType == FeedType.Twitter).FirstOrDefaultAsync(x => x.Id == id);
            if (feed != null)
            {
                var username = ((TwitterFeed)feed).Username;
                return username ?? string.Empty;
            }
            return string.Empty;
        }


        DateTimeOffset UpdatedTime(SyndicationItem? syndicationItem) =>
            UpdatedTimeAsync(syndicationItem).Result;

        static readonly string[] urls =
        {
            "https://tools.cdc.gov/api/v2/resources/media/415826.rss",
            "http://rss.slashdot.org/Slashdot/slashdotMainatom"
        };
    }
}
