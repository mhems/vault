using System.ComponentModel.DataAnnotations;

namespace Vault.Api
{
    public sealed record AccountResponse(
        ResourceLink Self,
        string Name,
        [Range(0, long.MaxValue)]
        long? BadassRank,
        List<ResourceLink> Players,
        List<ResourceLink> StashedEquipment
        );
}
