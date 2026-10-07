using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class ClassModApi(AppDbContext db) : IClassModApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<ClassModItemDto>> GetClassModsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            string? @class,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            Guid? skillId,
            CancellationToken ct)
        {
            var query = db.ClassModItems.AsNoTracking();

            if (playerId != null)
            {
                query = query.Where(i => i.PlayerId == playerId);
            }

            if (modelId != null)
            {
                query = query.Where(i => i.ModelId == modelId);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(
                    m => string.Equals(m.Model.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }


            if (!string.IsNullOrWhiteSpace(@class))
            {
                query = query.Where(m => string.Equals(m.Model.SubCategory, @class, StringComparison.InvariantCultureIgnoreCase));
            }

            if (manufacturer != null)
            {
                query = query.Where(m => m.Model.Manufacturer == manufacturer);
            }

            if (dlc != null)
            {
                query = query.Where(m => m.Model.Dlc == dlc);
            }

            if (unique != null)
            {
                query = query.Where(m => m.Model.Unique == unique);
            }

            if (!string.IsNullOrWhiteSpace(rarity))
            {
                query = query.Where(m => m.Rarity.Name.Equals(rarity, StringComparison.InvariantCultureIgnoreCase));
            }

            if (skillId != null)
            {
                query = query.Where(m => m.Boosts.Any(b => b.SkillId == skillId));
            }

            return await query
                .Select(e => new ClassModItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Prefix,
                    e.Boosts.Select(b => new SkillBoostDto(b.SkillId, b.Amount)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<ClassModItemDto> GetClassModAsync(Guid id, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new ClassModItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Prefix,
                    e.Boosts.Select(b => new SkillBoostDto(b.SkillId, b.Amount)).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment item exists with ID {id}");
        }
    }
}