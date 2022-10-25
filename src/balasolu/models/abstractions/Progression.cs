using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(ProgressionConverter))]
    public abstract class Progression : Entity<string>, IProgression
    {
        public ProgressionType ProgressionType { get; set; }
        public string? BaseAsset { get; set; }
        public string? TradeAsset { get; set; }
        public decimal MeanPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public virtual ICollection<Sample>? Samples { get; set; }
        public DateTimeOffset? ProgressionStart { get; set; }
        public DateTimeOffset? ProgressionEnd { get; set; }
    }
}
