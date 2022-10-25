using balasolu.models.abstractions;
using balasolu.models.addresses;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class AddressConverter : JsonConverter<Address>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Address).IsAssignableFrom(typeToConvert);

        public override Address? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(AddressType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (AddressType)clone.GetInt32();
            return type switch
            {
                AddressType.Default => JsonSerializer.Deserialize<DefaultAddress>(ref reader, options),
                AddressType.Billing => JsonSerializer.Deserialize<BillingAddress>(ref reader, options),
                AddressType.Shipping => JsonSerializer.Deserialize<ShippingAddress>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Address value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
