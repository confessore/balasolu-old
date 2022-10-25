using System.ComponentModel;

namespace balasolu.models.enums
{
    public enum AddressType
    {
        [Description("Default")]
        Default,
        [Description("Billing")]
        Billing,
        [Description("Shipping")]
        Shipping
    }
}
