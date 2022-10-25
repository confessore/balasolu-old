using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.feeds;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class FeedConverter : JsonConverter<Feed>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Feed).IsAssignableFrom(typeToConvert);

        public override Feed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(FeedType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (FeedType)clone.GetInt32();
            return type switch
            {
                FeedType.Default => JsonSerializer.Deserialize<DefaultFeed>(ref reader, options),
                FeedType.Twitter => JsonSerializer.Deserialize<DefaultFeed>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Feed value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
