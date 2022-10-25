using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(ObservationConverter))]
    public abstract class Observation : Entity<string>, IObservation
    {
        public ObservationType ObservationType { get; set; }
        public string? BaseAsset { get; set; }
        public string? TradingAsset { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset ObservedAt { get; set; }
    }
}
