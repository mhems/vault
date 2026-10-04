using Microsoft.EntityFrameworkCore;
using Vault.Domain;
using Vault.Infrastructure;

//var databasePath = args[0];
//var playersCsvPath = args[1];
//var equipmentCsvPath = args[2];

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={"../../../../../data/vault.db"}")
    .EnableSensitiveDataLogging()
    .Options;

await using var db = new AppDbContext(options);

var noElements = new ElementSet(true, false, false, false, false, false);
var trioElements = new ElementSet(false, true, true, true, true, false);
var trioElementsOrNone = new ElementSet(true, true, true, true, true, false);
var onlyExplosive = new ElementSet(false, false, false, false, false, true);
var onlySlag = new ElementSet(false, false, false, false, true, false);
db.ElementSets.Add(noElements);
db.ElementSets.Add(trioElements);
db.ElementSets.Add(trioElementsOrNone);
db.ElementSets.Add(onlyExplosive);
db.ElementSets.Add(onlySlag);

var nonUnique = new RaritySet(true, true, true, true, false, false, false, false, false);
var nonUniqueGreenOrBetter = new RaritySet(false, true, true, true, false, false, false, false, false);
var onlyBlue = new RaritySet(false, false, true, false, false, false, false, false, false);
var onlyPurple = new RaritySet(false, false, false, true, false, false, false, false, false);
var onlyLegendary = new RaritySet(false, false, false, false, true, false, false, false, false);
db.RaritySets.Add(nonUnique);
db.RaritySets.Add(nonUniqueGreenOrBetter);
db.RaritySets.Add(onlyBlue);
db.RaritySets.Add(onlyPurple);
db.RaritySets.Add(onlyLegendary);

var common = new Rarity("common", "white", (255, 255, 255));
var blue = new Rarity("rare", "blue", (0, 0, 255));
var legendary = new Rarity("legendary", "gold", (255, 255, 255));
db.Rarities.Add(common);

var assassin = new PlayerClass("Assassin");
var bore = new Skill("B0re", true, assassin, "Sniper", 3, 2);
assassin.AddSkill(bore);
var soldier = new PlayerClass("Soldier");
var siren = new PlayerClass("Siren");
var gunzerker = new PlayerClass("Gunzerker");

db.PlayerClasses.Add(assassin);
db.PlayerClasses.Add(soldier);
db.PlayerClasses.Add(siren);
db.PlayerClasses.Add(gunzerker);

var account = new Account("matt");
db.Accounts.Add(account);

var zero = new Player(account, assassin, "Zer0");
zero.InvestIn(bore, 1);

var lyudaModel = new GunModel("Droog", Gun.SniperRifle, Manufacturer.Vladof, nonUnique, trioElementsOrNone);
var lyuda = new GunItem(zero, lyudaModel, 80, common, 1, 2, 3, 4, 23, 1, new ElementalDamage(Element.Incendiary, 3), 33.3, "Reliable");
zero.AddEquipment(lyuda);

var beeModel = new ShieldModel("The Bee", Shield.Amplify, Manufacturer.Hyperion, onlyLegendary, noElements);
var bee = new ShieldItem(zero, beeModel, 81, legendary, 1, 1, 1, "Inflammable");
bee.ElementalImmunity = Element.Incendiary;
zero.AddEquipment(bee);

var missileModel = new GrenadeModel("Magic Missile", Grenade.Standard, Manufacturer.Hyperion, onlyPurple, onlySlag, Dlc.TinyTinasAssaultOnDragonKeep, true);
var missile = new GrenadeItem(zero, missileModel, 41, blue, 1, 100, 0, GrenadeDelivery.Lobbed, false, 4, new ElementalDamage(Element.Slag, 0));
zero.AddEquipment(missile);

var hunterModel = new ClassModModel("Legendary Hunter", assassin, Manufacturer.Jakobs, onlyLegendary);
var hunter = new ClassModItem(zero, hunterModel, 77, legendary, assassin, string.Empty, [new SkillBoost(bore, 3)]);
zero.AddEquipment(hunter);

var relicModel = new RelicModel(Relic.Allegiance, Manufacturer.Jakobs, nonUnique);
var relic = new RelicItem(zero, relicModel, 64, blue);
zero.AddEquipment(relic);

account.AddPlayer(zero);
account.AddPlayer(new Player(account, soldier, "Axton"));
account.AddPlayer(new Player(account, siren, "Maya"));
account.AddPlayer(new Player(account, gunzerker, "Salvador"));

await db.SaveChangesAsync();
