using System.ComponentModel.DataAnnotations;
using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public record LocationResponse(
        ResourceLinkDto Self,
        string Name,
        Dlc DLC,
        List<ResourceLinkDto> Characters
        );

    public record MapResponse(
        ResourceLinkDto Self,
        string Name,
        Dlc DLC,
        List<ResourceLinkDto> Characters,
        [Range(0, 6)]
        int NumberOfFastTravels,
        List<ResourceLinkDto> Areas,
        List<ResourceLinkDto> InConnections,
        List<ResourceLinkDto> OutConnections
        )
        : LocationResponse(
            Self,
            Name,
            DLC,
            Characters);

    public record AreaResponse(
        ResourceLinkDto Self,
        string Name,
        Dlc DLC,
        List<ResourceLinkDto> Characters,
        bool HasFastTravel,
        bool? HasUTurn,
        ResourceLinkDto Map
        )
        : LocationResponse(
            Self,
            Name,
            DLC,
            Characters);
}
