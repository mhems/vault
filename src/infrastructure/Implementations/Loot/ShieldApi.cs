using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class ShieldApi(AppDbContext db) : IShieldApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<ShieldItemDto>> GetShieldsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Shield? category,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            string? element,
            string? prefix,
            Element? immunity,
            Element? reduction,
            Manufacturer? battery,
            Manufacturer? capacitor,
            Manufacturer? body,
            CancellationToken ct)
        {
            var query = db.ShieldItems.AsNoTracking();

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

            if (category != null)
            {
                var categoryStr = category.ToString();
                query = query.Where(m => string.Equals(m.Model.SubCategory, categoryStr, StringComparison.InvariantCultureIgnoreCase));
            }

            if (manufacturer != null)
            {
                query = query.Where(m => m.Model.Manufacturer == manufacturer);
            }

            if (dlc != null)
            {
                query = query.Where(m => m.Model.Dlc == dlc);
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

            if (!string.IsNullOrWhiteSpace(prefix))
            {
                query = query.Where(m =>
                    !string.IsNullOrWhiteSpace(m.Prefix) &&
                    m.Prefix.Equals(prefix, StringComparison.InvariantCultureIgnoreCase));
            }

            if (immunity != null)
            {
                query = query.Where(m =>
                    m.ElementalImmunity != null &&
                    m.ElementalImmunity == immunity);
            }

            if (reduction != null)
            {
                query = query.Where(m =>
                    m.ElementalReduction != null &&
                    m.ElementalReduction == reduction);
            }

            if (battery != null)
            {
                query = query.Where(m => m.Battery == battery);
            }

            if (capacitor != null)
            {
                query = query.Where(m => m.Capacitor == capacitor);
            }

            if (body != null)
            {
                query = query.Where(m => m.Body == body);
            }

            return await query
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