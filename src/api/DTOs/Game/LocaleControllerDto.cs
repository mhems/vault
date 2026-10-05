using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public record LocationControllerDto(
        ResourceLinkDto Self,
        string Name,
        Dlc DLC,
        List<ResourceLinkDto> Characters
        );

    public record MapControllerDto(
        ResourceLinkDto Self,
        string Name,
        Dlc DLC,
        List<ResourceLinkDto> Characters,
        int NumberOfFastTravels,
        List<ResourceLinkDto> Areas,
        List<ResourceLinkDto> InConnections,
        List<ResourceLinkDto> OutConnections
        )
        : LocationControllerDto(
            Self,
            Name,
            DLC,
            Characters);

    public record AreaControllerDto(
        ResourceLinkDto Self,
        string Name,
        Dlc DLC,
        List<ResourceLinkDto> Characters,
        bool HasFastTravel,
        bool? HasUTurn,
        ResourceLinkDto Map
        )
        : LocationControllerDto(
            Self,
            Name,
            DLC,
            Characters);
}
