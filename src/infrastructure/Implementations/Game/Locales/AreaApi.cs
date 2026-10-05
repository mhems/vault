using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class AreaApi(AppDbContext db) : IAreaApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<AreaDto>> GetAreasAsync(CancellationToken ct)
        {
            return await db.Areas
              .AsNoTracking()
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
