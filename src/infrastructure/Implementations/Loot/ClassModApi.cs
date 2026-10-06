using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class ClassModApi(AppDbContext db) : IClassModApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<ClassModItemDto>> GetClassModsAsync(CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Select(e => new ClassModItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    (int?)e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Prefix,
                    e.Boosts.Select(b => new SkillBoostDto(b.SkillId, b.Amount)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<ClassModItemDto>> GetClassModsByPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(e => e.PlayerId == id)
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

        public async Task<List<ClassModItemDto>> GetClassModsByModelAsync(Guid id, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(e => e.ModelId == id)
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

        public async Task<List<ClassModItemDto>> GetClassModsByRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(e => e.RarityId == id)
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

        public async Task<List<ClassModItemDto>> GetClassModsByLootDropAsync(Guid id, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(e => e.DropId != null && e.DropId.Value == id)
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



        public async Task<List<ClassModItemDto>> GetClassModsByClassAsync(string @class, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(e => e.Class.Name != null &&
                    string.Equals(e.Class.Name, @class, StringComparison.InvariantCultureIgnoreCase))
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

        public async Task<List<ClassModItemDto>> GetClassModsByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.ClassModItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
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