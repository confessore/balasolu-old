using balasolu.models.enums;
using balasolu.models.enums.item;
using balasolu.models.interfaces;

namespace balasolu.models.abstractions
{
    public abstract class Item : Entity<string>, IItem
    {
        public ItemType ItemType { get; set; }
        public string? Name { get; set; }
        public ItemQuality ItemQuality { get; set; }
        public ItemRarity ItemRarity { get; set; }
        public bool Ethereal { get; set; }
        public bool Unidentified { get; set; }
        public bool Perfect { get; set; }
        public bool Upped { get; set; }
        public bool Socketed { get; set; }
        public int Sockets { get; set; }
        public int MaxSockets { get; set; }
        public int Quantity { get; set; }
    }
}
