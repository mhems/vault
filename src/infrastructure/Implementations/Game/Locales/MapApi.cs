using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class MapApi(AppDbContext db) : IMapApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<MapDto>> GetMapsAsync(CancellationToken ct)
        {
            return await db.Maps
              .AsNoTracking()
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
