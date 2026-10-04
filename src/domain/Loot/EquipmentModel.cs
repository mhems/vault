namespace Vault.Domain
{
    public class EquipmentModel(
        string? name,
        Equipment category,
        string subCategory,
        Manufacturer manufacturer,
        RaritySet raritySet,
        ElementSet? elementSet = null,
        Dlc dlc = Dlc.BaseGame,
        bool unique = false,
        string? flavorText = null
        )
    {
        public Guid Id { get; private init; } = Guid.NewGuid();

        public string? Name { get; private init; } = name;
        public Equipment Category { get; private init; } = category;
        public string SubCategory { get; private init; } = subCategory;

        public Manufacturer Manufacturer { get; private init; } = manufacturer;

        public Dlc Dlc { get; set; } = dlc;

        public bool Unique { get; private init; } = unique;

        public string? FlavorText { get; private init; } = flavorText;

        public List<EquipmentItem> Instances { get; private set; } = [];

        public List<LootPool> LootPools { get; private init; } = [];

        public Guid PossibleRaritiesId { get; private set; }
        public RaritySet PossibleRarities { get; private set; } = raritySet;

        public Guid? PossibleElementsId { get; private set; }
        public ElementSet? PossibleElements { get; private set; } = elementSet;

        private EquipmentModel() : this(string.Empty, Equipment.Gun, string.Empty, Manufacturer.Torgue, null!) { }
    }

    public class GunModel(string name, Gun gun, Manufacturer manufacturer,
        RaritySet raritySet, ElementSet elementSet,
        Dlc dlc = Dlc.BaseGame, bool unique = false, string? flavorText = null) :
        EquipmentModel(name, Equipment.Gun, gun.ToString(), manufacturer, raritySet, elementSet, dlc, unique, flavorText)
    {
        public GunModel(EquipmentModel model) :
            this(model.Name!, Enum.Parse<Gun>(model.SubCategory), model.Manufacturer,
                model.PossibleRarities, model.PossibleElements!, model.Dlc, model.Unique, model.FlavorText)
        {

        }
    }

    public class GrenadeModel(string name, Grenade grenade, Manufacturer manufacturer,
        RaritySet raritySet, ElementSet elementSet,
        Dlc dlc = Dlc.BaseGame, bool unique = false, string? flavorText = null) :
        EquipmentModel(name, Equipment.Grenade, grenade.ToString(), manufacturer, raritySet, elementSet, dlc, unique, flavorText)
    {
        public GrenadeModel(EquipmentModel model) :
            this(model.Name!, Enum.Parse<Grenade>(model.SubCategory), model.Manufacturer,
                model.PossibleRarities, model.PossibleElements!, model.Dlc, model.Unique, model.FlavorText)
        {

        }
    }

    public class ShieldModel(string name, Shield shield, Manufacturer manufacturer,
        RaritySet raritySet, ElementSet elementSet,
        Dlc dlc = Dlc.BaseGame, bool unique = false, string? flavorText = null) :
        EquipmentModel(name, Equipment.Shield, shield.ToString(), manufacturer,
            raritySet, elementSet, dlc, unique, flavorText)
    {
        public ShieldModel(EquipmentModel model) :
            this(model.Name!, Enum.Parse<Shield>(model.SubCategory), model.Manufacturer,
                model.PossibleRarities, model.PossibleElements!, model.Dlc, model.Unique, model.FlavorText)
        {

        }
    }

    public class ClassModModel(string name, string className, Manufacturer manufacturer,
        RaritySet raritySet,
        Dlc dlc = Dlc.BaseGame, bool unique = false, string? flavorText = null) :
        EquipmentModel(name, Equipment.ClassMod, className, manufacturer, raritySet, null, dlc, unique, flavorText)
    {

        public ClassModModel(string name, PlayerClass @class, Manufacturer manufacturer,
            RaritySet raritySet,
            Dlc dlc = Dlc.BaseGame, bool unique = false, string? flavorText = null) :
            this(name, @class.Name, manufacturer, raritySet, dlc, unique, flavorText)
        {

        }

        public ClassModModel(EquipmentModel model) :
            this(model.Name!, model.SubCategory, model.Manufacturer,
                model.PossibleRarities, model.Dlc, model.Unique, model.FlavorText)
        {

        }
    }

    public class RelicModel(Relic relic, Manufacturer manufacturer,
        RaritySet raritySet,
        Dlc dlc = Dlc.BaseGame, bool unique = false, string? flavorText = null) :
        EquipmentModel(null, Equipment.Relic, relic.ToString(), manufacturer, raritySet, null, dlc, unique, flavorText)
    {
        public RelicModel(EquipmentModel model) :
            this(Enum.Parse<Relic>(model.SubCategory), model.Manufacturer,
                model.PossibleRarities, model.Dlc, model.Unique, model.FlavorText)
        {

        }
    }

    public class RaritySet(bool white, bool green, bool blue, bool purple,
        bool legendary, bool effervescent, bool pearlescent, bool seraph, bool eTech)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool ComesInWhite { get; set; } = white;
        public bool ComesInGreen { get; set; } = green;
        public bool ComesInBlue { get; set; } = blue;
        public bool ComesInPurple { get; set; } = purple;
        public bool ComesInLegendary { get; set; } = legendary;
        public bool ComesInEffervescent { get; set; } = effervescent;
        public bool ComesInPearlescent { get; set; } = pearlescent;
        public bool ComesInSeraph { get; set; } = seraph;
        public bool ComesInETech { get; set; } = eTech;

        private RaritySet() : this(false, false, false, false, false, false, false, false, false) { }
    }

    public class ElementSet(bool none, bool incendiary, bool shock, bool corrosive, bool slag, bool explosive)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool ComesWithoutElement { get; set; } = none;
        public bool ComesInIncendiary { get; set; } = incendiary;
        public bool ComesInShock { get; set; } = shock;
        public bool ComesInCorrosive { get; set; } = corrosive;
        public bool ComesInSlag { get; set; } = slag;
        public bool ComesInExplosive { get; set; } = explosive;

        private ElementSet() : this(false, false, false, false, false, false) { }

    }
}
