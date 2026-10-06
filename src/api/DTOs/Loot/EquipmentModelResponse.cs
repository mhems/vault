using Vault.Domain;

namespace Vault.Api
{
    public sealed record EquipmentModelResponse(
        ResourceLinkDto Self,
        string? Name,
        Equipment Category,
        string SubCategory,
        Manufacturer Manufacturer,
        Dlc DLC,
        bool Unique,
        string? FlavorText,
        List<ResourceLinkDto> Instances,
        List<ResourceLinkDto> LootPools,
        ResourceLinkDto RaritySet,
        ResourceLinkDto? ElementSet
        );

    public sealed record RaritySetResponse(
        ResourceLinkDto Self,
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

    public sealed record ElementSetResponse(
        ResourceLinkDto Self,
        bool ComesWithoutElement,
        bool ComesInIncendiary,
        bool ComesInShock,
        bool ComesInCorrosive,
        bool ComesInSlag,
        bool ComesInExplosive
        );
}
