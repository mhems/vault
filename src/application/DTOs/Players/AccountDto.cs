using System.ComponentModel.DataAnnotations;

namespace Vault.Application
{
    public sealed record AccountDto(
        Guid Id,
        string Name,
        [Range(0, long.MaxValue)]
        long? BadassRank,
        List<Guid> PlayerIds,
        List<Guid> StashedEquipment
        );

    public sealed record AddAccountRequest(
        string Name,
        [Range(0, long.MaxValue)]
        long? BadassRank
        );
}
