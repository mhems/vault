using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class GrenadeApi(AppDbContext db) : IGrenadeApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<GrenadeItemDto>> GetGrenadesAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            GrenadeDelivery? delivery,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            string? element,
            double? maxFuse,
            bool? sticky,
            CancellationToken ct)
        {
            var query = db.GrenadeItems.AsNoTracking();

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

            if (delivery != null)
            {
                var deliveryStr = delivery.ToString();
                query = query.Where(m => string.Equals(m.Model.SubCategory, deliveryStr, StringComparison.InvariantCultureIgnoreCase));
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

            if (!string.IsNullOrWhiteSpace(element))
            {
                var lookingForNonElemental = element.Equals(Element.None.ToString(), StringComparison.InvariantCultureIgnoreCase);
                query = query.Where(m =>
                    m.ElementalDamage == null
                    ? lookingForNonElemental
                    : m.ElementalDamage.Element.ToString().Equals(element, StringComparison.InvariantCultureIgnoreCase)
                );
            }

            if (maxFuse != null)
            {
                query = query.Where(m => m.Fuse <= maxFuse);
            }

            if (sticky != null)
            {
                query = query.Where(m => m.Sticky == sticky);
            }

            return await query
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