using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class CharacterApi(AppDbContext db) : ICharacterApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<NonPlayableCharacterDto>> GetCharactersAsync(CancellationToken ct)
        {
            return await db.Characters
              .AsNoTracking()
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
