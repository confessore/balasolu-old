using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(BoothConverter))]
    public abstract class Booth : Entity<string>, IBooth
    {
        public BoothType BoothType { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImageSource { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
