using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class LocationApi(AppDbContext db) : ILocationApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<LocationDto>> GetLocationsAsync(CancellationToken ct)
        {
            return await db.Locations
              .AsNoTracking()
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
