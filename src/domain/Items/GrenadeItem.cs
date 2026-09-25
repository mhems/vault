namespace Vault.Domain
{
    public class GrenadeItem(
        EquipmentItem baseItem,
        int damage,
        int blastRadius,
        double fuse,
        string delivery,
        bool sticky = false,
        int? childCount = null,
        ElementalDamage? elementalDamage = null
        )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public Guid BaseItemId => BaseItem.Id;
        public EquipmentItem BaseItem { get; private init; } = baseItem;

        public int Damage { get; private init; } = damage;
        public int BlastRadius { get; private init; } = blastRadius;
        public double Fuse { get; private init; } = fuse;
        public string Delivery { get; private init; } = delivery;
        public bool Sticky { get; private init; } = sticky;
        public int? ChildCount { get; private init; } = childCount;

        public ElementalDamage? ElementalDamage { get; private init; } = elementalDamage;
    }
}
