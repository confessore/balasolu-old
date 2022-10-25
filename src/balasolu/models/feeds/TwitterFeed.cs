using balasolu.models.abstractions;

namespace balasolu.models.feeds
{
    public class TwitterFeed : Feed
    {
        public TwitterFeed()
        {
        }

        public string? Username { get; set; }
    }
}
