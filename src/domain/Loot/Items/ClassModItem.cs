namespace Vault.Domain
{
    public class ClassModItem : EquipmentItem
    {
        public Guid PlayerClassId { get; private init; }
        public PlayerClass Class { get; private init; }
        public string Prefix { get; private init; }
        public List<SkillBoost> Boosts { get; private init; }

        private ClassModItem() : base() { }
        public ClassModItem(Player player,
            ClassModModel model,
            byte? level,
            Rarity rarity,
            PlayerClass @class,
            string prefix,
            IEnumerable<SkillBoost> boosts,
            uint? buyPrice = null,
            uint? sellPrice = null) : base(player, model, level, rarity, buyPrice, sellPrice)
        {
            Class = @class;
            PlayerClassId = @class.Id;
            Prefix = prefix;
            Boosts = new(boosts);
        }
    }

    public sealed class SkillBoost(Skill skill, byte amount)
    {
        public Guid SkillId { get; private init; } = skill.Id;
        public Skill Skill { get; private init; } = skill;
        public byte Amount { get; private init; } = amount;

        private SkillBoost() : this(null!, 0) { }
    }
}
