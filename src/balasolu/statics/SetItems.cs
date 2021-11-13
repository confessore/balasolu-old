using balasolu.extensions;
using balasolu.models;
using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.enums.item;
using balasolu.models.enums.item.weapon;
using balasolu.models.enums.item.weapon.axe;
using balasolu.models.enums.item.weapon.bow;
using System.Collections.Generic;

namespace balasolu.statics
{
    public static class SetItems
    {
        #region axes

        public static readonly IEnumerable<Item> axes =
            new List<Item>()
            {
                #region normal

                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Set,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.DoubleAxe,
                    MaxSockets = 4,
                    Name = ItemWeaponSetAxeNormal.DoubleAxe.GetDescription()
                }

                #endregion
            };

        #endregion

        #region bows

        public static readonly IEnumerable<Item> bows =
            new List<Item>()
            {
                #region normal

                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Set,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.LongBattleBow,
                    MaxSockets = 4,
                    Name = ItemWeaponSetBowNormal.LongBattleBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Set,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.ShortWarBow,
                    MaxSockets = 4,
                    Name = ItemWeaponSetBowNormal.ShortWarBow.GetDescription()
                }

                #endregion
            };

        #endregion
    }
}
