namespace Vault.Domain
{
    public class Skill(
        string name,
        bool onePointMax,
        PlayerClass @class,
        string tree,
        byte tier,
        byte column,
        string? description = null
        ) : IEquatable<Skill>
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Name { get; private init; } = name;

        public bool OnePointMax { get; private init; } = onePointMax;

        public Guid PlayerClassId => Class.Id;
        public PlayerClass Class { get; private init; } = @class;

        public string Tree { get; private init; } = tree;

        public byte Tier { get; private init; } = tier;

        public byte Column { get; private init; } = column;

        public string? Description { get; private init; } = description;

        public override bool Equals(object? obj)
        {
            if (obj is Skill other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(Skill? other)
        {
            if (other is null)
            {
                return false;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
