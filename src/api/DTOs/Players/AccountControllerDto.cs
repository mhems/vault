using Vault.Api;

namespace api.DTOs.Players
{
    public sealed record AccountControllerDto(
        ResourceLinkDto Self,
        string Name,
        long? BadassRank,
        List<ResourceLinkDto> Players,
        List<ResourceLinkDto> StashedEquipment
        );
}
