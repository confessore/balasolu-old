using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(ContactConverter))]
    public abstract class Contact : Entity<string>, IContact
    {
        public ContactType ContactType { get; set; }
        public virtual ICollection<Phone>? Phones { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
