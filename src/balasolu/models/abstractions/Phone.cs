using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(PhoneConverter))]
    public abstract class Phone : Entity<string>, IPhone
    {
        public PhoneType PhoneType { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Discriminator { get; set; }
    }
}
