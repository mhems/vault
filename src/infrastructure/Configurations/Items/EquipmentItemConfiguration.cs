using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class EquipmentItemConfiguration : IEntityTypeConfiguration<EquipmentItem>
    {
        public void Configure(EntityTypeBuilder<EquipmentItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Model)
                .WithMany()
                .HasForeignKey(e => e.ModelId)
                .IsRequired();

            builder.Property(e => e.Level)
                .IsRequired();

            builder.HasOne(e => e.Rarity)
                .WithMany()
                .HasForeignKey(e => e.RarityId)
                .IsRequired();

            builder.Property(e => e.BuyPrice);

            builder.Property(e => e.SellPrice);

            builder.HasOne(e => e.Player)
                .WithMany(p => p.Equipment)
                .HasForeignKey(e => e.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsMany(e => e.Effects,
                effect =>
                {
                    effect.Property(e => e.Description)
                        .IsRequired()
                        .HasMaxLength(64);

                    effect.Property(e => e.Amount)
                        .IsRequired();

                    effect.Property(e => e.Units)
                        .HasMaxLength(16);
                });
        }
    }
}
