using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace balasolu.web.models.abstractions
{
    public abstract class User : IdentityUser, IUser
    {
        public UserType UserType { get; set; }
        public virtual bool PC { get; set; }
        public virtual bool Switch { get; set; }
        public virtual bool Xbox { get; set; }
        public virtual bool PlayStation { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
    }
}
