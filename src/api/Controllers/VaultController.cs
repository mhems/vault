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
            ?? string.Empty;
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
                ConvertGuids(dto.Items, ""),
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
                ConvertGuids(dto.StashedEquipment, "")
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
                dto.Description);
        }

        protected RarityControllerDto ConvertRarity(RarityDto dto)
        {
            return new(
                MakeResourceLinkDto(dto.Id, RaritiesController.GetRarityRoute),
                dto.Name,
                dto.ColorName,
                dto.RgbaColorValue);
        }
    }
}
