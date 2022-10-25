using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(RoleConverter))]
    public abstract class Role : IdentityRole, IRole
    {
        [JsonConstructor]
        public Role() { }

        public RoleType RoleType { get; set; }
    }
}
