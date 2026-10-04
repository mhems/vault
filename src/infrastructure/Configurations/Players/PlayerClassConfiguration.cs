using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class PlayerClassConfiguration : IEntityTypeConfiguration<PlayerClass>
    {
        public void Configure(EntityTypeBuilder<PlayerClass> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
              .IsRequired()
              .HasMaxLength(32)
              .UseCollation("NOCASE");

            builder.Property(p => p.Dlc)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(128);
        }
    }
}
