using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class EquipmentItemApi(AppDbContext db) : IEquipmentItemApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsAsync(CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
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

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsByPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(e => e.PlayerId == id)
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

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsByModelAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(e => e.ModelId == id)
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

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsByRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(e => e.RarityId == id)
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

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsByLootDropAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(e => e.DropId != null && e.DropId.Value == id)
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

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsByCategoryAsync(string category, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Category.ToString(), category, StringComparison.InvariantCultureIgnoreCase))
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

        public async Task<List<EquipmentItemDto>> GetEquipmentItemsByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.EquipmentItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
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