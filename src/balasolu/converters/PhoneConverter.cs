using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.phones;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class PhoneConverter : JsonConverter<Phone>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Phone).IsAssignableFrom(typeToConvert);

        public override Phone? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(PhoneType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (PhoneType)clone.GetInt32();
            return type switch
            {
                PhoneType.Default => JsonSerializer.Deserialize<DefaultPhone>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Phone value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
