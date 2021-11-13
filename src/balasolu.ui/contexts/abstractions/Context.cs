using balasolu.ui.contexts.interfaces;

namespace balasolu.ui.contexts.abstractions
{
    public abstract class Context : IReceivable
    {
        public virtual Action<object> Receive { get; set; } = _ => { };
    }
}
