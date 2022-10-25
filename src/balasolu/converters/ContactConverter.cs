using balasolu.models.abstractions;
using balasolu.models.contacts;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class ContactConverter : JsonConverter<Contact>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Contact).IsAssignableFrom(typeToConvert);

        public override Contact? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(ContactType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (ContactType)clone.GetInt32();
            return type switch
            {
                ContactType.Default => JsonSerializer.Deserialize<DefaultContact>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Contact value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
