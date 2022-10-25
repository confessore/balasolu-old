using balasolu.models.abstractions;

namespace balasolu.models.users
{
    public class VendorUser : User
    {
        public virtual Booth? Booth { get; set; }
    }
}
