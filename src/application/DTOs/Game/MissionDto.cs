using Vault.Domain;

namespace Vault.Application
{
    public sealed record MissionDto(
        Guid Id,
        Dlc DLC,
        bool StoryMission,
        Guid StartAreaId,
        Guid EndAreaId,
        Guid? MissionGiver,
        Guid? MissionRewarder,
        Guid? MissionItem,
        Guid? LootPool,
        List<Guid> Maps,
        List<Guid> Predecessors,
        List<Guid> Successors
        );
}

