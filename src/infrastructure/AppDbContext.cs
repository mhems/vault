using Microsoft.EntityFrameworkCore;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        #region user-related
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerClass> PlayerClasses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        #endregion

        #region loot-related
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<EquipmentModel> EquipmentModels { get; set; }
        public DbSet<RaritySet> RaritySets { get; set; }
        public DbSet<ElementSet> ElementSets { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<GunItem> GunItems { get; set; }
        public DbSet<GrenadeItem> GrenadeItems { get; set; }
        public DbSet<ShieldItem> ShieldItems { get; set; }
        public DbSet<ClassModItem> ClassModItems { get; set; }
        public DbSet<RelicItem> RelicItems { get; set; }
        #endregion

        #region game-related
        public DbSet<Location> Locations { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Map> Maps { get; set; }

        public DbSet<NonPlayableCharacter> Characters { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<UniqueEnemy> UniqueEnemies { get; set; }

        public DbSet<Mission> Missions { get; set; }

        public DbSet<LootPool> LootPools { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
