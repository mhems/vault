using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class CharacterApi(AppDbContext db) : ICharacterApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<NonPlayableCharacterDto>> GetCharactersAsync(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            CancellationToken ct)
        {
            var query = db.Characters.AsNoTracking();

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

            return await query
              .Select(e => new NonPlayableCharacterDto(
                  e.Id,
                  e.Name,
                  e.Species,
                  e.SubSpecies,
                  e.Dlc,
                  e.Level,
                  e.Affiliation,
                  e.Enemy,
                  e.Locations.Select(l => l.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<NonPlayableCharacterDto> GetCharacterAsync(Guid id, CancellationToken ct)
        {
            return await db.Characters
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new NonPlayableCharacterDto(
                  e.Id,
                  e.Name,
                  e.Species,
                  e.SubSpecies,
                  e.Dlc,
                  e.Level,
                  e.Affiliation,
                  e.Enemy,
                  e.Locations.Select(l => l.Id).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such character exists with ID {id}");
        }
    }
}
