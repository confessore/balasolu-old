using balasolu.models.abstractions;
using balasolu.models.entries;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class EntryConverter : JsonConverter<Entry>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Entry).IsAssignableFrom(typeToConvert);

        public override Entry? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(EntryType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (EntryType)clone.GetInt32();
            return type switch
            {
                EntryType.Default => JsonSerializer.Deserialize<DefaultEntry>(ref reader, options),
                EntryType.Twitter => JsonSerializer.Deserialize<TwitterEntry>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Entry value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
