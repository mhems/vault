using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class GrenadeItemConfiguration : IEntityTypeConfiguration<GrenadeItem>
    {
        public void Configure(EntityTypeBuilder<GrenadeItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.BaseItem)
                .WithMany()
                .HasForeignKey(e => e.BaseItemId)
                .IsRequired();

            builder.Property(e => e.Damage)
                .IsRequired();

            builder.Property(e => e.BlastRadius)
                .IsRequired();

            builder.Property(e => e.Fuse)
                .IsRequired();

            builder.Property(e => e.Delivery)
                .IsRequired()
                .HasMaxLength(16)
                .UseCollation("NOCASE");

            builder.Property(e => e.Sticky)
                .IsRequired();

            builder.Property(e => e.ChildCount)
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
        }
    }
}
