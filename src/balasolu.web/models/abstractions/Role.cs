using balasolu.models.enums;
using balasolu.models.interfaces;
using Microsoft.AspNetCore.Identity;

namespace balasolu.web.models.abstractions
{
    public abstract class Role : IdentityRole, IRole
    {
        public RoleType RoleType { get; set; }
    }
}
