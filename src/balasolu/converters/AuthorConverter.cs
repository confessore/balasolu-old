using balasolu.models.abstractions;
using balasolu.models.authors;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class AuthorConverter : JsonConverter<Author>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Author).IsAssignableFrom(typeToConvert);

        public override Author? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(AuthorType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (AuthorType)clone.GetInt32();
            return type switch
            {
                AuthorType.Default => JsonSerializer.Deserialize<DefaultAuthor>(ref reader, options),
                AuthorType.Twitter => JsonSerializer.Deserialize<TwitterAuthor>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Author value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
