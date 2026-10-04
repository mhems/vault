namespace Vault.Domain
{
    public class PlayerClass(
        string name,
        Dlc dlc = Dlc.BaseGame
        )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Name { get; private init; } = name;

        public Dlc Dlc { get; set; } = dlc;

        public HashSet<Skill> Skills { get; set; } = [];

        public List<Player> Players { get; set; } = [];

        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }
    }
}
