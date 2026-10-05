using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class MissionConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(m => m.Dlc)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(128);

            builder.Property(m => m.StoryMission)
                .IsRequired();

            builder.HasOne(m => m.StartArea)
                .WithMany()
                .HasForeignKey(m => m.StartAreaId)
                .IsRequired();

            builder.HasOne(m => m.EndArea)
                .WithMany()
                .HasForeignKey(m => m.EndAreaId)
                .IsRequired();

            builder.HasOne(m => m.MissionGiver)
                .WithMany()
                .HasForeignKey(m => m.MissionGiverId);

            builder.HasOne(m => m.MissionRewarder)
                .WithMany()
                .HasForeignKey(m => m.MissionRewarderId);

            builder.HasOne(m => m.MissionItem)
                .WithMany()
                .HasForeignKey(m => m.MissionItemId);

            builder.HasMany(m => m.Maps)
                .WithMany();

            builder.HasMany(m => m.Predecessors)
                .WithMany(m => m.Successors);

            builder.HasOne(m => m.LootPool)
                .WithMany()
                .HasForeignKey(m => m.LootPoolId);
        }
    }
}