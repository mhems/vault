using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class UniqueEnemyApi(AppDbContext db) : IUniqueEnemyApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<UniqueEnemyDto>> GetUniqueEnemiesAsync(CancellationToken ct)
        {
            return await db.UniqueEnemies
              .AsNoTracking()
              .Select(e => new UniqueEnemyDto(
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
                  e.Weaknesses.Select(e => e.Element).ToList(),
                  e.Resistances.Select(e => e.Element).ToList(),
                  e.Immunities.Select(e => e.Element).ToList(),
                  e.LootPoolId,
                  e.Boss,
                  e.RaidBoss))
              .ToListAsync(ct);
        }

        public async Task<UniqueEnemyDto> GetUniqueEnemyAsync(Guid id, CancellationToken ct)
        {
            return await db.UniqueEnemies
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new UniqueEnemyDto(
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
                  e.Weaknesses.Select(e => e.Element).ToList(),
                  e.Resistances.Select(e => e.Element).ToList(),
                  e.Immunities.Select(e => e.Element).ToList(),
                  e.LootPoolId,
                  e.Boss,
                  e.RaidBoss))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such unique enemy exists with ID {id}");
        }
    }
}
