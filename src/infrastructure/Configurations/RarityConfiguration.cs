
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class RarityConfiguration : IEntityTypeConfiguration<Rarity>
    {
        public void Configure(EntityTypeBuilder<Rarity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(p => p.ColorName)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(p => p.Red)
                .IsRequired();

            builder.Property(p => p.Green)
                .IsRequired();

            builder.Property(p => p.Blue)
                .IsRequired();
        }
    }
}
