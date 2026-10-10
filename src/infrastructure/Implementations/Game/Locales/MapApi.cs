using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class MapApi(AppDbContext db) : IMapApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<MapDto>> GetMapsAsync(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            bool? hasFastTravel,
            bool? hasMultipleConnections,
            CancellationToken ct)
        {
            var query = db.Maps.AsNoTracking();

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
                if (hasFastTravel.Value)
                {
                    query = query.Where(l => l.NumFastTravels > 0);
                }
                else
                {
                    query = query.Where(l => l.NumFastTravels == 0);
                }
            }

            if (hasMultipleConnections != null)
            {
                if (hasMultipleConnections.Value)
                {
                    query = query.Where(l => l.ConnectionsIn.Count > 1 || l.ConnectionsOut.Count > 1);
                }
                else
                {
                    query = query.Where(l => l.ConnectionsIn.Count <= 1 && l.ConnectionsOut.Count <= 1);
                }
            }

            return await query
              .Select(e => new MapDto(
                  e.Id,
                  e.Name,
                  e.Dlc,
                  e.Characters.Select(c => c.Id).ToList(),
                  e.NumFastTravels,
                  e.Areas.Select(a => a.Id).ToList(),
                  e.ConnectionsIn.Select(c => c.Id).ToList(),
                  e.ConnectionsOut.Select(c => c.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<MapDto> GetMapAsync(Guid id, CancellationToken ct)
        {
            return await db.Maps
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new MapDto(
                  e.Id,
                  e.Name,
                  e.Dlc,
                  e.Characters.Select(c => c.Id).ToList(),
                  e.NumFastTravels,
                  e.Areas.Select(a => a.Id).ToList(),
                  e.ConnectionsIn.Select(c => c.Id).ToList(),
                  e.ConnectionsOut.Select(c => c.Id).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such map exists with ID {id}");
        }
    }
}
