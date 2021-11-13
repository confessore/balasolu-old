using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System;

namespace balasolu.web.models.abstractions
{
    public abstract class Post : Entity<string>, IPost
    {
        public PostType PostType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public virtual Item? ItemFT { get; set; }
        public virtual Item? ItemISO { get; set; }
        public virtual User? User { get; set; }
    }
}
