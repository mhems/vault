namespace Vault.Domain
{
    public abstract class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Dlc Dlc { get; set; }

        public List<NonPlayableCharacter> Characters { get; set; } = [];

        public Location(string name, Dlc dlc = Dlc.BaseGame)
        {
            Name = name;
            Dlc = dlc;
        }
    }
}
