using balasolu.models.abstractions;
using balasolu.models.agents;
using balasolu.models.enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace balasolu.converters
{
    public sealed class AgentConverter : JsonConverter<Agent>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Agent).IsAssignableFrom(typeToConvert);

        public override Agent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var clone = reader;
            while (clone.Read())
            {
                if (clone.TokenType == JsonTokenType.PropertyName)
                {
                    var name = clone.GetString();
                    if (name != null)
                    {
                        if (name.ToLower() == nameof(AgentType).ToLower())
                            break;
                    }
                }
            }
            clone.Read();
            var type = (AgentType)clone.GetInt32();
            return type switch
            {
                AgentType.Default => JsonSerializer.Deserialize<DefaultAgent>(ref reader, options),
                _ => null,
            };
        }

        public override void Write(Utf8JsonWriter writer, Agent value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
