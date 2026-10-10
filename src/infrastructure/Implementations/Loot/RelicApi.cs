using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class RelicApi(AppDbContext db) : IRelicApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<RelicItemDto>> GetRelicsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            CancellationToken ct)
        {
            var query = db.RelicItems.AsNoTracking();

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

            if (!string.IsNullOrWhiteSpace(subcategory))
            {
                query = query.Where(m => string.Equals(m.Model.SubCategory, subcategory, StringComparison.InvariantCultureIgnoreCase));
            }

            if (manufacturer != null)
            {
                query = query.Where(m => m.Model.Manufacturer == manufacturer);
            }

            if (dlc != null)
            {
                query = query.Where(m => m.Model.Dlc == dlc);
            }

            if (minLevel != null)
            {
                query = query.Where(m => m.Level >= minLevel);
            }

            if (maxLevel != null)
            {
                query = query.Where(m => m.Level <= maxLevel);
            }

            if (unique != null)
            {
                query = query.Where(m => m.Model.Unique == unique);
            }

            if (!string.IsNullOrWhiteSpace(rarity))
            {
                query = query.Where(m => m.Rarity.Name.Equals(rarity, StringComparison.InvariantCultureIgnoreCase));
            }

            return await query
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<RelicItemDto>> GetRelicsByPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(e => e.PlayerId == id)
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<RelicItemDto>> GetRelicsByModelAsync(Guid id, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(e => e.ModelId == id)
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<RelicItemDto>> GetRelicsByRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(e => e.RarityId == id)
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<RelicItemDto>> GetRelicsByLootDropAsync(Guid id, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(e => e.DropId != null && e.DropId.Value == id)
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }



        public async Task<List<RelicItemDto>> GetRelicsByTypeAsync(string type, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(e => e.Model.SubCategory != null &&
                    string.Equals(e.Model.SubCategory, type, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<RelicItemDto>> GetRelicsByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<RelicItemDto> GetRelicAsync(Guid id, CancellationToken ct)
        {
            return await db.RelicItems
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new RelicItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment item exists with ID {id}");
        }
    }
}