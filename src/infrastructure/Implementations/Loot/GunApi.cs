using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class GunApi(AppDbContext db) : IGunApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<GunItemDto>> GetGunsAsync(CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => e.PlayerId == id)
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByModelAsync(Guid id, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => e.ModelId == id)
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => e.RarityId == id)
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByLootDropAsync(Guid id, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => e.DropId != null && e.DropId.Value == id)
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByElementAsync(string element, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => e.ElementalDamage != null &&
                    string.Equals(e.ElementalDamage.Element.ToString(), element, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByTypeAsync(string type, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => e.Model.SubCategory != null &&
                    string.Equals(e.Model.SubCategory, type, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetGunsByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .ToListAsync(ct);
        }

        public async Task<GunItemDto> GetGunAsync(Guid id, CancellationToken ct)
        {
            return await db.GunItems
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new GunItemDto(
                    e.Id,
                    e.PlayerId,
                    e.ModelId,
                    e.RarityId,
                    e.Drop != null ? new LootDropDto(e.Drop) : null,
                    e.Level,
                    (int?)e.BuyPrice,
                    (int?)e.SellPrice,
                    e.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                    e.Damage,
                    e.Accuracy,
                    e.FireRate,
                    e.ReloadSpeed,
                    e.MagazineSize,
                    e.PelletCount,
                    (e.ElementalDamage != null && e.ElementalChance.HasValue)
                        ? new ElementalDamageChanceDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond, e.ElementalChance.Value)
                        : null,
                    e.Prefix,
                    e.MissionItem,
                    e.Barrel,
                    e.Stock,
                    e.Grip,
                    e.Scope,
                    e.Body))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment item exists with ID {id}");
        }
    }
}