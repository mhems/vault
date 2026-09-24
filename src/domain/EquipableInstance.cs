namespace Vault.Domain
{
    public class EquipableInstance(
        Guid playerId,
        string name,
        string category,
        string manufacturer,
        byte level,
        //Rarity rarity,
        bool unique = false,
        uint? buyPrice = null,
        uint? sellPrice = null,
        string? flavorText = null
        )
    {
        //protected readonly List<Source> sources = [];
        //protected readonly List<Effect> effects = [];

        public Guid Id { get; protected init; } = Guid.NewGuid();

        public string Name { get; protected init; } = name;

        public string Category { get; protected init; } = category;

        public string Manufacturer { get; protected init; } = manufacturer;

        public byte Level { get; protected init; } = level;

        //public Rarity Rarity { get; protected init; } = rarity;

        public bool Unique { get; protected init; } = unique;

        public uint? BuyPrice { get; protected init; } = buyPrice;

        public uint? SellPrice { get; protected init; } = sellPrice;

        public string? FlavorText { get; protected init; } = flavorText ?? string.Empty;

        public Guid PlayerId { get; protected init; } = playerId;

        public Player Player { get; protected init; } = null!;

        //public IReadOnlyCollection<Source> Sources => sources.AsReadOnly();

        //public IReadOnlyCollection<Effect> Effects => effects.AsReadOnly();
    }
}
