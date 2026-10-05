using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class EquipmentModelApi(AppDbContext db) : IEquipmentModelApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<EquipmentModelDto>> GetEquipmentModelsAsync(CancellationToken ct)
        {
            return await db.EquipmentModels
                .AsNoTracking()
                .Select(m => new EquipmentModelDto(
                    m.Id,
                    m.Name,
                    m.Category,
                    m.SubCategory,
                    m.Manufacturer,
                    m.Dlc,
                    m.Unique,
                    m.FlavorText,
                    m.Instances.Select(i => i.Id).ToList(),
                    m.LootPools.Select(l => l.Id).ToList(),
                    m.PossibleRarities.Id,
                    (m.PossibleElements != null ? m.PossibleElements.Id : null)))
                .ToListAsync(ct);
        }

        public async Task<List<EquipmentModelDto>> GetEquipmentModelsByCategoryAsync(string category, CancellationToken ct)
        {
            return await db.EquipmentModels
                .AsNoTracking()
                .Where(m => string.Equals(m.Category.ToString(), category, StringComparison.InvariantCultureIgnoreCase))
                .Select(m => new EquipmentModelDto(
                    m.Id,
                    m.Name,
                    m.Category,
                    m.SubCategory,
                    m.Manufacturer,
                    m.Dlc,
                    m.Unique,
                    m.FlavorText,
                    m.Instances.Select(i => i.Id).ToList(),
                    m.LootPools.Select(l => l.Id).ToList(),
                    m.PossibleRarities.Id,
                    (m.PossibleElements != null ? m.PossibleElements.Id : null)))
                .ToListAsync(ct);
        }
        public async Task<List<EquipmentModelDto>> GetEquipmentModelsByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.EquipmentModels
                .AsNoTracking()
                .Where(m => string.Equals(m.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .Select(m => new EquipmentModelDto(
                    m.Id,
                    m.Name,
                    m.Category,
                    m.SubCategory,
                    m.Manufacturer,
                    m.Dlc,
                    m.Unique,
                    m.FlavorText,
                    m.Instances.Select(i => i.Id).ToList(),
                    m.LootPools.Select(l => l.Id).ToList(),
                    m.PossibleRarities.Id,
                    (m.PossibleElements != null ? m.PossibleElements.Id : null)))
                .ToListAsync(ct);
        }

        public async Task<List<EquipmentModelDto>> GetEquipmentModelsByRaritySetAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentModels
                .AsNoTracking()
                .Where(m => m.PossibleRaritiesId == id)
                .Select(m => new EquipmentModelDto(
                    m.Id,
                    m.Name,
                    m.Category,
                    m.SubCategory,
                    m.Manufacturer,
                    m.Dlc,
                    m.Unique,
                    m.FlavorText,
                    m.Instances.Select(i => i.Id).ToList(),
                    m.LootPools.Select(l => l.Id).ToList(),
                    m.PossibleRarities.Id,
                    (m.PossibleElements != null ? m.PossibleElements.Id : null)))
                .ToListAsync(ct);
        }

        public async Task<List<EquipmentModelDto>> GetEquipmentModelsByElementSetAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentModels
                .AsNoTracking()
                .Where(m => m.PossibleElementsId.HasValue && m.PossibleElementsId.Value == id)
                .Select(m => new EquipmentModelDto(
                    m.Id,
                    m.Name,
                    m.Category,
                    m.SubCategory,
                    m.Manufacturer,
                    m.Dlc,
                    m.Unique,
                    m.FlavorText,
                    m.Instances.Select(i => i.Id).ToList(),
                    m.LootPools.Select(l => l.Id).ToList(),
                    m.PossibleRarities.Id,
                    (m.PossibleElements != null ? m.PossibleElements.Id : null)))
                .ToListAsync(ct);
        }

        public async Task<EquipmentModelDto> GetEquipmentModelAsync(Guid id, CancellationToken ct)
        {
            return await db.EquipmentModels
              .AsNoTracking()
              .Where(m => m.Id == id)
              .Select(m => new EquipmentModelDto(
                  m.Id,
                  m.Name,
                  m.Category,
                  m.SubCategory,
                  m.Manufacturer,
                  m.Dlc,
                  m.Unique,
                  m.FlavorText,
                  m.Instances.Select(i => i.Id).ToList(),
                  m.LootPools.Select(l => l.Id).ToList(),
                  m.PossibleRarities.Id,
                  (m.PossibleElements != null ? m.PossibleElements.Id : null)))
              .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment model exists with ID {id}");
        }
    }
}
