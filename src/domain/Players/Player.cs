
namespace Vault.Domain
{
    public class Player
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public Guid PlayerClassId { get; private init; }
        public PlayerClass Class { get; private init; }

        public Guid AccountId { get; private init; }
        public Account Account { get; private init; }

        public string Name { get; private set; }

        public byte Level { get; private set; }

        public uint? Experience { get; init; }

        public uint? Money { get; init; }

        public List<EquipmentItem> Equipment { get; set; } = [];
        public HashSet<PlayerSkill> SkillTree { get; set; } = [];

        private Player() { }
        public Player(Account account,
            PlayerClass @class,
            string name,
            byte? level = null,
            uint? experience = null,
            uint? money = null)
        {
            Account = account;
            AccountId = account.Id;
            Class = @class;
            PlayerClassId = @class.Id;
            Name = name;
            Level = level ?? 1;
            Experience = experience;
            Money = money;
        }

        public void LevelUp()
        {
            Level += 1;
        }

        public void SetLevel(int level)
        {
            if (level < 0 || level > 90)
            {
                throw new ArgumentException("level must be between 0 and 90");
            }

            if (level < Level)
            {
                throw new ArgumentException("cannot decrease level");
            }

            Level = (byte)level;
        }

        public void InvestIn(Skill skill, byte amount = 1)
        {
            if (skill.PlayerClassId != PlayerClassId)
            {
                throw new ArgumentException($"skill '{skill.Name}' does not belong to {Class.Name}", nameof(skill));
            }

            var playerSkill = SkillTree.FirstOrDefault(ps => ps.Skill.Id == skill.Id);
            if (playerSkill == null)
            {
                playerSkill = new(skill);
                playerSkill.Invest(amount);
                SkillTree.Add(playerSkill);
            }
            else
            {
                playerSkill.Invest(amount);
            }
        }

        public void ClearSkillTree()
        {
            SkillTree.Clear();
        }

        public void AddEquipment(EquipmentItem item)
        {
            Equipment.Add(item);
        }
    }

    public sealed class PlayerSkill : IEquatable<PlayerSkill>
    {
        public Guid SkillId { get; private init; }
        public Skill Skill { get; private init; }
        public byte Amount { get; private set; }

        private PlayerSkill() { }
        public PlayerSkill(Skill skill)
        {
            Skill = skill;
            SkillId = skill.Id;
        }

        public void Invest(byte amount = 1)
        {
            int max = Skill.OnePointMax ? 1 : 5;
            var total = Amount + amount;
            if (total > max)
            {
                throw new ArgumentException("cannot invest into skill further");
            }
            Amount = (byte)total;
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
            if (skill == null)
            {
                return Skill == null;
            }
            return Skill?.Equals(skill) ?? skill == null;
        }

        public override int GetHashCode()
        {
            return Skill?.GetHashCode() ?? 0;
        }
    }
}
