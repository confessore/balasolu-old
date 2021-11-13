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
    public static class UniqueItems
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
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.Axe,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueAxeNormal.Axe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.BattleAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeNormal.BattleAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.BroadAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeNormal.BroadAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.DoubleAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeNormal.DoubleAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.GiantAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeNormal.GiantAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.GreatAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeNormal.GreatAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.HandAxe,
                    MaxSockets = 2,
                    Name = ItemWeaponUniqueAxeNormal.HandAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.LargeAxe,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueAxeNormal.LargeAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.MilitaryPick,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeNormal.MilitaryPick.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeNormal.WarAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeNormal.WarAxe.GetDescription()
                },

                #endregion

                #region exceptional

                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.AncientAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeExceptional.AncientAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.BeardedAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeExceptional.BeardedAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.Cleaver,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueAxeExceptional.Cleaver.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.Crowbill,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeExceptional.Crowbill.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.GothicAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeExceptional.GothicAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.Hatchet,
                    MaxSockets = 2,
                    Name = ItemWeaponUniqueAxeExceptional.Hatchet.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.MilitaryAxe,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueAxeExceptional.MilitaryAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.Naga,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeExceptional.Naga.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.Tabar,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeExceptional.Tabar.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeExceptional.TwinAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeExceptional.TwinAxe.GetDescription()
                },

                #endregion

                #region elite

                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.BerserkerAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeElite.BerserkerAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.ChampionAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeElite.ChampionAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.Decapitator,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeElite.Decapitator.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.EttinAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeElite.EttinAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.FeralAxe,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueAxeElite.FeralAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.GloriousAxe,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeElite.GloriousAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.SilverEdgedAxe,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueAxeElite.SilverEdgedAxe.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.SmallCrescent,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueAxeElite.SmallCrescent.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.Tomahawk,
                    MaxSockets = 2,
                    Name = ItemWeaponUniqueAxeElite.Tomahawk.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Axe,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseAxeElite.WarSpike,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueAxeElite.WarSpike.GetDescription()
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
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.CompositeBow,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueBowNormal.CompositeBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.HuntersBow,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueBowNormal.HuntersBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.LongBattleBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowNormal.LongBattleBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.LongBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowNormal.LongBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.LongWarBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowNormal.LongWarBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.ShortBattleBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowNormal.ShortBattleBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.ShortBow,
                    MaxSockets = 3,
                    Name = ItemWeaponUniqueBowNormal.ShortBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Normal,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowNormal.ShortWarBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowNormal.ShortWarBow.GetDescription()
                },

                #endregion

                #region exceptional

                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.CedarBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowExceptional.CedarBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.DoubleBow,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueBowExceptional.DoubleBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.EdgeBow,
                    MaxSockets = 3,
                    Name = ItemWeaponUniqueBowExceptional.EdgeBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.GothicBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowExceptional.GothicBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.LongSiegeBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowExceptional.LongSiegeBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.RazorBow,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueBowExceptional.RazorBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.RuneBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowExceptional.RuneBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Exceptional,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowExceptional.ShortSiegeBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowExceptional.ShortSiegeBow.GetDescription()
                },

                #endregion

                #region elite

                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.BladeBow,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueBowElite.BladeBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.CrusaderBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowElite.CrusaderBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.DiamondBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowElite.DiamondBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.GreatBow,
                    MaxSockets = 4,
                    Name = ItemWeaponUniqueBowElite.GreatBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.HydraBow,
                    MaxSockets = 6,
                    Name = ItemWeaponUniqueBowElite.HydraBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.ShadowBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowElite.ShadowBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.SpiderBow,
                    MaxSockets = 3,
                    Name = ItemWeaponUniqueBowElite.SpiderBow.GetDescription()
                },
                new WeaponItem()
                {
                    ItemType = ItemType.Weapon,
                    ItemQuality = ItemQuality.Elite,
                    ItemRarity = ItemRarity.Unique,
                    ItemWeaponType = ItemWeaponType.Bow,
                    ItemWeaponBase = (ItemWeaponBase)ItemWeaponBaseBowElite.WardBow,
                    MaxSockets = 5,
                    Name = ItemWeaponUniqueBowElite.WardBow.GetDescription()
                }

                #endregion
            };

        #endregion
    }
}
