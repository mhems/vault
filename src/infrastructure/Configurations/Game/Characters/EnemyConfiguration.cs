using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> builder)
        {
            builder.ToTable("Enemy");

            builder.Property(e => e.Prefix)
                .HasMaxLength(32);

            builder.Property(e => e.HasShield)
                .IsRequired();

            builder.Property(e => e.Unique)
                .IsRequired();

            builder.OwnsMany(e => e.Weaknesses,
                affinity =>
                {
                    affinity.Property(a => a.Element)
                        .IsRequired()
                        .HasConversion<string>()
                        .HasMaxLength(16);
                });


            builder.OwnsMany(e => e.Resistances,
                affinity =>
                {
                    affinity.Property(a => a.Element)
                        .IsRequired()
                        .HasConversion<string>()
                        .HasMaxLength(16);
                });


            builder.OwnsMany(e => e.Immunities,
                affinity =>
                {
                    affinity.Property(a => a.Element)
                        .IsRequired()
                        .HasConversion<string>()
                        .HasMaxLength(16);
                });

            builder.HasOne(m => m.LootPool)
                .WithMany()
                .HasForeignKey(m => m.LootPoolId);
        }
    }
}