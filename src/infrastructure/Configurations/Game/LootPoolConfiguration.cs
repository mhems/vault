using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class LootPoolConfiguration : IEntityTypeConfiguration<LootPool>
    {
        public void Configure(EntityTypeBuilder<LootPool> builder)
        {
            builder.HasKey(lp => lp.Id);

            builder.HasMany(lp => lp.Models)
                .WithMany(m => m.LootPools);
        }
    }
}