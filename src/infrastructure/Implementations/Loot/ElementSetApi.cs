using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class ElementSetApi(AppDbContext db) : IElementSetApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<ElementSetDto>> GetElementSetsAsync(CancellationToken ct)
        {
            return await db.ElementSets
              .AsNoTracking()
              .Select(e => new ElementSetDto(
                  e.Id,
                  e.Description,
                  e.ComesWithoutElement,
                  e.ComesInIncendiary,
                  e.ComesInShock,
                  e.ComesInCorrosive,
                  e.ComesInSlag,
                  e.ComesInExplosive))
              .ToListAsync(ct);
        }

        public async Task<ElementSetDto> GetElementSetAsync(Guid id, CancellationToken ct)
        {
            return await db.ElementSets
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new ElementSetDto(
                  r.Id,
                  r.Description,
                  r.ComesWithoutElement,
                  r.ComesInIncendiary,
                  r.ComesInShock,
                  r.ComesInCorrosive,
                  r.ComesInSlag,
                  r.ComesInExplosive))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such element set exists with ID {id}");
        }
    }
}
