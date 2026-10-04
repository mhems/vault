namespace Vault.Domain
{
    public class NonPlayableCharacter(string species, string? name = null, bool enemy = false, Dlc dlc = Dlc.BaseGame)
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; } = name;

        public Dlc Dlc { get; set; } = dlc;

        public byte? Level { get; set; }

        public string Species { get; set; } = species;

        public string? SubSpecies { get; set; }

        public string? Affiliation { get; set; }

        public bool Enemy { get; set; } = enemy;

        public List<Location> Locations { get; set; } = [];
    }
}
