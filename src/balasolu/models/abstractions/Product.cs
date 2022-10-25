using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(ProductConverter))]
    public abstract class Product : Entity<string>, IProduct
    {
        public ProductType ProductType { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImageSource { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
    }
}
