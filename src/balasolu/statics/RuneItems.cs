using balasolu.extensions;
using balasolu.models;
using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.enums.item;
using balasolu.models.enums.item.other;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace balasolu.statics
{
    public static class RuneItems
    {
        public static Task<IEnumerable<Item>> GenerateRuneItemsAsync()
        {
            var list = new List<Item>();
            foreach (var enumValue in Enum.GetValues<ItemOtherRune>())
            {
                if (enumValue != ItemOtherRune.Default)
                {
                    var item = new OtherItem()
                    {
                        ItemType = ItemType.Other,
                        ItemQuality = ItemQuality.Default,
                        ItemRarity = ItemRarity.Default,
                        ItemOtherType = ItemOtherType.Rune,
                        ItemOtherBase = ItemOtherBase.Default,
                        MaxSockets = 0,
                        Name = enumValue.GetDescription()
                    };
                    list.Add(item);
                }
            }
            return Task.FromResult((IEnumerable<Item>)list);
        }
    }
}
