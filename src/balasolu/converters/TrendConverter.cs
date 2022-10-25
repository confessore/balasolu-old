using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.trends;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class TrendConverter : JsonConverter<Trend>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Trend).IsAssignableFrom(typeToConvert);

        public override Trend? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(TrendType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (TrendType)clone.GetInt32();
            return type switch
            {
                TrendType.Default => JsonSerializer.Deserialize<DefaultTrend>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Trend value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
