using System.ComponentModel.DataAnnotations;
using Vault.Api;

namespace api.DTOs.Players
{
    public sealed record AccountResponse(
        ResourceLinkDto Self,
        string Name,
        [Range(0, long.MaxValue)]
        long? BadassRank,
        List<ResourceLinkDto> Players,
        List<ResourceLinkDto> StashedEquipment
        );
}
