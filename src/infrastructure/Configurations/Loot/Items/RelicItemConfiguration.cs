using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class RelicItemConfiguration : IEntityTypeConfiguration<RelicItem>
    {
        public void Configure(EntityTypeBuilder<RelicItem> builder)
        {
            builder.ToTable("Relic");
        }
    }
}
