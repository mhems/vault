using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class RarityApi(AppDbContext db) : IRarityApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<RarityDto>> GetRaritiesAsync(CancellationToken ct)
        {
            return await db.Rarities
              .AsNoTracking()
              .Select(r => new RarityDto(
                  r.Id,
                  r.Name,
                  r.ColorName,
                  r.Color))
              .ToListAsync(ct);
        }

        public async Task<RarityDto> GetRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.Rarities
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RarityDto(
                  r.Id,
                  r.Name,
                  r.ColorName,
                  r.Color))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such rarity exists with ID {id}");
        }
    }
}
