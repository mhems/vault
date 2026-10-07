using System.ComponentModel.DataAnnotations;

namespace Vault.Api
{
    public sealed record PlayerResponse(
        ResourceLink Self,
        ResourceLink Account,
        ResourceLink PlayerClassLink,
        string Name,
        [Range(1, 90)]
        int Level,
        [Range(0, int.MaxValue)]
        int? Experience,
        [Range(0, int.MaxValue)]
        int? Money,
        List<ResourceLink> Items,
        List<PlayerSkillResponse> SkillTrees
    );

    public sealed record PlayerSkillResponse(
        ResourceLink Skill,
        [Range(1, 5)]
        int Amount
    );
}
