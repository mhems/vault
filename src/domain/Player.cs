
namespace Vault.Domain
{
    public class Player(
        string @class,
        string name
        )
    {
        private readonly List<EquipableInstance> equipment = [];

        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Class { get; private init; } = @class;

        public string Name { get; private set; } = name;

        public byte Level { get; private set; } = 1;

        public uint Experience { get; private init; } = 0;

        public uint Money { get; private init; } = 0;

        public IReadOnlyCollection<EquipableInstance> Equipment => equipment.AsReadOnly();
    }
}
