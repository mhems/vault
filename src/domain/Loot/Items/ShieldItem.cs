namespace Vault.Domain
{
    public class ShieldItem : EquipmentItem
    {
        public int Capacity { get; private init; }
        public int RechargeRate { get; private init; }
        public double RechargeDelay { get; private init; }

        public string? Prefix { get; set; }

        public ElementalDamage? ElementalDamage { get; private init; }

        public Element? ElementalImmunity { get; set; }
        public Element? ElementalReduction { get; set; }

        public Manufacturer? Battery { get; init; }
        public Manufacturer? Capacitor { get; init; }
        public Manufacturer? Body { get; init; }

        private ShieldItem() : base() { }

        public ShieldItem(Player player,
            ShieldModel model,
            byte? level,
            Rarity rarity,
            int capacity,
            int rechargeRate,
            double rechargeDelay,
            string? prefix = null,
            ElementalDamage? elementalDamage = null,
            Element? immunity = null,
            Element? reduction = null,
            uint? buyPrice = null,
            uint? sellPrice = null) : base(player, model, level, rarity, buyPrice, sellPrice)
        {
            Capacity = capacity;
            RechargeRate = rechargeRate;
            RechargeDelay = rechargeDelay;
            ElementalDamage = elementalDamage;
            ElementalImmunity = immunity;
            ElementalReduction = reduction;
            Prefix = prefix;
        }
    }
}
