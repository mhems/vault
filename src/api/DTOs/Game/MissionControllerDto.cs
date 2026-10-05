using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public sealed record MissionControllerDto(
        ResourceLinkDto Self,
        Dlc DLC,
        bool StoryMission,
        ResourceLinkDto StartArea,
        ResourceLinkDto EndArea,
        ResourceLinkDto? MissionGiver,
        ResourceLinkDto? MissionRewarder,
        ResourceLinkDto? MissionItem,
        ResourceLinkDto? LootPool,
        List<ResourceLinkDto> Maps,
        List<ResourceLinkDto> Predecessors,
        List<ResourceLinkDto> Successors
        );
}

