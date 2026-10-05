using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class EnemyApi(AppDbContext db) : IEnemyApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<EnemyDto>> GetEnemiesAsync(CancellationToken ct)
        {
            return await db.Enemies
              .AsNoTracking()
              .Select(e => new EnemyDto(
                  e.Id,
                  e.Name,
                  e.Species,
                  e.SubSpecies,
                  e.Dlc,
                  e.Level,
                  e.Affiliation,
                  e.Locations.Select(l => l.Id).ToList(),
                  e.Prefix,
                  e.HasShield,
                  e.Unique,
                  e.Weaknesses.Select(e => e.Element).ToList(),
                  e.Resistances.Select(e => e.Element).ToList(),
                  e.Immunities.Select(e => e.Element).ToList(),
                  e.LootPoolId))
              .ToListAsync(ct);
        }

        public async Task<EnemyDto> GetEnemyAsync(Guid id, CancellationToken ct)
        {
            return await db.Enemies
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new EnemyDto(
                  e.Id,
                  e.Name,
                  e.Species,
                  e.SubSpecies,
                  e.Dlc,
                  e.Level,
                  e.Affiliation,
                  e.Locations.Select(l => l.Id).ToList(),
                  e.Prefix,
                  e.HasShield,
                  e.Unique,
                  e.Weaknesses.Select(e => e.Element).ToList(),
                  e.Resistances.Select(e => e.Element).ToList(),
                  e.Immunities.Select(e => e.Element).ToList(),
                  e.LootPoolId))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such enemy exists with ID {id}");
        }
    }
}
