using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(EntryConverter))]
    public abstract class Entry : Entity<string>, IEntity<string>, IEntry
    {
        public EntryType EntryType { get; set; }
        public string? Title { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
    }
}
