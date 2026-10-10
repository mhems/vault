using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class EquipmentModelApi(AppDbContext db) : IEquipmentModelApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<EquipmentModelDto>> GetEquipmentModelsAsync(
            string? name,
            Equipment? category,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            Guid? raritySetId,
            Guid? elementSetId,
            string? canHaveRarity,
            string? canHaveElement,
            CancellationToken ct)
        {
            var query = db.EquipmentModels.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(
                    m => !string.IsNullOrWhiteSpace(m.Name) &&
                          string.Equals(m.Name, name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (category != null)
            {
                query = query.Where(m => m.Category == category);
            }

            if (!string.IsNullOrWhiteSpace(subcategory))
            {
                query = query.Where(m => string.Equals(m.SubCategory, subcategory, StringComparison.InvariantCultureIgnoreCase));
            }

            if (manufacturer != null)
            {
                query = query.Where(m => m.Manufacturer == manufacturer);
            }

            if (dlc != null)
            {
                query = query.Where(m => m.Dlc == dlc);
            }

            if (unique != null)
            {
                query = query.Where(m => m.Unique == unique);
            }

            if (raritySetId != null)
            {
                query = query.Where(m => m.PossibleRaritiesId == raritySetId);
            }

            if (elementSetId != null)
            {
                query = query.Where(
                    m => m.PossibleElementsId != null &&
                         m.PossibleElementsId == elementSetId);
            }

            if (!string.IsNullOrWhiteSpace(canHaveRarity))
            {
                query = canHaveRarity.ToLower() switch
                {
                    "white" => query.Where(m => m.PossibleRarities.ComesInWhite),
                    "green" => query.Where(m => m.PossibleRarities.ComesInGreen),
                    "blue" => query.Where(m => m.PossibleRarities.ComesInBlue),
                    "purple" => query.Where(m => m.PossibleRarities.ComesInPurple),
                    "legendary" => query.Where(m => m.PossibleRarities.ComesInLegendary),
                    "e-tech" or "etech" => query.Where(m => m.PossibleRarities.ComesInETech),
                    "effervescent" => query.Where(m => m.PossibleRarities.ComesInEffervescent),
                    "pearlescent" => query.Where(m => m.PossibleRarities.ComesInPearlescent),
                    "seraph" => query.Where(m => m.PossibleRarities.ComesInSeraph),
                    _ => throw new ArgumentException($"unknown rarity {canHaveRarity}")
                };
            }

            if (!string.IsNullOrWhiteSpace(canHaveElement))
            {
                query = canHaveElement.ToLower() switch
                {
                    "none" => query.Where(m => m.PossibleElements != null && m.PossibleElements.ComesWithoutElement),
                    "incendiary" or "fire" => query.Where(m => m.PossibleElements != null && m.PossibleElements.ComesInIncendiary),
                    "shock" or "electricty" => query.Where(m => m.PossibleElements != null && m.PossibleElements.ComesInShock),
                    "corrosive" or "acid" => query.Where(m => m.PossibleElements != null && m.PossibleElements.ComesInCorrosive),
                    "slag" => query.Where(m => m.PossibleElements != null && m.PossibleElements.ComesInSlag),
                    "explosive" => query.Where(m => m.PossibleElements != null && m.PossibleElements.ComesInExplosive),
                    _ => throw new ArgumentException($"unknown element {canHaveElement}")
                };
            }

            return await query
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
