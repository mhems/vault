using System.ComponentModel.DataAnnotations;
using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public record NonPlayableCharacterResponse(
        ResourceLinkDto Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        [Range(1, 200)]
        int? Level,
        string? Affiliation,
        bool Enemy,
        List<ResourceLinkDto> Locations
    );

    public record EnemyResponse(
        ResourceLinkDto Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        [Range(1, 200)]
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
        : NonPlayableCharacterResponse(
            Self,
            Name,
            Species,
            SubSpecies,
            DLC,
            Level,
            Affiliation,
            true,
            Locations);

    public sealed record UniqueEnemyResponse(
        ResourceLinkDto Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        [Range(1, 200)]
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
        : EnemyResponse(
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

