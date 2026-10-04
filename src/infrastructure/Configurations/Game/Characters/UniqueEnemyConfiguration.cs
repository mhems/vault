using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class UniqueEnemyConfiguration : IEntityTypeConfiguration<UniqueEnemy>
    {
        public void Configure(EntityTypeBuilder<UniqueEnemy> builder)
        {
            builder.ToTable("UniqueEnemy");

            builder.Property(e => e.Boss)
                .IsRequired();

            builder.Property(e => e.RaidBoss)
                .IsRequired();
        }
    }
}