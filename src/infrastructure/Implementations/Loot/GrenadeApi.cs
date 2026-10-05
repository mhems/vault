using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class GrenadeApi(AppDbContext db) : IGrenadeApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<GrenadeItemDto>> GetGrenadesAsync(CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => e.PlayerId == id)
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByModelAsync(Guid id, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => e.ModelId == id)
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByRarityAsync(Guid id, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => e.RarityId == id)
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByLootDropAsync(Guid id, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => e.DropId != null && e.DropId.Value == id)
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByElementAsync(string element, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => e.ElementalDamage != null &&
                    string.Equals(e.ElementalDamage.Element.ToString(), element, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByDeliveryAsync(string delivery, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => e.Model.SubCategory != null &&
                    string.Equals(e.Model.SubCategory, delivery, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetGrenadesByManufacturerAsync(string manufacturer, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(e => string.Equals(e.Model.Manufacturer.ToString(), manufacturer, StringComparison.InvariantCultureIgnoreCase))
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .ToListAsync(ct);
        }

        public async Task<GrenadeItemDto> GetGrenadeAsync(Guid id, CancellationToken ct)
        {
            return await db.GrenadeItems
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(e => new GrenadeItemDto(
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
                    e.BlastRadius,
                    e.Fuse,
                    e.Delivery,
                    e.Sticky,
                    e.ChildCount,
                    e.ElementalDamage != null
                        ? new ElementalDamageDto(e.ElementalDamage.Element, e.ElementalDamage.DamagePerSecond)
                        : null))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such equipment item exists with ID {id}");
        }
    }
}