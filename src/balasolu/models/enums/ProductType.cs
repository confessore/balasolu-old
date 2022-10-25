using System.ComponentModel;

namespace balasolu.models.enums
{
    public enum ProductType
    {
        [Description("Default")]
        Default,
        [Description("Digital")]
        Digital,
        [Description("Physical")]
        Physical,
        [Description("Service")]
        Service,
        [Description("Subscription")]
        Subscription,
        [Description("Affiliate")]
        Affiliate
    }
}
