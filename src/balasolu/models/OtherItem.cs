using balasolu.models.abstractions;
using balasolu.models.enums.item.other;

namespace balasolu.models
{
    public sealed class OtherItem : Item
    {
        public ItemOtherType ItemOtherType { get; set; }
        public ItemOtherBase ItemOtherBase { get; set; }
    }
}
