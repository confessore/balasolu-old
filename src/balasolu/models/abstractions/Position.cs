using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(PositionConverter))]
    public abstract class Position : Entity<string>, IPosition
    {
        public PositionType PositionType { get; set; }
        public string? BaseAsset { get; set; }
        public string? TradeAsset { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public DateTimeOffset PurchasedAt { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
    }
}
