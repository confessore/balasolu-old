using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(CartConverter))]
    public abstract class Cart : Entity<string>, ICart
    {
        public CartType CartType { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
