using balasolu.models.abstractions;
using balasolu.models.booths;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class BoothConverter : JsonConverter<Booth>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Booth).IsAssignableFrom(typeToConvert);

        public override Booth? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(BoothType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (BoothType)clone.GetInt32();
            return type switch
            {
                BoothType.Default => JsonSerializer.Deserialize<DefaultBooth>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Booth value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
