using Microsoft.EntityFrameworkCore;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerClass> PlayerClasses { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<EquipmentModel> EquipmentModels { get; set; }
        public DbSet<EquipmentItem> EquipmentItems { get; set; }
        public DbSet<GunItem> GunItems { get; set; }
        public DbSet<GrenadeItem> GrenadeItems { get; set; }
        public DbSet<ShieldItem> ShieldItems { get; set; }
        public DbSet<ClassModItem> ClassModItems { get; set; }

        public DbSet<Rarity> Rarities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
