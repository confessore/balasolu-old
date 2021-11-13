using System.ComponentModel;

namespace balasolu.models.enums
{
    public enum ItemType
    {
        [Description("Default")]
        Default,
        [Description("Armor")]
        Armor,
        [Description("Weapon")]
        Weapon,
        [Description("Other")]
        Other
    }
}
