using balasolu.models.abstractions;
using balasolu.models.carts;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class CartConverter : JsonConverter<Cart>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Cart).IsAssignableFrom(typeToConvert);

        public override Cart? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(CartType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (CartType)clone.GetInt32();
            return type switch
            {
                CartType.Default => JsonSerializer.Deserialize<DefaultCart>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Cart value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
