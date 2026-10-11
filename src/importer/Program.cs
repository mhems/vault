using importer;
using Microsoft.EntityFrameworkCore;
using Vault.Domain;
using Vault.Infrastructure;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={"../../../../../data/vault.db"}")
    .EnableSensitiveDataLogging()
    .Options;

await using var db = new AppDbContext(options);

foreach (var map in CsvUtilities.ParseMaps())
{
    db.Maps.Add(new Map(map.Name, map.Dlc)
    {
        NumFastTravels = map.NumFastTravels
    });
}

foreach (var rarity in CsvUtilities.ParseRarities())
{
    var item = new Rarity(rarity.Name, rarity.Color, (rarity.Red, rarity.Green, rarity.Blue));
    Console.WriteLine($"{rarity.Name} - #{rarity.Red:X2}{rarity.Green:X2}{rarity.Blue:X2}");
    db.Rarities.Add(item);
}

return 0;

Dictionary<string, PlayerClass> classMap = [];
foreach (var playerClass in CsvUtilities.ParseClasses())
{
    var name = char.ToUpper(playerClass.Name[0]) + playerClass.Name[1..];
    var @class = new PlayerClass(name, playerClass.Dlc);
    classMap[playerClass.Name.ToLower()] = @class;
    db.PlayerClasses.Add(@class);
}

foreach (var skill in CsvUtilities.ParseSkills())
{
    if (classMap.TryGetValue(skill.Class.ToLower(), out var @class))
    {
        db.Skills.Add(new Skill(skill.Name, skill.OnePointMax, @class, skill.Tree, skill.Tier, skill.Column));
    }
    else throw new InvalidDataException($"unknown class {skill.Class.ToLower()}");
}

Dictionary<string, RaritySet> raritySetMap = [];
raritySetMap["white"] = new RaritySet(true, false, false, false, false, false, false, false, false);
raritySetMap["white+"] = new RaritySet(true, true, true, true, false, false, false, false, false);
raritySetMap["green+"] = new RaritySet(false, true, true, true, false, false, false, false, false);
raritySetMap["blue"] = new RaritySet(false, false, true, false, false, false, false, false, false);
raritySetMap["blue+"] = new RaritySet(false, false, true, true, false, false, false, false, false);
raritySetMap["purple"] = new RaritySet(false, false, false, true, false, false, false, false, false);
raritySetMap["legendary"] = new RaritySet(false, false, false, false, true, false, false, false, false);
raritySetMap["effervescent"] = new RaritySet(false, false, false, false, false, true, false, false, false);
raritySetMap["pearlescent"] = new RaritySet(false, false, false, false, false, false, true, false, false);
raritySetMap["seraph"] = new RaritySet(false, false, false, false, false, false, false, true, false);
raritySetMap["e-tech"] = new RaritySet(false, false, false, false, false, false, false, false, true);

foreach (var set in raritySetMap.Values)
{
    db.RaritySets.Add(set);
}

Dictionary<(bool, bool, bool, bool, bool, bool), ElementSet> elementSetMap = [];
elementSetMap[(true, false, false, false, false, false)] = new ElementSet(true, false, false, false, false, false); // none
elementSetMap[(false, true, false, false, false, false)] = new ElementSet(false, true, false, false, false, false); // fire
elementSetMap[(false, false, true, false, false, false)] = new ElementSet(false, false, true, false, false, false); // shock
elementSetMap[(false, false, false, true, false, false)] = new ElementSet(false, false, false, true, false, false); // corrosive
elementSetMap[(false, false, false, false, true, false)] = new ElementSet(false, false, false, false, true, false); // slag
elementSetMap[(false, false, false, false, false, true)] = new ElementSet(false, false, false, false, false, true); // explosive
elementSetMap[(false, true, true, true, false, false)] = new ElementSet(false, true, true, true, false, false); // elemental w/o slag
elementSetMap[(false, true, true, true, true, false)] = new ElementSet(false, true, true, true, true, false); // elemental
elementSetMap[(true, true, true, true, false, false)] = new ElementSet(true, true, true, true, false, false); // not slag or explosive
elementSetMap[(false, true, true, true, false, true)] = new ElementSet(false, true, true, true, false, true); // not slag or none
elementSetMap[(true, true, true, true, true, false)] = new ElementSet(true, true, true, true, true, false); // not explosive
elementSetMap[(false, true, true, true, true, true)] = new ElementSet(false, true, true, true, true, true); // any but none
elementSetMap[(true, true, true, true, true, true)] = new ElementSet(true, true, true, true, true, true); // any

foreach (var set in elementSetMap.Values)
{
    db.ElementSets.Add(set);
}

foreach (var item in CsvUtilities.ParseGuns())
{
    var elementSet = elementSetMap[(item.None, item.Incendiary, item.Shock, item.Corrosive, item.Slag, item.Explosive)];
    var raritySet = raritySetMap[item.Rarity];
    db.EquipmentModels.Add(new EquipmentModel(item.Name, Equipment.Gun, item.SubCategory.ToString(), item.Manufacturer,
        raritySet, elementSet, item.Dlc, item.Unique));
}

foreach (var item in CsvUtilities.ParseGrenades())
{
    var elementSet = elementSetMap[(item.None, item.Incendiary, item.Shock, item.Corrosive, item.Slag, item.Explosive)];
    var raritySet = raritySetMap[item.Rarity];
    db.EquipmentModels.Add(new EquipmentModel(item.Name, Equipment.Grenade, item.SubCategory.ToString(), item.Manufacturer,
        raritySet, elementSet, item.Dlc, item.Unique));
}

foreach (var item in CsvUtilities.ParseShields())
{
    var elementSet = elementSetMap[(item.None, item.Incendiary, item.Shock, item.Corrosive, item.Slag, item.Explosive)];
    var raritySet = raritySetMap[item.Rarity];
    db.EquipmentModels.Add(new EquipmentModel(item.Name, Equipment.Shield, item.SubCategory.ToString(), item.Manufacturer,
        raritySet, elementSet, item.Dlc, item.Unique));
}

foreach (var item in CsvUtilities.ParseClassMods())
{
    var raritySet = raritySetMap[item.Rarity];
    db.EquipmentModels.Add(new EquipmentModel(item.Name, Equipment.ClassMod, item.Class, item.Manufacturer,
        raritySet, null, item.Dlc));
}

foreach (var item in CsvUtilities.ParseRelics())
{
    var raritySet = raritySetMap[item.Rarity];
    db.EquipmentModels.Add(new EquipmentModel(item.Name, Equipment.Relic, item.SubCategory?.ToString() ?? string.Empty, item.Manufacturer,
        raritySet, null, item.Dlc,
        string.Equals(item.Rarity, "blue", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrWhiteSpace(item.Name)));
}

var account = new Account("matt");
db.Accounts.Add(account);

await db.SaveChangesAsync();
