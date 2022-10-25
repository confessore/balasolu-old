using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.progressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class ProgressionConverter : JsonConverter<Progression>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Progression).IsAssignableFrom(typeToConvert);

        public override Progression? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(ProgressionType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (ProgressionType)clone.GetInt32();
            return type switch
            {
                ProgressionType.Default => JsonSerializer.Deserialize<DefaultProgression>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Progression value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
