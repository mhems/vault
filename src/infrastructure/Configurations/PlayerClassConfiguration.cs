using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure.Configurations
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

            builder.HasMany(p => p.Skills)
                .WithOne()
                .HasForeignKey(p => p.Id);
        }
    }
}
