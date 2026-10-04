using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class NonPlayableCharacterConfiguration : IEntityTypeConfiguration<NonPlayableCharacter>
    {
        public void Configure(EntityTypeBuilder<NonPlayableCharacter> builder)
        {
            builder.UseTptMappingStrategy();

            builder.ToTable("NonPlayableCharacters");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(64);

            builder.Property(l => l.Dlc)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(128);

            builder.Property(c => c.Level);

            builder.Property(c => c.Species)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(c => c.SubSpecies)
                .HasMaxLength(32);

            builder.Property(c => c.Affiliation)
                .HasMaxLength(64);

            builder.Property(c => c.Enemy);

            builder.HasMany(c => c.Locations)
                .WithMany(l => l.Characters);
        }
    }
}