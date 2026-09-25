namespace Vault.Domain
{
    public class ShieldItem(
        EquipmentItem baseItem,
        int capacity,
        int rechargeRate,
        double rechargeDelay,
        ElementalDamage? elementalDamage = null
        )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public Guid BaseItemId => BaseItem.Id;
        public EquipmentItem BaseItem { get; private init; } = baseItem;

        public int Capacity { get; private init; } = capacity;
        public int RechargeRate { get; private init; } = rechargeRate;
        public double RechargeDelay { get; private init; } = rechargeDelay;

        public ElementalDamage? ElementalDamage { get; private init; } = elementalDamage;

        public string? Battery { get; init; }
        public string? Capacitor { get; init; }
        public string? Body { get; init; }
    }
}
