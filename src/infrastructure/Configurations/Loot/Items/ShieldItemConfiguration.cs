using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class ShieldItemConfiguration : IEntityTypeConfiguration<ShieldItem>
    {
        public void Configure(EntityTypeBuilder<ShieldItem> builder)
        {
            builder.ToTable("Shield");

            builder.Property(e => e.Capacity)
                .IsRequired();

            builder.Property(e => e.RechargeRate)
                .IsRequired();

            builder.Property(e => e.RechargeDelay)
                .IsRequired();

            builder.Property(e => e.Prefix)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.ComplexProperty(e => e.ElementalDamage,
                elementalDamage =>
                {
                    elementalDamage.Property(e => e.Element)
                        .HasColumnName("Element")
                        .HasConversion<string>()
                        .HasMaxLength(16)
                        .UseCollation("NOCASE");

                    elementalDamage.Property(e => e.DamagePerSecond)
                        .HasColumnName("ElementalDamagePerSecond");
                });

            builder.Property(e => e.ElementalImmunity)
                .HasConversion<string>()
                .HasMaxLength(16)
                .UseCollation("NOCASE");

            builder.Property(e => e.ElementalReduction)
                .HasConversion<string>()
                .HasMaxLength(16)
                .UseCollation("NOCASE");

            builder.Property(e => e.Battery)
                .HasMaxLength(32)
                .HasConversion<string>()
                .UseCollation("NOCASE");

            builder.Property(e => e.Capacity)
                .HasMaxLength(32)
                .HasConversion<string>()
                .UseCollation("NOCASE");

            builder.Property(e => e.Body)
                .HasMaxLength(32)
                .HasConversion<string>()
                .UseCollation("NOCASE");
        }
    }
}
