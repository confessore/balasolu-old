using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(CartItem))]
    public abstract class CartItem : Entity<string>, ICartItem
    {
        public CartItemType CartItemType { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
