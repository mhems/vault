using System.ComponentModel.DataAnnotations;
using Vault.Api;

namespace api.DTOs.Players
{
    public sealed record PlayerResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Account,
        ResourceLinkDto PlayerClassLink,
        string Name,
        [Range(1, 90)]
        int Level,
        [Range(0, int.MaxValue)]
        int? Experience,
        [Range(0, int.MaxValue)]
        int? Money,
        List<ResourceLinkDto> Items,
        List<PlayerSkillResponse> SkillTrees
    );

    public sealed record PlayerSkillResponse(
        ResourceLinkDto Skill,
        [Range(1, 5)]
        int Amount
    );
}
