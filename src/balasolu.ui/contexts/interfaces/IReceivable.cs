namespace balasolu.ui.contexts.interfaces
{
    public interface IReceivable
    {
        Action<object> Receive { get; set; }
    }
}
