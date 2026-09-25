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

            builder.HasOne(p => p.Class)
                .WithMany()
                .HasForeignKey(p => p.PlayerClassId);

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

            builder.OwnsMany(p => p.SkillTree,
                element =>
                {
                    element.HasOne(e => e.Skill)
                        .WithMany()
                        .HasForeignKey(e => e.SkillId)
                        .IsRequired();

                    element.Property(e => e.Amount)
                        .IsRequired();
                });
        }
    }
}
