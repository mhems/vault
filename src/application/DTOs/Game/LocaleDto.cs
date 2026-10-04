using Vault.Domain;

namespace Vault.Application
{
    public record LocationDto(
        Guid Id,
        string Name,
        Dlc DLC,
        List<Guid> Characters
        );

    public record MapDto(
        Guid Id,
        string Name,
        Dlc DLC,
        List<Guid> Characters,
        int NumberOfFastTravels,
        List<Guid> Areas,
        List<Guid> InConnections,
        List<Guid> OutConnections
        )
        : LocationDto(
            Id,
            Name,
            DLC,
            Characters);

    public record AreaDto(
        Guid Id,
        string Name,
        Dlc DLC,
        List<Guid> Characters,
        bool HasFastTravel,
        bool? HasUTurn,
        Guid MapId
        )
        : LocationDto(
            Id,
            Name,
            DLC,
            Characters);
}
