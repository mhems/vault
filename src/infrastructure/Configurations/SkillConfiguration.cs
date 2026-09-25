using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
              .IsRequired()
              .HasMaxLength(32)
              .UseCollation("NOCASE");

            builder.Property(s => s.OnePointMax)
                .IsRequired();

            builder.HasOne(s => s.Class)
                .WithMany()
                .HasForeignKey(s => s.PlayerClassId)
                .IsRequired();

            builder.Property(s => s.Tree)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(s => s.Tier)
                .IsRequired();

            builder.Property(s => s.Column)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(256);
        }
    }
}
