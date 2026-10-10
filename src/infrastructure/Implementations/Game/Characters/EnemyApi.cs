using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class EnemyApi(AppDbContext db) : IEnemyApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<EnemyDto>> GetEnemiesAsync(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            bool? hasShield,
            string? weakToElement,
            string? resistsElement,
            string? immuneToElement,
            Guid? canDropModelId,
            CancellationToken ct)
        {
            var query = db.Enemies.AsNoTracking();

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

            return await query
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
