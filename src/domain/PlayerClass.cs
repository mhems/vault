namespace Vault.Domain
{
    public class PlayerClass(
        string name
        )
    {
        private readonly HashSet<Skill> skills = [];
        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Name { get; private init; } = name;

        public IReadOnlySet<Skill> Skills => skills.AsReadOnly();
    }
}
