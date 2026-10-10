using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class LocationApi(AppDbContext db) : ILocationApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<LocationDto>> GetLocationsAsync(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            CancellationToken ct)
        {
            var query = db.Locations.AsNoTracking();

            if (dlc != null)
            {
                query = query.Where(l => l.Dlc == dlc);
            }

            if (canSpawnCharacterId != null)
            {
                query = query.Where(l => l.Characters.Any(c => c.Id == canSpawnCharacterId));
            }

            return await query
              .Select(e => new LocationDto(
                  e.Id,
                  e.Name,
                  e.Dlc,
                  e.Characters.Select(c => c.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<LocationDto> GetLocationAsync(Guid id, CancellationToken ct)
        {
            return await db.Locations
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new LocationDto(
                  e.Id,
                  e.Name,
                  e.Dlc,
                  e.Characters.Select(c => c.Id).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such location exists with ID {id}");
        }
    }
}
