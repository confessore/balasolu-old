using System.ComponentModel;

namespace balasolu.models.enums.item
{
    public enum ItemRarity
    {
        [Description("")]
        Default,
        [Description("Normal")]
        Normal,
        [Description("Superior")]
        Superior,
        [Description("Magic")]
        Magic,
        [Description("Rare")]
        Rare,
        [Description("Unique")]
        Unique,
        [Description("Set")]
        Set,
        [Description("Runeword")]
        Runeword,
        [Description("Crafted")]
        Crafted
    }
}
