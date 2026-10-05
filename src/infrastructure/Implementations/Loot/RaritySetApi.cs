using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class RaritySetApi(AppDbContext db) : IRaritySetApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<RaritySetDto>> GetRaritySetsAsync(CancellationToken ct)
        {
            return await db.RaritySets
              .AsNoTracking()
              .Select(r => new RaritySetDto(
                  r.Id,
                  r.Description,
                  r.ComesInWhite,
                  r.ComesInGreen,
                  r.ComesInBlue,
                  r.ComesInPurple,
                  r.ComesInLegendary,
                  r.ComesInEffervescent,
                  r.ComesInPearlescent,
                  r.ComesInSeraph,
                  r.ComesInETech))
              .ToListAsync(ct);
        }

        public async Task<RaritySetDto> GetRaritySetAsync(Guid id, CancellationToken ct)
        {
            return await db.RaritySets
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RaritySetDto(
                  r.Id,
                  r.Description,
                  r.ComesInWhite,
                  r.ComesInGreen,
                  r.ComesInBlue,
                  r.ComesInPurple,
                  r.ComesInLegendary,
                  r.ComesInEffervescent,
                  r.ComesInPearlescent,
                  r.ComesInSeraph,
                  r.ComesInETech))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such rarity set exists with ID {id}");
        }
    }
}
