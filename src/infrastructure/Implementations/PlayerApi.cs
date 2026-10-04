using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class PlayerApi(AppDbContext db) : IPlayerApi
    {
        private readonly AppDbContext db = db;

        #region queries
        public async Task<PlayerDto> GetPlayerAsync(Guid id, CancellationToken ct)
        {
            return await db.Players
                .Where(player => player.Id == id)
                .Select(player => new PlayerDto(
                    player.Id,
                    player.AccountId,
                    player.PlayerClassId,
                    player.Name,
                    player.Level,
                    (int?)player.Experience,
                    (int?)player.Money,
                    player.Equipment.Select(e => e.Id).ToList(),
                    player.SkillTree.Select(s => new PlayerSkillDto(s.SkillId, s.Amount)).ToList()))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");
        }

        public async Task<List<PlayerDto>> GetPlayersAsync(CancellationToken ct)
        {
            return await db.Players
                .Select(player => new PlayerDto(
                    player.Id,
                    player.AccountId,
                    player.PlayerClassId,
                    player.Name,
                    player.Level,
                    (int?)player.Experience,
                    (int?)player.Money,
                    player.Equipment.Select(e => e.Id).ToList(),
                    player.SkillTree.Select(s => new PlayerSkillDto(s.SkillId, s.Amount)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<PlayerDto>> GetPlayersByClassAsync(string @class, CancellationToken ct)
        {
            return await db.Players
                .Where(player => player.Class.Name == @class)
                .Select(player => new PlayerDto(
                    player.Id,
                    player.AccountId,
                    player.PlayerClassId,
                    player.Name,
                    player.Level,
                    (int?)player.Experience,
                    (int?)player.Money,
                    player.Equipment.Select(e => e.Id).ToList(),
                    player.SkillTree.Select(s => new PlayerSkillDto(s.SkillId, s.Amount)).ToList()))
                .ToListAsync(ct);
        }

        public async Task<List<EquipmentItemDto>> GetPlayerItemsAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return await db.EquipmentItems
                    .Where(i => i.PlayerId == id)
                    .Select(i => new EquipmentItemDto(
                        i.Id,
                        i.PlayerId,
                        i.ModelId,
                        i.RarityId,
                        i.DropId,
                        i.Level,
                        (int?)i.BuyPrice,
                        (int?)i.SellPrice,
                        i.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                    .ToListAsync(ct);
        }

        public async Task<List<GunItemDto>> GetPlayerGunsAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return await db.GunItems
                    .Where(i => i.PlayerId == id)
                    .Select(i => new GunItemDto(
                        i.Id,
                        i.PlayerId,
                        i.ModelId,
                        i.RarityId,
                        i.DropId,
                        i.Level,
                        (int?)i.BuyPrice,
                        (int?)i.SellPrice,
                        i.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                        i.Damage,
                        i.Accuracy,
                        i.FireRate,
                        i.ReloadSpeed,
                        i.MagazineSize,
                        i.PelletCount,
                        (i.ElementalDamage != null && i.ElementalChance.HasValue)
                          ? new ElementalDamageChanceDto(i.ElementalDamage.Element,
                                                         i.ElementalDamage.DamagePerSecond,
                                                         i.ElementalChance.Value)
                          : null,
                        i.Prefix,
                        i.MissionItem,
                        i.Barrel,
                        i.Stock,
                        i.Grip,
                        i.Scope,
                        i.Body))
                    .ToListAsync(ct);
        }

        public async Task<List<GrenadeItemDto>> GetPlayerGrenadesAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return await db.GrenadeItems
                    .Where(i => i.PlayerId == id)
                    .Select(i => new GrenadeItemDto(
                        i.Id,
                        i.PlayerId,
                        i.ModelId,
                        i.RarityId,
                        i.DropId,
                        i.Level,
                        (int?)i.BuyPrice,
                        (int?)i.SellPrice,
                        i.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                        i.Damage,
                        i.BlastRadius,
                        i.Fuse,
                        i.Delivery,
                        i.Sticky,
                        i.ChildCount,
                        i.ElementalDamage != null
                          ? new ElementalDamageDto(i.ElementalDamage.Element,
                                                   i.ElementalDamage.DamagePerSecond)
                          : null))
                    .ToListAsync(ct);
        }

        public async Task<List<ShieldItemDto>> GetPlayerShieldsAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return await db.ShieldItems
                    .Where(i => i.PlayerId == id)
                    .Select(i => new ShieldItemDto(
                        i.Id,
                        i.PlayerId,
                        i.ModelId,
                        i.RarityId,
                        i.DropId,
                        i.Level,
                        (int?)i.BuyPrice,
                        (int?)i.SellPrice,
                        i.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                        i.Capacity,
                        i.RechargeRate,
                        i.RechargeDelay,
                        i.Prefix,
                        i.ElementalDamage != null
                          ? new ElementalDamageDto(i.ElementalDamage.Element,
                                                   i.ElementalDamage.DamagePerSecond)
                          : null,
                        i.ElementalImmunity,
                        i.ElementalReduction,
                        i.Battery,
                        i.Capacitor,
                        i.Body))
                    .ToListAsync(ct);
        }

        public async Task<List<ClassModItemDto>> GetPlayerClassModsAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return await db.ClassModItems
                    .Where(i => i.PlayerId == id)
                    .Select(i => new ClassModItemDto(
                        i.Id,
                        i.PlayerId,
                        i.ModelId,
                        i.RarityId,
                        i.DropId,
                        i.Level,
                        (int?)i.BuyPrice,
                        (int?)i.SellPrice,
                        i.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                        i.Prefix,
                        i.Boosts.Select(b => new SkillBoostDto(b.SkillId, b.Amount)).ToList()))
                    .ToListAsync(ct);
        }

        public async Task<List<RelicItemDto>> GetPlayerRelicsAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return await db.RelicItems
                    .Where(i => i.PlayerId == id)
                    .Select(i => new RelicItemDto(
                        i.Id,
                        i.PlayerId,
                        i.ModelId,
                        i.RarityId,
                        i.DropId,
                        i.Level,
                        (int?)i.BuyPrice,
                        (int?)i.SellPrice,
                        i.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()))
                    .ToListAsync(ct);
        }

        public async Task<List<PlayerSkillDto>> GetPlayerSkillsAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            return player.SkillTree
                .Select(s => new PlayerSkillDto(
                    s.SkillId,
                    s.Amount))
                .ToList();
        }

        #endregion

        #region commands
        public async Task<Guid> AddPlayerAsync(AddPlayerDto dto, CancellationToken ct)
        {
            var account = await db.Accounts.FirstOrDefaultAsync(a => a.Id == dto.AccountId, ct)
                ?? throw new KeyNotFoundException($"unable to find account {dto.AccountId}");

            var @class = await db.PlayerClasses.FirstOrDefaultAsync(c => c.Id == dto.PlayerClassId, ct)
                ?? throw new KeyNotFoundException($"unable to find player class {dto.PlayerClassId}");

            if (dto.Experience.HasValue && dto.Experience.Value < 0)
            {
                throw new ArgumentException($"experience cannot be below zero");
            }

            if (dto.Money.HasValue && dto.Money.Value < 0)
            {
                throw new ArgumentException($"money cannot be below zero");
            }

            if (dto.Level.HasValue && (dto.Level.Value < 0 || dto.Level.Value > Byte.MaxValue))
            {
                throw new ArgumentException($"level must be between 0 and 255");
            }

            var player = new Player(account, @class, dto.Name, (byte?)dto.Level, (uint?)dto.Experience, (uint?)dto.Money);

            await db.Players.AddAsync(player, ct);
            await db.SaveChangesAsync(ct);

            return player.Id;
        }

        public async Task LevelUpPlayerAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            player.LevelUp();

            await db.SaveChangesAsync(ct);
        }

        public async Task SetPlayerLevelAsync(Guid id, int level, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            player.SetLevel(level);

            await db.SaveChangesAsync(ct);
        }

        public async Task AddGunToPlayerAsync(Guid id, GunItemDto item, CancellationToken ct)
        {
            (var player, var model, var rarity) = await GetItemObjectsAsync(id, item.ModelId, item.RarityId, ct);

            GunModel gunModel;
            if (model.Category == Equipment.Gun)
            {
                gunModel = new(model);
            }
            else
            {
                throw new ArgumentException($"model with ID {model.Id} is not a gun");
            }

            ElementalDamage? elementalDamage = null;
            double? elementalDamageChance = null;
            if (item.ElementalDamage != null)
            {
                elementalDamage = new(item.ElementalDamage.Element, item.ElementalDamage.DamagePerSecond);
                elementalDamageChance = item.ElementalDamage.Chance;
            }

            player.AddEquipment(new GunItem(player,
                gunModel,
                item.Level,
                rarity,
                item.Damage,
                item.Accuracy,
                item.FireRate,
                item.ReloadSpeed,
                item.MagazineSize,
                item.PelletCount,
                elementalDamage,
                elementalDamageChance,
                item.Prefix,
                item.MissionItem,
                (uint?)item.BuyPrice,
                (uint?)item.SellPrice));

            await db.SaveChangesAsync(ct);
        }

        public async Task AddGrenadeToPlayerAsync(Guid id, GrenadeItemDto item, CancellationToken ct)
        {
            (var player, var model, var rarity) = await GetItemObjectsAsync(id, item.ModelId, item.RarityId, ct);

            GrenadeModel grenadeModel;
            if (model.Category == Equipment.Grenade)
            {
                grenadeModel = new(model);
            }
            else
            {
                throw new ArgumentException($"model with ID {model.Id} is not a grenade");
            }

            ElementalDamage? elementalDamage = null;
            if (item.ElementalDamage != null)
            {
                elementalDamage = new(item.ElementalDamage.Element, item.ElementalDamage.DamagePerSecond);
            }

            player.AddEquipment(new GrenadeItem(player,
                grenadeModel,
                item.Level,
                rarity,
                item.Damage,
                item.BlastRadius,
                item.Fuse,
                item.Delivery,
                item.Sticky,
                item.ChildCount,
                elementalDamage,
                (uint?)item.BuyPrice,
                (uint?)item.SellPrice));

            await db.SaveChangesAsync(ct);
        }

        public async Task AddShieldToPlayerAsync(Guid id, ShieldItemDto item, CancellationToken ct)
        {
            (var player, var model, var rarity) = await GetItemObjectsAsync(id, item.ModelId, item.RarityId, ct);

            ShieldModel shieldModel;
            if (model.Category == Equipment.Shield)
            {
                shieldModel = new(model);
            }
            else
            {
                throw new ArgumentException($"model with ID {model.Id} is not a shield");
            }

            ElementalDamage? elementalDamage = null;
            if (item.ElementalDamage != null)
            {
                elementalDamage = new(item.ElementalDamage.Element, item.ElementalDamage.DamagePerSecond);
            }

            player.AddEquipment(new ShieldItem(player,
                shieldModel,
                item.Level,
                rarity,
                item.Capacity,
                item.RechargeRate,
                item.RechargeDelay,
                item.Prefix,
                elementalDamage,
                item.ElementalImmunity,
                item.ElementalReduction,
                (uint?)item.BuyPrice,
                (uint?)item.SellPrice));

            await db.SaveChangesAsync(ct);
        }

        public async Task AddRelicToPlayerAsync(Guid id, RelicItemDto item, CancellationToken ct)
        {
            (var player, var model, var rarity) = await GetItemObjectsAsync(id, item.ModelId, item.RarityId, ct);

            RelicModel relicModel;
            if (model.Category == Equipment.Relic)
            {
                relicModel = new(model);
            }
            else
            {
                throw new ArgumentException($"model with ID {model.Id} is not a relic");
            }

            player.AddEquipment(new RelicItem(player,
                relicModel,
                item.Level,
                rarity,
                (uint?)item.BuyPrice,
                (uint?)item.SellPrice));

            await db.SaveChangesAsync(ct);
        }

        public async Task AddClassModToPlayerAsync(Guid id, ClassModItemDto item, CancellationToken ct)
        {
            (var player, var model, var rarity) = await GetItemObjectsAsync(id, item.ModelId, item.RarityId, ct);

            ClassModModel classModModel;
            if (model.Category == Equipment.Shield)
            {
                classModModel = new(model);
            }
            else
            {
                throw new ArgumentException($"model with ID {model.Id} is not a shield");
            }

            player.AddEquipment(new ClassModItem(player,
                classModModel,
                item.Level,
                rarity,
                player.Class,
                item.Prefix,
                [],
                (uint?)item.BuyPrice,
                (uint?)item.SellPrice));

            await db.SaveChangesAsync(ct);
        }

        public async Task PlayerInvestInSkillAsync(Guid id, PlayerSkillDto investment, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            var skill = await db.Skills.FirstOrDefaultAsync(s => s.Id == investment.SkillId, ct)
                ?? throw new KeyNotFoundException($"no such skill exists with ID {investment.SkillId}");

            player.InvestIn(skill, investment.Amount);

            await db.SaveChangesAsync(ct);
        }

        public async Task ClearPlayerSkillTreeAsync(Guid id, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == id, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {id}");

            player.ClearSkillTree();

            await db.SaveChangesAsync(ct);
        }

        private async Task<(Player, EquipmentModel, Rarity)> GetItemObjectsAsync(Guid playerId, Guid modelId, Guid rarityId, CancellationToken ct)
        {
            var player = await db.Players.FirstOrDefaultAsync(p => p.Id == playerId, ct)
                ?? throw new KeyNotFoundException($"no such player exists with ID {playerId}");

            var model = await db.EquipmentModels.FirstOrDefaultAsync(m => m.Id == modelId, ct)
                ?? throw new KeyNotFoundException($"no such model exists with ID {modelId}");

            var rarity = await db.Rarities.FirstOrDefaultAsync(r => r.Id == rarityId, ct)
                ?? throw new KeyNotFoundException($"no such rarity exists with ID {rarityId}");

            return (player, model, rarity);
        }
        #endregion

    }
}
