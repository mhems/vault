namespace Vault.Domain
{
    public class ClassModItem(
        EquipmentItem baseItem,
        PlayerClass @class,
        string prefix,
        IEnumerable<Boost> boosts
        )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public Guid BaseItemId => BaseItem.Id;
        public EquipmentItem BaseItem { get; private init; } = baseItem;

        public Guid PlayerClassId => Class.Id;
        public PlayerClass Class { get; private init; } = @class;
        public string Prefix { get; private init; } = prefix;
        public List<Boost> Boosts { get; private init; } = new List<Boost>(boosts);
    }

    public sealed class Boost(Skill skill, byte amount)
    {
        public Skill Skill { get; private init; } = skill;
        public byte Amount { get; private init; } = amount;
    }
}
