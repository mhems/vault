using System.ComponentModel.DataAnnotations;
using Vault.Api;
using Vault.Domain;

namespace Vault.Api
{
    public record LocationResponse(
        ResourceLink Self,
        string Name,
        Dlc DLC,
        List<ResourceLink> Characters
        );

    public record MapResponse(
        ResourceLink Self,
        string Name,
        Dlc DLC,
        List<ResourceLink> Characters,
        [Range(0, 6)]
        int NumberOfFastTravels,
        List<ResourceLink> Areas,
        List<ResourceLink> InConnections,
        List<ResourceLink> OutConnections
        )
        : LocationResponse(
            Self,
            Name,
            DLC,
            Characters);

    public record AreaResponse(
        ResourceLink Self,
        string Name,
        Dlc DLC,
        List<ResourceLink> Characters,
        bool HasFastTravel,
        bool? HasUTurn,
        ResourceLink Map
        )
        : LocationResponse(
            Self,
            Name,
            DLC,
            Characters);
}
