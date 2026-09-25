using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class PlayerQueries(AppDbContext db) : IPlayerQueries
    {
        private readonly AppDbContext db = db;

        public Task<List<PlayerDto>> GetPlayersAsync(CancellationToken ct)
        {
            return db.Players
                .Select(player => ToDto(player))
                .ToListAsync(ct);
        }

        public Task<List<PlayerDto>> GetPlayersByClassAsync(string @class, CancellationToken ct)
        {
            return db.Players
                .Where(player => player.Class.Name == @class)
                .Select(player => ToDto(player))
                .ToListAsync(ct);
        }

        private static PlayerDto ToDto(Player player)
        {
            return new PlayerDto(
                    player.Id,
                    player.Class.Name,
                    player.Name,
                    player.Level,
                    (int?)player.Experience,
                    (int?)player.Money);
        }
    }
}
