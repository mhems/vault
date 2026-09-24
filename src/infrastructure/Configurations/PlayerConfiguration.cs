using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Class)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(p => p.Level)
                .IsRequired();

            builder.Property(p => p.Experience)
                .IsRequired();

            builder.Property(p => p.Money)
                .IsRequired();

            builder.HasMany(p => p.Equipment)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.Id);
        }
    }
}
