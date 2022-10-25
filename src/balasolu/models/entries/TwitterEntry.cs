
using balasolu.models.abstractions;
using balasolu.models.interfaces;

namespace balasolu.models.entries
{
    public class TwitterEntry : Entry, IEntity<string>, IEntry
    {
        public TwitterEntry()
        {
        }

        public string? AuthorId { get; set; }
    }
}
