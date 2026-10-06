using System.ComponentModel.DataAnnotations;

namespace Vault.Application
{
    public sealed record PlayerDto(
        Guid Id,
        Guid AccountId,
        Guid PlayerClassId,
        string Name,
        [Range(1, 90)]
        int Level,
        [Range(0, int.MaxValue)]
        int? Experience,
        [Range(0, int.MaxValue)]
        int? Money,
        List<Guid> Items,
        List<PlayerSkillDto> SkillTree
    );

    public sealed record AddPlayerRequest(
        Guid PlayerClassId,
        Guid AccountId,
        string Name,
        [Range(1, 90)]
        int Level = 1,
        [Range(0, int.MaxValue)]
        int? Experience = null,
        [Range(0, int.MaxValue)]
        int? Money = null
    );

    public sealed record PlayerSkillDto(
        Guid SkillId,
        [Range(1, 5)]
        int Amount
    );
}
