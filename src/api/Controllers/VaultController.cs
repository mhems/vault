using api.DTOs.Players;
using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    public abstract class VaultController(LinkGenerator links) : ControllerBase
    {
        protected LinkGenerator links = links;

        protected ResourceLinkDto MakeResourceLinkDto(Guid id, string routeName)
        {
            var uri = links.GetUriByName(
                HttpContext,
                routeName,
                values: new { id })
            ?? throw new Exception($"id={id}, route={routeName}");
            return new(id, uri);
        }

        protected List<ResourceLinkDto> ConvertGuids(IEnumerable<Guid> guids, string route)
        {
            return guids
                .Select(id => MakeResourceLinkDto(id, route))
                .ToList();
        }

        protected PlayerControllerDto ConvertPlayer(PlayerDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.AccountId, AccountsController.GetAccountRoute),
                MakeResourceLinkDto(dto.PlayerClassId, PlayerClassesController.GetPlayerClassRoute),
                dto.Name,
                dto.Level,
                dto.Experience,
                dto.Money,
                ConvertGuids(dto.Items, EquipmentItemsController.GetEquipmentItemRoute),
                dto.SkillTree.Select(ps =>
                    new PlayerSkillControllerDto(MakeResourceLinkDto(ps.SkillId, SkillsController.GetSkillRoute),
                                                 ps.Amount)).ToList()
            );
        }

        protected AccountControllerDto ConvertAccount(AccountDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, AccountsController.GetAccountRoute),
                dto.Name,
                dto.BadassRank,
                ConvertGuids(dto.PlayerIds, PlayersController.GetPlayerRoute),
                ConvertGuids(dto.StashedEquipment, EquipmentItemsController.GetEquipmentItemRoute)
            );
        }

        protected PlayerClassControllerDto ConvertPlayerClass(PlayerClassDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, PlayerClassesController.GetPlayerClassRoute),
                dto.DLC,
                dto.Name,
                ConvertGuids(dto.Skills, SkillsController.GetSkillRoute),
                ConvertGuids(dto.Players, PlayersController.GetPlayerRoute)
            );
        }

        protected SkillControllerDto ConvertSkill(SkillDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, SkillsController.GetSkillRoute),
                MakeResourceLinkDto(dto.PlayerClassId, PlayerClassesController.GetPlayerClassRoute),
                dto.Name,
                dto.MaxPoints,
                dto.Tree,
                dto.TreeRow,
                dto.TreeColumn,
                dto.Description
            );
        }

        protected RarityControllerDto ConvertRarity(RarityDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, RaritiesController.GetRarityRoute),
                dto.Name,
                dto.ColorName,
                dto.RgbaColorValue
            );
        }

        protected EquipmentModelControllerDto ConvertEquipmentModel(EquipmentModelDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, EquipmentModelsController.GetEquipmentModelRoute),
                dto.Name,
                dto.Category,
                dto.SubCategory,
                dto.Manufacturer,
                dto.DLC,
                dto.Unique,
                dto.FlavorText,
                ConvertGuids(dto.Instances, EquipmentItemsController.GetEquipmentItemRoute),
                ConvertGuids(dto.LootPools, LootPoolsController.GetLootPoolRoute),
                MakeResourceLinkDto(dto.RaritySet, RaritySetsController.GetRaritySetRoute),
                dto.ElementSet != null ? MakeResourceLinkDto(dto.ElementSet.Value, ElementSetsController.GetElementSetRoute) : null
            );
        }

        protected RaritySetControllerDto ConvertRaritySet(RaritySetDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, RaritySetsController.GetRaritySetRoute),
                dto.ComesInWhite,
                dto.ComesInGreen,
                dto.ComesInBlue,
                dto.ComesInPurple,
                dto.ComesInLegendary,
                dto.ComesInEffervescent,
                dto.ComesInPearlescent,
                dto.ComesInSeraph,
                dto.ComesInETech
            );
        }

        protected ElementSetControllerDto ConvertElementSet(ElementSetDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, ElementSetsController.GetElementSetRoute),
                dto.ComesWithoutElement,
                dto.ComesInIncendiary,
                dto.ComesInShock,
                dto.ComesInCorrosive,
                dto.ComesInSlag,
                dto.ComesInExplosive
            );
        }

        protected EquipmentItemControllerDto ConvertEquipmentItem(EquipmentItemDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, EquipmentItemsController.GetEquipmentItemRoute),
                MakeResourceLinkDto(dto.PlayerId, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.ModelId, EquipmentModelsController.GetEquipmentModelRoute),
                MakeResourceLinkDto(dto.RarityId, RaritiesController.GetRarityRoute),
                ConvertLootDrop(dto.Drop),
                dto.Level,
                dto.BuyPrice,
                dto.SellPrice,
                dto.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()
                );
        }

        protected GunControllerDto ConvertGun(GunItemDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, GunsController.GetGunRoute),
                MakeResourceLinkDto(dto.PlayerId, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.ModelId, EquipmentModelsController.GetEquipmentModelRoute),
                MakeResourceLinkDto(dto.RarityId, RaritiesController.GetRarityRoute),
                ConvertLootDrop(dto.Drop),
                dto.Level,
                dto.BuyPrice,
                dto.SellPrice,
                dto.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                dto.Damage,
                dto.Accuracy,
                dto.FireRate,
                dto.ReloadSpeed,
                dto.MagazineSize,
                dto.PelletCount,
                dto.ElementalDamage,
                dto.Prefix,
                dto.MissionItem,
                dto.Barrel,
                dto.Stock,
                dto.Grip,
                dto.Scope,
                dto.Body
                );
        }

        protected GrenadeControllerDto ConvertGrenade(GrenadeItemDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, GrenadesController.GetGrenadeRoute),
                MakeResourceLinkDto(dto.PlayerId, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.ModelId, EquipmentModelsController.GetEquipmentModelRoute),
                MakeResourceLinkDto(dto.RarityId, RaritiesController.GetRarityRoute),
                ConvertLootDrop(dto.Drop),
                dto.Level,
                dto.BuyPrice,
                dto.SellPrice,
                dto.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                dto.Damage,
                dto.BlastRadius,
                dto.Fuse,
                dto.Delivery,
                dto.Sticky,
                dto.ChildCount,
                dto.ElementalDamage
                );
        }

        protected ShieldControllerDto ConvertShield(ShieldItemDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, ShieldsController.GetShieldRoute),
                MakeResourceLinkDto(dto.PlayerId, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.ModelId, EquipmentModelsController.GetEquipmentModelRoute),
                MakeResourceLinkDto(dto.RarityId, RaritiesController.GetRarityRoute),
                ConvertLootDrop(dto.Drop),
                dto.Level,
                dto.BuyPrice,
                dto.SellPrice,
                dto.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                dto.Capacity,
                dto.RechargeRate,
                dto.RechargeDelay,
                dto.Prefix,
                dto.ElementalDamage,
                dto.ElementalImmunity,
                dto.ElementalReduction,
                dto.Battery,
                dto.Capacitor,
                dto.Body
                );
        }

        protected ClassModControllerDto ConvertClassMod(ClassModItemDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, ClassModsController.GetClassModRoute),
                MakeResourceLinkDto(dto.PlayerId, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.ModelId, EquipmentModelsController.GetEquipmentModelRoute),
                MakeResourceLinkDto(dto.RarityId, RaritiesController.GetRarityRoute),
                ConvertLootDrop(dto.Drop),
                dto.Level,
                dto.BuyPrice,
                dto.SellPrice,
                dto.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList(),
                dto.Prefix,
                dto.Boosts.Select(b => new SkillBoostControllerDto(
                    MakeResourceLinkDto(b.SkillId, SkillsController.GetSkillRoute),
                    b.Amount)).ToList()
                );
        }

        protected RelicControllerDto ConvertRelic(RelicItemDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, RelicsController.GetRelicRoute),
                MakeResourceLinkDto(dto.PlayerId, PlayersController.GetPlayerRoute),
                MakeResourceLinkDto(dto.ModelId, EquipmentModelsController.GetEquipmentModelRoute),
                MakeResourceLinkDto(dto.RarityId, RaritiesController.GetRarityRoute),
                ConvertLootDrop(dto.Drop),
                dto.Level,
                dto.BuyPrice,
                dto.SellPrice,
                dto.Effects.Select(e => new EffectDto(e.Description, e.Amount, e.Units)).ToList()
                );
        }

        protected LootPoolControllerDto ConvertLootPool(LootPoolDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, LootPoolsController.GetLootPoolRoute),
                ConvertGuids(dto.Models, EquipmentModelsController.GetEquipmentModelRoute)
                );
        }

        protected LootDropControllerDto? ConvertLootDrop(LootDropDto? dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new(
                dto.Specified,
                dto.Mission != null ? MakeResourceLinkDto(dto.Mission.Value, MissionsController.GetMissionRoute) : null,
                dto.Area != null ? MakeResourceLinkDto(dto.Area.Value, AreasController.GetAreaRoute) : null,
                dto.Enemy != null ? MakeResourceLinkDto(dto.Enemy.Value, EnemiesController.GetEnemyRoute) : null
            );
        }

        protected MissionControllerDto ConvertMission(MissionDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, MissionsController.GetMissionRoute),
                dto.DLC,
                dto.StoryMission,
                MakeResourceLinkDto(dto.StartAreaId, AreasController.GetAreaRoute),
                MakeResourceLinkDto(dto.EndAreaId, AreasController.GetAreaRoute),
                dto.MissionGiver != null ? MakeResourceLinkDto(dto.MissionGiver.Value, CharactersController.GetCharacterRoute) : null,
                dto.MissionRewarder != null ? MakeResourceLinkDto(dto.MissionRewarder.Value, CharactersController.GetCharacterRoute) : null,
                dto.MissionItem != null ? MakeResourceLinkDto(dto.MissionItem.Value, EquipmentModelsController.GetEquipmentModelRoute) : null,
                dto.LootPool != null ? MakeResourceLinkDto(dto.LootPool.Value, LootPoolsController.GetLootPoolRoute) : null,
                ConvertGuids(dto.Maps, MapsController.GetMapRoute),
                ConvertGuids(dto.Predecessors, MissionsController.GetMissionRoute),
                ConvertGuids(dto.Successors, MissionsController.GetMissionRoute)
            );
        }

        protected LocationControllerDto ConvertLocation(LocationDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, MapsController.GetMapRoute),
                dto.Name,
                dto.DLC,
                ConvertGuids(dto.Characters, CharactersController.GetCharacterRoute)
                );
        }

        protected MapControllerDto ConvertMap(MapDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, MapsController.GetMapRoute),
                dto.Name,
                dto.DLC,
                ConvertGuids(dto.Characters, CharactersController.GetCharacterRoute),
                dto.NumberOfFastTravels,
                ConvertGuids(dto.Areas, AreasController.GetAreaRoute),
                ConvertGuids(dto.InConnections, MapsController.GetMapRoute),
                ConvertGuids(dto.OutConnections, MapsController.GetMapRoute)
                );
        }

        protected AreaControllerDto ConvertArea(AreaDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, AreasController.GetAreaRoute),
                dto.Name,
                dto.DLC,
                ConvertGuids(dto.Characters, CharactersController.GetCharacterRoute),
                dto.HasFastTravel,
                dto.HasUTurn,
                MakeResourceLinkDto(dto.MapId, MapsController.GetMapRoute)
                );
        }

        protected NonPlayableCharacterControllerDto ConvertCharacter(NonPlayableCharacterDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, CharactersController.GetCharacterRoute),
                dto.Name,
                dto.Species,
                dto.SubSpecies,
                dto.DLC,
                dto.Level,
                dto.Affiliation,
                dto.Enemy,
                ConvertGuids(dto.Locations, LocationsController.GetLocationRoute)
            );
        }

        protected EnemyControllerDto ConvertEnemy(EnemyDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, CharactersController.GetCharacterRoute),
                dto.Name,
                dto.Species,
                dto.SubSpecies,
                dto.DLC,
                dto.Level,
                dto.Affiliation,
                ConvertGuids(dto.Locations, LocationsController.GetLocationRoute),
                dto.Prefix,
                dto.HasShield,
                dto.Unique,
                dto.ElementalWeaknesses,
                dto.ElementalResistances,
                dto.ElementalImmunities,
                dto.LootPool != null ? MakeResourceLinkDto(dto.LootPool.Value, LootPoolsController.GetLootPoolRoute) : null
            );
        }

        protected UniqueEnemyControllerDto ConvertUniqueEnemy(UniqueEnemyDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, CharactersController.GetCharacterRoute),
                dto.Name,
                dto.Species,
                dto.SubSpecies,
                dto.DLC,
                dto.Level,
                dto.Affiliation,
                ConvertGuids(dto.Locations, LocationsController.GetLocationRoute),
                dto.Prefix,
                dto.HasShield,
                dto.ElementalWeaknesses,
                dto.ElementalResistances,
                dto.ElementalImmunities,
                dto.LootPool != null ? MakeResourceLinkDto(dto.LootPool.Value, LootPoolsController.GetLootPoolRoute) : null,
                dto.Boss,
                dto.RaidBoss
            );
        }
    }
}
