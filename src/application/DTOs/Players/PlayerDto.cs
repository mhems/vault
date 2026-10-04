namespace Vault.Application
{
    public sealed record PlayerDto(
        Guid Id,
        Guid AccountId,
        Guid PlayerClassId,
        string Name,
        int Level,
        int? Experience,
        int? Money,
        List<Guid> Items,
        List<PlayerSkillDto> SkillTree
    );

    public sealed record AddPlayerDto(
        Guid PlayerClassId,
        Guid AccountId,
        string Name,
        int? Level = 1,
        int? Experience = null,
        int? Money = null
    );

    public sealed record PlayerSkillDto(
        Guid SkillId,
        byte Amount
    );
}
