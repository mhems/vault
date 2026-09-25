
namespace Vault.Domain
{
    public class Player(
        PlayerClass @class,
        string name,
        byte level = 1
        )
    {
        private readonly List<EquipmentItem> equipment = [];
        private readonly Dictionary<Skill, PlayerSkill> skillTree = [];

        public Guid Id { get; private init; } = Guid.NewGuid();

        public Guid PlayerClassId => Class.Id;
        public PlayerClass Class { get; private init; } = @class;

        public string Name { get; private set; } = name;

        public byte Level { get; private set; } = level;

        public uint? Experience { get; init; } = 0;

        public uint? Money { get; init; }

        public IReadOnlyCollection<EquipmentItem> Equipment => equipment.AsReadOnly();
        public IReadOnlySet<PlayerSkill> SkillTree => skillTree.Values.ToHashSet().AsReadOnly();

        public void InvestIn(Skill skill, byte amount = 1)
        {
            if (skillTree.TryGetValue(skill, out PlayerSkill? playerSkill))
            {
                playerSkill.Invest(amount);
            }
            else
            {
                playerSkill = new(skill);
                playerSkill.Invest(amount);
                skillTree[skill] = playerSkill;
            }
        }
    }

    public sealed class PlayerSkill(Skill skill) : IEquatable<PlayerSkill>
    {
        public Guid SkillId => Skill.Id;
        public Skill Skill { get; private init; } = skill;
        public byte Amount { get; private set; } = 0;

        public void Invest(byte amount = 1)
        {
            int max = Skill.OnePointMax ? 1 : 5;
            byte newAmount = (byte)Math.Clamp(Amount + amount, 0, max);
            Amount = newAmount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is PlayerSkill skill)
            {
                return Equals(skill);
            }
            return false;
        }

        public bool Equals(PlayerSkill? skill)
        {
            if (skill is null)
            {
                return false;
            }
            return Skill.Equals(skill);
        }

        public override int GetHashCode()
        {
            return Skill.GetHashCode();
        }
    }
}
