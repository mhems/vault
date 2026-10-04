using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class MapConfiguration : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.ToTable("Map");

            builder.Property(m => m.NumFastTravels);

            builder.HasMany(m => m.ConnectionsIn)
                .WithMany(m => m.ConnectionsOut);
        }
    }
}