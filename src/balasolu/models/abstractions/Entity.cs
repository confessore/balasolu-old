using balasolu.models.interfaces;
using System;

namespace balasolu.models.abstractions
{
    public abstract class Entity<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey? Id { get; set; }
    }
}
