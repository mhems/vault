using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class LootPoolApi(AppDbContext db) : ILootPoolApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<LootPoolDto>> GetLootPoolsAsync(Guid? modelId, CancellationToken ct)
        {
            var query = db.LootPools.AsNoTracking();

            if (modelId != null)
            {
                query = query.Where(e => e.Models.Any(m => m.Id == modelId));
            }

            return await query
              .Select(e => new LootPoolDto(
                  e.Id,
                  e.Models.Select(m => m.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<LootPoolDto> GetLootPoolAsync(Guid id, CancellationToken ct)
        {
            return await db.LootPools
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new LootPoolDto(
                  e.Id,
                  e.Models.Select(m => m.Id).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such loot pool exists with ID {id}");
        }
    }
}
