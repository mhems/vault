using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.UseTptMappingStrategy();

            builder.ToTable("Location");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(l => l.Dlc)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(128);
        }
    }
}