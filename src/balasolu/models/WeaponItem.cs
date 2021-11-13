using balasolu.models.abstractions;
using balasolu.models.enums.item.weapon;

namespace balasolu.models
{
    public sealed class WeaponItem : Item
    {
        public ItemWeaponType ItemWeaponType { get; set; }
        public ItemWeaponBase ItemWeaponBase { get; set; }
    }
}
