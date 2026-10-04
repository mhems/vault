namespace Vault.Domain
{
    public class GrenadeItem : EquipmentItem
    {
        public int Damage { get; private init; }
        public int BlastRadius { get; private init; }
        public double Fuse { get; private init; }
        public GrenadeDelivery Delivery { get; private init; }
        public bool Sticky { get; private init; }
        public int? ChildCount { get; private init; }

        public ElementalDamage? ElementalDamage { get; private init; }

        private GrenadeItem() : base() { }

        public GrenadeItem(Player player,
            GrenadeModel model,
            byte? level,
            Rarity rarity,
            int damage,
            int blastRadius,
            double fuse,
            GrenadeDelivery delivery,
            bool sticky = false,
            int? childCount = null,
            ElementalDamage? elementalDamage = null,
            uint? buyPrice = null,
            uint? sellPrice = null) : base(player, model, level, rarity, buyPrice, sellPrice)
        {
            Damage = damage;
            BlastRadius = blastRadius;
            Fuse = fuse;
            Delivery = delivery;
            Sticky = sticky;
            ChildCount = childCount;
            ElementalDamage = elementalDamage;
        }
    }
}
