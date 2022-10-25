namespace balasolu.models.interfaces
{
    public interface IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey? Id { get; set; }
    }
}
