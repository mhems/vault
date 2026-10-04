using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class EquipmentModelConfiguration : IEntityTypeConfiguration<EquipmentModel>
    {
        public void Configure(EntityTypeBuilder<EquipmentModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .UseCollation("NOCASE");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(32)
                .HasConversion<string>()
                .UseCollation("NOCASE");

            builder.Property(e => e.SubCategory)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Manufacturer)
                .IsRequired()
                .HasMaxLength(32)
                .HasConversion<string>()
                .UseCollation("NOCASE");

            builder.Property(l => l.Dlc)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(128);

            builder.Property(e => e.Unique)
                .IsRequired();

            builder.Property(e => e.FlavorText)
                .HasMaxLength(256);

            builder.HasMany(e => e.Instances)
                .WithOne(e => e.Model)
                .HasForeignKey(e => e.ModelId);

            builder.HasOne(e => e.PossibleElements)
                .WithMany()
                .HasForeignKey(e => e.PossibleElementsId);

            builder.HasOne(e => e.PossibleRarities)
                .WithMany()
                .HasForeignKey(e => e.PossibleRaritiesId);
        }
    }

    public sealed class RaritySetConfiguration : IEntityTypeConfiguration<RaritySet>
    {
        public void Configure(EntityTypeBuilder<RaritySet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ComesInWhite)
                .IsRequired();

            builder.Property(e => e.ComesInGreen)
                .IsRequired();

            builder.Property(e => e.ComesInBlue)
                .IsRequired();

            builder.Property(e => e.ComesInPurple)
                .IsRequired();

            builder.Property(e => e.ComesInLegendary)
                .IsRequired();

            builder.Property(e => e.ComesInEffervescent)
                .IsRequired();

            builder.Property(e => e.ComesInPearlescent)
                .IsRequired();

            builder.Property(e => e.ComesInSeraph)
                .IsRequired();

            builder.Property(e => e.ComesInETech)
                .IsRequired();
        }
    }

    public sealed class ElementSetConfiguration : IEntityTypeConfiguration<ElementSet>
    {
        public void Configure(EntityTypeBuilder<ElementSet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ComesWithoutElement)
                .IsRequired();

            builder.Property(e => e.ComesInIncendiary)
                .IsRequired();

            builder.Property(e => e.ComesInShock)
                .IsRequired();

            builder.Property(e => e.ComesInCorrosive)
                .IsRequired();

            builder.Property(e => e.ComesInSlag)
                .IsRequired();

            builder.Property(e => e.ComesInExplosive)
                .IsRequired();
        }
    }
}
