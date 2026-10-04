namespace Vault.Domain
{
    public class GunItem : EquipmentItem
    {
        public int Damage { get; private init; }
        public double Accuracy { get; private init; }
        public double FireRate { get; private init; }
        public double ReloadSpeed { get; private init; }
        public int MagazineSize { get; private init; }
        public int? PelletCount { get; private init; }

        public ElementalDamage? ElementalDamage { get; private init; }
        public double? ElementalChance { get; private init; }

        public string? Prefix { get; private init; }

        public bool MissionItem { get; private init; }

        public Manufacturer? Barrel { get; init; }
        public Manufacturer? Stock { get; init; }
        public Manufacturer? Grip { get; init; }
        public Manufacturer? Scope { get; init; }
        public Manufacturer? Body { get; init; }

        private GunItem() : base() { }

        public GunItem(Player player,
            GunModel model,
            byte? level,
            Rarity rarity,
            int damage,
            double accuracy,
            double fireRate,
            double reloadSpeed,
            int magazineSize,
            int? pelletCount = null,
            ElementalDamage? elementalDamage = null,
            double? elementalChance = null,
            string? prefix = null,
            bool missionItem = false,
            uint? buyPrice = null,
            uint? sellPrice = null) : base(player, model, level, rarity, buyPrice, sellPrice)
        {
            Damage = damage;
            Accuracy = accuracy;
            FireRate = fireRate;
            ReloadSpeed = reloadSpeed;
            MagazineSize = magazineSize;
            PelletCount = pelletCount;
            ElementalDamage = elementalDamage;
            ElementalChance = elementalChance;
            Prefix = prefix;
            MissionItem = missionItem;
        }
    }
}
