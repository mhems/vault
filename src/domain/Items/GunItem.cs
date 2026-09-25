namespace Vault.Domain
{
    public class GunItem(
        EquipmentItem baseItem,
        int damage,
        double accuracy,
        double fireRate,
        double reloadSpeed,
        int magazineSize,
        int pelletCount = 1,
        ElementalDamage? elementalDamage = null,
        double? elementalChance = null,
        string? prefix = null
        )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public Guid BaseItemId => BaseItem.Id;
        public EquipmentItem BaseItem { get; private init; } = baseItem;

        public int Damage { get; private init; } = damage;
        public double Accuracy { get; private init; } = accuracy;
        public double FireRate { get; private init; } = fireRate;
        public double ReloadSpeed { get; private init; } = reloadSpeed;
        public int MagazineSize { get; private init; } = magazineSize;
        public int PelletCount { get; private init; } = pelletCount;

        public ElementalDamage? ElementalDamage { get; private init; } = elementalDamage;
        public double? ElementalChance { get; private init; } = elementalChance;

        public string? Prefix { get; private init; } = prefix;

        public string? Barrel { get; init; }
        public string? Stock { get; init; }
        public string? Grip { get; init; }
        public string? Scope { get; init; }
        public string? Body { get; init; }
    }
}
