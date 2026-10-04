using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Area");

            builder.Property(a => a.HasFastTravel);

            builder.Property(a => a.HasUTurn);

            builder.HasOne(a => a.Map)
                .WithMany(m => m.Areas)
                .HasForeignKey(a => a.MapId);

            builder.HasOne(m => m.LootPool)
                .WithMany()
                .HasForeignKey(m => m.LootPoolId);
        }
    }
}