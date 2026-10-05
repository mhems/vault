using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public record NonPlayableCharacterControllerDto(
        ResourceLinkDto Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        int? Level,
        string? Affiliation,
        bool Enemy,
        List<ResourceLinkDto> Locations
    );

    public record EnemyControllerDto(
        ResourceLinkDto Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        int? Level,
        string? Affiliation,
        List<ResourceLinkDto> Locations,
        string? Prefix,
        bool HasShield,
        bool Unique,
        List<Element> ElementalWeaknesses,
        List<Element> ElementalResistances,
        List<Element> ElementalImmunities,
        ResourceLinkDto? LootPool)
        : NonPlayableCharacterControllerDto(
            Self,
            Name,
            Species,
            SubSpecies,
            DLC,
            Level,
            Affiliation,
            true,
            Locations);

    public sealed record UniqueEnemyControllerDto(
        ResourceLinkDto Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        int? Level,
        string? Affiliation,
        List<ResourceLinkDto> Locations,
        string? Prefix,
        bool HasShield,
        List<Element> ElementalWeaknesses,
        List<Element> ElementalResistances,
        List<Element> ElementalImmunities,
        ResourceLinkDto? LootPool,
        bool Boss,
        bool RaidBoss
        )
        : EnemyControllerDto(
            Self,
            Name,
            Species,
            SubSpecies,
            DLC,
            Level,
            Affiliation,
            Locations,
            Prefix,
            HasShield,
            true,
            ElementalWeaknesses,
            ElementalResistances,
            ElementalImmunities,
            LootPool);
}

