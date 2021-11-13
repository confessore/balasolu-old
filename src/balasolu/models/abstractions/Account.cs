using balasolu.models.enums;
using balasolu.models.interfaces;

namespace balasolu.models.abstractions
{
    public abstract class Account : Entity<ulong>, IAccount
    {
        public AccountType AccountType { get; set; }
    }
}
