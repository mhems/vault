using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class ShieldApi(AppDbContext db) : IShieldApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<ShieldItemDto>> GetShieldsAsync(CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => e.PlayerId == id)
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByModelAsync(Guid id, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => e.ModelId == id)
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => e.RarityId == id)
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByLootDropAsync(Guid id, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => e.DropId != null && e.DropId.Value == id)
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByElementAsync(string element, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => e.ElementalDamage != null &&
                    string.Equals(e.ElementalDamage.Element.ToString(), element, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByTypeAsync(string type, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => e.Model.SubCategory != null &&
                    string.Equals(e.Model.SubCategory, type, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetShieldsByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<ShieldItemDto> GetShieldAsync(Guid id, CancellationToken ct)
        {
            return await db.ShieldItems
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new ShieldItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Capacity,
                    e.RechargeRate,
                    e.RechargeDelay,
                    e.Prefix,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null,
                    e.ElementalImmunity,
                    e.ElementalReduction,
                    e.Battery,
                    e.Capacitor,
                    e.Body))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment item exists with ID {id}");
        }
    }
}