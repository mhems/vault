namespace Vault.Domain
{
    public class EquipmentItem(
        Player player,
        EquipmentModel model,
        byte level,
        Rarity rarity,
        uint? buyPrice = null,
        uint? sellPrice = null
        )
    {
        protected readonly List<Effect> effects = [];

        public Guid Id { get; protected init; } = Guid.NewGuid();

        public Guid ModelId => Model.Id;
        public EquipmentModel Model { get; protected set; } = model;

        public byte Level { get; protected init; } = level;

        public Guid RarityId => Rarity.Id;
        public Rarity Rarity { get; protected init; } = rarity;

        public uint? BuyPrice { get; protected init; } = buyPrice;
        public uint? SellPrice { get; protected init; } = sellPrice;

        public Guid PlayerId => Player.Id;
        public Player Player { get; protected init; } = player;

        //public Source Source {get; init;}
        public IReadOnlyCollection<Effect> Effects => effects.AsReadOnly();

        public void AddEffect(Effect effect)
        {
            effects.Add(effect);
        }
    }

    public sealed record ElementalDamage(string Element, double DamagePerSecond);

    public sealed record Effect(string Description, double Amount, string? Units = null);
}
