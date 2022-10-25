using System.ComponentModel;

namespace balasolu.models.enums
{
    public enum TokenType
    {
        [Description("Default")]
        Default,
        [Description("Authentication")]
        Authentication,
        [Description("Refresh")]
        Refresh
    }
}
