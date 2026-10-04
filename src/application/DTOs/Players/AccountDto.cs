namespace Vault.Application
{
    public sealed record AccountDto(
        Guid Id,
        string Name,
        long? BadassRank,
        List<Guid> PlayerIds,
        List<Guid> StashedEquipment
        );

    public sealed record AddAccountDto(
        string Name,
        long? BadassRank
        );
}
