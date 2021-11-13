using balasolu.ui.components;
using balasolu.ui.contexts.abstractions;
using Microsoft.AspNetCore.Components.Web;

namespace balasolu.ui.contexts
{
    class DivContext : Context
    {
        public virtual Action<MouseEventArgs>? OnMouseDown { get; set; }
        public virtual Action<MouseEventArgs>? OnMouseUp { get; set; }

        public DivComponent? Source { get; set; }

        public override Action<object> Receive => obj =>
        {
            
        };
    }
}
