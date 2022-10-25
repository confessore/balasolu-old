using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(AgentConverter))]
    public abstract class Agent : Entity<string>, IAgent
    {
        public AgentType AgentType { get; set; }
        public virtual ICollection<Position>? Positions { get; set; }
    }
}
