using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.positions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class PositionConverter : JsonConverter<Position>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Position).IsAssignableFrom(typeToConvert);

        public override Position? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(PositionType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (PositionType)clone.GetInt32();
            return type switch
            {
                PositionType.Default => JsonSerializer.Deserialize<DefaultPosition>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Position value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
