using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public class GunApi(AppDbContext db) : IGunApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<GunItemDto>> GetGunsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Gun? category,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            string? element,
            string? prefix,
            bool? missionItem,
            Manufacturer? barrel,
            Manufacturer? stock,
            Manufacturer? grip,
            Manufacturer? scope,
            Manufacturer? body,
            CancellationToken ct)
        {
            var query = db.GunItems.AsNoTracking();

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

            if (missionItem != null)
            {
                query = query.Where(m => m.MissionItem == missionItem);
            }

            if (barrel != null)
            {
                query = query.Where(m => m.Barrel == barrel);
            }

            if (stock != null)
            {
                query = query.Where(m => m.Stock == stock);
            }

            if (grip != null)
            {
                query = query.Where(m => m.Grip == grip);
            }

            if (scope != null)
            {
                query = query.Where(m => m.Scope == scope);
            }

            if (body != null)
            {
                query = query.Where(m => m.Body == body);
            }

            return await query
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