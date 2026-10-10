using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class EquipmentItemApi(AppDbContext db) : IEquipmentItemApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Equipment? category,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            CancellationToken ct)
        {
            var query = db.EquipmentItems.AsNoTracking();

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
                    m => !string.IsNullOrWhiteSpace(m.Model.Name) &&
                          string.Equals(m.Model.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (category != null)
            {
                query = query.Where(m => m.Model.Category == category);
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
                .Select(e => new EquipmentItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()
                    ))
                .ToListAsync(ct);
        }

        public async Task<EquipmentItemDto> GetEquipmentItemAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new EquipmentItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()
                    ))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment item exists with ID {id}");
        }
    }
}