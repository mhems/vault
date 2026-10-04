using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class ClassModItemConfiguration : IEntityTypeConfiguration<ClassModItem>
    {
        public void Configure(EntityTypeBuilder<ClassModItem> builder)
        {
            builder.ToTable("ClassMod");

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
                    boost.Property<Guid>("Id");

                    boost.HasKey("Id");

                    boost.WithOwner()
                        .HasForeignKey("ClassModItemId");

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
