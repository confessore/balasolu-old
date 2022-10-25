using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(TrendConverter))]
    public abstract class Trend : Entity<string>, ITrend
    {
        public TrendType TrendType { get; set; }
        public string? BaseAsset { get; set; }
        public string? TradeAsset { get; set; }
        public decimal MeanPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public virtual ICollection<Progression>? Progressions { get; set; }
        public DateTimeOffset? TrendStart { get; set; }
        public DateTimeOffset? TrendEnd { get; set; }
    }
}
