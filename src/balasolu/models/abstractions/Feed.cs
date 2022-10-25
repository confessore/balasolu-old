using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(FeedConverter))]
    public abstract class Feed : Entity<string>, IFeed
    {
        public FeedType FeedType { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public DateTimeOffset Updated { get; set; }
        public DateTimeOffset Fetched { get; set; }
        public virtual ICollection<Entry>? Entries { get; set; }
    }
}
