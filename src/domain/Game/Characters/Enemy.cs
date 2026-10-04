namespace Vault.Domain
{
    public class Enemy : NonPlayableCharacter
    {
        public string? Prefix { get; set; }
        public bool HasShield { get; set; }

        public List<ElementalAffinity> Weaknesses { get; set; } = [];
        public List<ElementalAffinity> Resistances { get; set; } = [];
        public List<ElementalAffinity> Immunities { get; set; } = [];

        public bool Unique { get; set; }

        public Guid? LootPoolId { get; set; }
        public LootPool? LootPool { get; set; }

        public Enemy(string species, string? name = null, bool unique = false) : base(species, name, true)
        {
            Unique = unique;
        }
    }

    public sealed record ElementalAffinity(Element Element);
}
