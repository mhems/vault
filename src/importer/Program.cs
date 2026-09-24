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

// Read CSV...
// Construct domain objects...
// db.Players.Add(...);

db.Players.Add(new Player("Assassin", "Zer0"));
db.Players.Add(new Player("Soldier", "Axton"));
db.Players.Add(new Player("Siren", "Maya"));
db.Players.Add(new Player("Gunzerker", "Salvador"));

await db.SaveChangesAsync();
