using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class ShieldItemConfiguration : IEntityTypeConfiguration<ShieldItem>
    {
        public void Configure(EntityTypeBuilder<ShieldItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.BaseItem)
                .WithMany()
                .HasForeignKey(e => e.BaseItemId)
                .IsRequired();

            builder.Property(e => e.Capacity)
                .IsRequired();

            builder.Property(e => e.RechargeRate)
                .IsRequired();

            builder.Property(e => e.RechargeDelay)
                .IsRequired();

            builder.ComplexProperty(e => e.ElementalDamage,
                elementalDamage =>
                {
                    elementalDamage.Property(e => e.Element)
                        .HasColumnName("Element")
                        .HasMaxLength(16)
                        .UseCollation("NOCASE");

                    elementalDamage.Property(e => e.DamagePerSecond)
                        .HasColumnName("ElementalDamagePerSecond");
                });

            builder.Property(e => e.Battery)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Capacity)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Body)
                .HasMaxLength(32)
                .UseCollation("NOCASE");
        }
    }
}
