using balasolu.models.abstractions;
using balasolu.models.enums.item.armor;

namespace balasolu.models
{
    public sealed class ArmorItem : Item
    {
        public ItemArmorType ItemArmorType { get; set; }
        public ItemArmorBase ItemArmorBase { get; set; }
    }
}
