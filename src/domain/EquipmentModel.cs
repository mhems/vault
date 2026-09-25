namespace Vault.Domain
{
    public class EquipmentModel(
        string name,
        string category,
        string subcategory,
        string manufacturer,
        bool unique = false,
        string? flavorText = null
        )
    {
        //private readonly List<Source> sources = [];

        public Guid Id { get; private init; } = Guid.NewGuid();

        public string Name { get; private init; } = name;
        public string Category { get; private init; } = category;
        public string SubCategory { get; private init; } = subcategory;

        public string Manufacturer { get; private init; } = manufacturer;

        public bool Unique { get; private init; } = unique;
        public string? FlavorText { get; private init; } = flavorText;

        //public IReadOnlyCollection<Source> Sources => sources.AsReadOnly();
    }
}
