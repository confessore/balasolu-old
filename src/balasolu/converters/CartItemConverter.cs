using balasolu.cartitems;
using balasolu.models.abstractions;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class CartItemConverter : JsonConverter<CartItem>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(CartItem).IsAssignableFrom(typeToConvert);

        public override CartItem? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(CartItemType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (CartItemType)clone.GetInt32();
            return type switch
            {
                CartItemType.Default => JsonSerializer.Deserialize<DefaultCartItem>(ref reader, options),
                CartItemType.Digital => JsonSerializer.Deserialize<DigitalCartItem>(ref reader, options),
                CartItemType.Physical => JsonSerializer.Deserialize<PhysicalCartItem>(ref reader, options),
                CartItemType.Service => JsonSerializer.Deserialize<ServiceCartItem>(ref reader, options),
                CartItemType.Subscription => JsonSerializer.Deserialize<SubscriptionCartItem>(ref reader, options),
                CartItemType.Affiliate => JsonSerializer.Deserialize<AffiliateCartItem>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, CartItem value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
