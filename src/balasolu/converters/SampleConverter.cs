using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.samples;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class SampleConverter : JsonConverter<Sample>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Sample).IsAssignableFrom(typeToConvert);

        public override Sample? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(SampleType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (SampleType)clone.GetInt32();
            return type switch
            {
                SampleType.Default => JsonSerializer.Deserialize<DefaultSample>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Sample value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
