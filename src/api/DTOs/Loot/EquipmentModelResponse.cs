using Vault.Domain;

namespace Vault.Api
{
    public sealed record EquipmentModelResponse(
        ResourceLink Self,
        string? Name,
        Equipment Category,
        string SubCategory,
        Manufacturer Manufacturer,
        Dlc DLC,
        bool Unique,
        string? FlavorText,
        List<ResourceLink> Instances,
        List<ResourceLink> LootPools,
        ResourceLink RaritySet,
        ResourceLink? ElementSet
        );

    public sealed record RaritySetResponse(
        ResourceLink Self,
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
        ResourceLink Self,
        bool ComesWithoutElement,
        bool ComesInIncendiary,
        bool ComesInShock,
        bool ComesInCorrosive,
        bool ComesInSlag,
        bool ComesInExplosive
        );
}
