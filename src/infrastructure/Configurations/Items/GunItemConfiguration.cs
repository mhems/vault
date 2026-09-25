using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class GunItemConfiguration : IEntityTypeConfiguration<GunItem>
    {
        public void Configure(EntityTypeBuilder<GunItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.BaseItem)
                .WithMany()
                .HasForeignKey(e => e.BaseItemId)
                .IsRequired();

            builder.Property(e => e.Damage)
                .IsRequired();

            builder.Property(e => e.Accuracy)
                .IsRequired();

            builder.Property(e => e.FireRate)
                .IsRequired();

            builder.Property(e => e.ReloadSpeed)
                .IsRequired();

            builder.Property(e => e.MagazineSize)
                .IsRequired();

            builder.Property(e => e.PelletCount)
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

            builder.Property(e => e.ElementalChance);

            builder.Property(e => e.Prefix)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Barrel)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Stock)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Grip)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Scope)
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Body)
                .HasMaxLength(32)
                .UseCollation("NOCASE");
        }
    }
}
