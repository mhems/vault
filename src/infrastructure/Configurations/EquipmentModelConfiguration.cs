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
                .IsRequired()
                .HasMaxLength(64)
                .UseCollation("NOCASE");

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.SubCategory)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Manufacturer)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(e => e.Unique)
                .IsRequired();

            builder.Property(e => e.FlavorText)
                .HasMaxLength(256);
        }
    }
}
