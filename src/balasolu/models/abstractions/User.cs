using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(UserConverter))]
    public abstract class User : IdentityUser, IUser
    {
        [JsonConstructor]
        public User() { }

        public UserType UserType { get; set; }
        public virtual ICollection<Token>? Tokens { get; set; }
        public virtual Contact? Contact { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
