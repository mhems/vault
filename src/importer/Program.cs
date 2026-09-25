using Microsoft.EntityFrameworkCore;
using Vault.Domain;
using Vault.Infrastructure;

//var databasePath = args[0];
//var playersCsvPath = args[1];
//var equipmentCsvPath = args[2];

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={"../../../../../data/vault.db"}")
    .Options;

await using var db = new AppDbContext(options);

var assassin = new PlayerClass("Assassin");
var soldier = new PlayerClass("Soldier");
var siren = new PlayerClass("Siren");
var gunzerker = new PlayerClass("Gunzerker");

db.PlayerClasses.Add(assassin);
db.PlayerClasses.Add(soldier);
db.PlayerClasses.Add(siren);
db.PlayerClasses.Add(gunzerker);

db.Players.Add(new Player(assassin, "Zer0"));
db.Players.Add(new Player(soldier, "Axton"));
db.Players.Add(new Player(siren, "Maya"));
db.Players.Add(new Player(gunzerker, "Salvador"));

db.Rarities.Add(new Rarity("common", "white", (255, 255, 255)));

await db.SaveChangesAsync();
