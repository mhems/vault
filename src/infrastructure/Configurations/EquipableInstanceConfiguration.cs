using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class EquipableInstanceConfiguration : IEntityTypeConfiguration<EquipableInstance>
    {
        public void Configure(EntityTypeBuilder<EquipableInstance> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(128)
                .UseCollation("NOCASE");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Manufacturer)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Level)
                .IsRequired();

            builder.Property(e => e.Unique)
                .IsRequired();

            builder.Property(e => e.BuyPrice);

            builder.Property(e => e.SellPrice);

            builder.Property(e => e.FlavorText)
                .HasMaxLength(256)
                .UseCollation("NOCASE");

            builder.HasOne(e => e.Player)
                .WithMany(p => p.Equipment)
                .HasForeignKey(e => e.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
