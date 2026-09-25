using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class ClassModItemConfiguration : IEntityTypeConfiguration<ClassModItem>
    {
        public void Configure(EntityTypeBuilder<ClassModItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.BaseItem)
                .WithMany()
                .HasForeignKey(e => e.BaseItemId)
                .IsRequired();

            builder.HasOne(e => e.Class)
                .WithMany()
                .HasForeignKey(e => e.PlayerClassId)
                .IsRequired();

            builder.Property(e => e.Prefix)
                .IsRequired()
                .HasMaxLength(32)
                .UseCollation("NOCASE");

            builder.OwnsMany(e => e.Boosts,
                boost =>
                {
                    boost.HasOne(b => b.Skill)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .IsRequired();

                    boost.Property(e => e.Amount)
                        .IsRequired();
                });
        }
    }
}
