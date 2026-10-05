using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class MissionApi(AppDbContext db) : IMissionApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<MissionDto>> GetMissionsAsync(CancellationToken ct)
        {
            return await db.Missions
              .AsNoTracking()
              .Select(e => new MissionDto(
                  e.Id,
                  e.Dlc,
                  e.StoryMission,
                  e.StartAreaId,
                  e.EndAreaId,
                  e.MissionGiverId,
                  e.MissionRewarderId,
                  e.MissionItemId,
                  e.LootPoolId,
                  e.Maps.Select(m => m.Id).ToList(),
                  e.Predecessors.Select(m => m.Id).ToList(),
                  e.Successors.Select(m => m.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<MissionDto> GetMissionAsync(Guid id, CancellationToken ct)
        {
            return await db.Missions
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new MissionDto(
                  e.Id,
                  e.Dlc,
                  e.StoryMission,
                  e.StartAreaId,
                  e.EndAreaId,
                  e.MissionGiverId,
                  e.MissionRewarderId,
                  e.MissionItemId,
                  e.LootPoolId,
                  e.Maps.Select(m => m.Id).ToList(),
                  e.Predecessors.Select(m => m.Id).ToList(),
                  e.Successors.Select(m => m.Id).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such mission exists with ID {id}");
        }
    }
}
