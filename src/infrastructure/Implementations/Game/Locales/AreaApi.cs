using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class AreaApi(AppDbContext db) : IAreaApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<AreaDto>> GetAreasAsync(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            bool? hasFastTravel,
            bool? hasUTurn,
            Guid? mapId,
            CancellationToken ct)
        {
            var query = db.Areas.AsNoTracking();

            if (dlc != null)
            {
                query = query.Where(l => l.Dlc == dlc);
            }

            if (canSpawnCharacterId != null)
            {
                query = query.Where(l => l.Characters.Any(c => c.Id == canSpawnCharacterId));
            }

            if (hasFastTravel != null)
            {
                query = query.Where(l => l.HasFastTravel == hasFastTravel);
            }

            if (hasUTurn != null)
            {
                query = query.Where(l => l.HasUTurn == hasUTurn);
            }

            if (mapId != null)
            {
                query = query.Where(l => l.MapId == mapId);
            }

            return await query
              .Select(e => new AreaDto(
                  e.Id,
                  e.Name,
                  e.Dlc,
                  e.Characters.Select(c => c.Id).ToList(),
                  e.HasFastTravel,
                  e.HasUTurn,
                  e.MapId))
              .ToListAsync(ct);
        }

        public async Task<AreaDto> GetAreaAsync(Guid id, CancellationToken ct)
        {
            return await db.Areas
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new AreaDto(
                  e.Id,
                  e.Name,
                  e.Dlc,
                  e.Characters.Select(c => c.Id).ToList(),
                  e.HasFastTravel,
                  e.HasUTurn,
                  e.MapId))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such area exists with ID {id}");
        }
    }
}
