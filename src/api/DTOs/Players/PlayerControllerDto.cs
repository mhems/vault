using Vault.Api;

namespace api.DTOs.Players
{
    public sealed record PlayerControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Account,
        ResourceLinkDto PlayerClassLink,
        string Name,
        int Level,
        int? Experience,
        int? Money,
        List<ResourceLinkDto> Items,
        List<PlayerSkillControllerDto> SkillTrees
    );

    public sealed record PlayerSkillControllerDto(
        ResourceLinkDto Skill,
        int Amount
    );
}
