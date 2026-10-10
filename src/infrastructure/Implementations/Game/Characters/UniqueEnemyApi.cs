using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class UniqueEnemyApi(AppDbContext db) : IUniqueEnemyApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<UniqueEnemyDto>> GetUniqueEnemiesAsync(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            bool? hasShield,
            string? weakToElement,
            string? resistsElement,
            string? immuneToElement,
            Guid? canDropModelId,
            bool? boss,
            bool? raidBoss,
            CancellationToken ct)
        {
            var query = db.UniqueEnemies.AsNoTracking();

            if (dlc != null)
            {
                query = query.Where(c => c.Dlc == dlc);
            }

            if (!string.IsNullOrWhiteSpace(species))
            {
                query = query.Where(
                    c =>
                        !string.IsNullOrWhiteSpace(c.Species) &&
                        c.Species.Equals(species, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(affiliation))
            {
                query = query.Where(
                    c =>
                        !string.IsNullOrWhiteSpace(c.Affiliation) &&
                        c.Affiliation.Equals(affiliation, StringComparison.InvariantCultureIgnoreCase));
            }

            if (spawnLocationId != null)
            {
                query = query.Where(c => c.Locations.Any(l => l.Id == spawnLocationId));
            }

            if (hasShield != null)
            {
                query = query.Where(c => c.HasShield == hasShield);
            }

            if (!string.IsNullOrWhiteSpace(weakToElement))
            {
                query = query.Where(c => c.Weaknesses.Any(w => w.Element.ToString().Equals(weakToElement, StringComparison.InvariantCultureIgnoreCase)));
            }

            if (!string.IsNullOrWhiteSpace(resistsElement))
            {
                query = query.Where(c => c.Resistances.Any(w => w.Element.ToString().Equals(resistsElement, StringComparison.InvariantCultureIgnoreCase)));
            }

            if (!string.IsNullOrWhiteSpace(immuneToElement))
            {
                query = query.Where(c => c.Immunities.Any(w => w.Element.ToString().Equals(immuneToElement, StringComparison.InvariantCultureIgnoreCase)));
            }

            if (canDropModelId != null)
            {
                query = query.Where(c => c.LootPool != null && c.LootPool.Models.Any(m => m.Id == canDropModelId));
            }

            if (boss != null)
            {
                query = query.Where(c => c.Boss == boss);
            }

            if (raidBoss != null)
            {
                query = query.Where(c => c.RaidBoss == raidBoss);
            }

            return await query
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
