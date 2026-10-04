using Vault.Domain;

namespace Vault.Application
{
    public sealed record EquipmentModelDto(
        Guid Id,
        string? Name,
        Equipment Category,
        string SubCategory,
        Manufacturer Manufacturer,
        Dlc DLC,
        bool Unique,
        string? FlavorText,
        List<Guid> Instances,
        List<Guid> LootPools,
        Guid RaritySet,
        Guid? ElementSet
        );

    public sealed record RaritySetDto(
        Guid Id,
        bool ComesInWhite,
        bool ComesInGreen,
        bool ComesInBlue,
        bool ComesInPurple,
        bool ComesInLegendary,
        bool ComesInEffervescent,
        bool ComesInPearlescent,
        bool ComesInSeraph,
        bool ComesInETech
        );

    public sealed record ElementSetDto(
        Guid Id,
        bool ComesWithoutElement,
        bool ComesInIncendiary,
        bool ComesInShock,
        bool ComesInCorrosive,
        bool ComesInSlag,
        bool ComesInExplosive
        );
}
