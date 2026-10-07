using Vault.Api;
using Vault.Domain;

namespace Vault.Api
{
    public sealed record MissionResponse(
        ResourceLink Self,
        Dlc DLC,
        bool StoryMission,
        ResourceLink StartArea,
        ResourceLink EndArea,
        ResourceLink? MissionGiver,
        ResourceLink? MissionRewarder,
        ResourceLink? MissionItem,
        ResourceLink? LootPool,
        List<ResourceLink> Maps,
        List<ResourceLink> Predecessors,
        List<ResourceLink> Successors
        );
}

