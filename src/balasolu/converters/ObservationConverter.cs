using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.observations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class ObservationConverter : JsonConverter<Observation>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Observation).IsAssignableFrom(typeToConvert);

        public override Observation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(ObservationType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (ObservationType)clone.GetInt32();
            return type switch
            {
                ObservationType.Default => JsonSerializer.Deserialize<DefaultObservation>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Observation value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
