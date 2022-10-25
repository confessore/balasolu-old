using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(AuthorConverter))]
    public abstract class Author : Entity<string>, IAuthor
    {
        public AuthorType AuthorType { get; set; }
        public string? Name { get; set; }
        public string? Uri { get; set; }
        public string? Email { get; set; }
    }
}
