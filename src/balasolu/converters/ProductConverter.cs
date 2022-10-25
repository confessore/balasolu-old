using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.products;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class ProductConverter : JsonConverter<Product>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Product).IsAssignableFrom(typeToConvert);

        public override Product? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(ProductType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (ProductType)clone.GetInt32();
            return type switch
            {
                ProductType.Default => JsonSerializer.Deserialize<DefaultProduct>(ref reader, options),
                ProductType.Digital => JsonSerializer.Deserialize<DigitalProduct>(ref reader, options),
                ProductType.Physical => JsonSerializer.Deserialize<PhysicalProduct>(ref reader, options),
                ProductType.Service => JsonSerializer.Deserialize<ServiceProduct>(ref reader, options),
                ProductType.Subscription => JsonSerializer.Deserialize<SubscriptionProduct>(ref reader, options),
                ProductType.Affiliate => JsonSerializer.Deserialize<AffiliateProduct>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
