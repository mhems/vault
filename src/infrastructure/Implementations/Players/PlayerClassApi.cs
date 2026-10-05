using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class PlayerClassApi(AppDbContext db) : IPlayerClassApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<PlayerClassDto>> GetPlayerClassesAsync(CancellationToken ct)
        {
            return await db.PlayerClasses
              .AsNoTracking()
              .Select(p => new PlayerClassDto(
                  p.Id,
                  p.Dlc,
                  p.Name,
                  p.Skills.Select(s => s.Id).ToList(),
                  p.Players.Select(p => p.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<PlayerClassDto> GetPlayerClassAsync(Guid id, CancellationToken ct)
        {
            return await db.PlayerClasses
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new PlayerClassDto(
                    p.Id,
                    p.Dlc,
                    p.Name,
                    p.Skills.Select(s => s.Id).ToList(),
                    p.Players.Select(p => p.Id).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such player class exists with ID {id}");
        }
    }
}
