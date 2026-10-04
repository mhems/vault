namespace Vault.Domain
{
    public class Skill : IEquatable<Skill>
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Name { get; private init; }

        public bool OnePointMax { get; private init; }

        public Guid PlayerClassId { get; private init; }
        public PlayerClass Class { get; private init; }

        public string Tree { get; private init; }

        public byte Tier { get; private init; }

        public byte Column { get; private init; }

        public string? Description { get; private init; }

        private Skill() { }
        public Skill(string name,
            bool onePointMax,
            PlayerClass @class,
            string tree,
            byte tier,
            byte column,
            string? description = null
        )
        {
            Name = name;
            OnePointMax = onePointMax;
            Class = @class;
            PlayerClassId = @class.Id;
            Tree = tree;
            Tier = tier;
            Column = column;
            Description = description;
        }

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
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
