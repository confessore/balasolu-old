using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(SampleConverter))]
    public abstract class Sample : Entity<string>, ISample
    {
        public SampleType SampleType { get; set; }
        public string? BaseAsset { get; set; }
        public string? TradeAsset { get; set; }
        public decimal MeanPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public virtual ICollection<Observation>? Observations { get; set; }
        public DateTimeOffset? SampleStart { get; set; }
        public DateTimeOffset? SampleEnd { get; set; }
    }
}
