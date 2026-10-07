using System.ComponentModel.DataAnnotations;
using Vault.Api;
using Vault.Domain;

namespace Vault.Api
{
    public record NonPlayableCharacterResponse(
        ResourceLink Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        [Range(1, 200)]
        int? Level,
        string? Affiliation,
        bool Enemy,
        List<ResourceLink> Locations
    );

    public record EnemyResponse(
        ResourceLink Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        [Range(1, 200)]
        int? Level,
        string? Affiliation,
        List<ResourceLink> Locations,
        string? Prefix,
        bool HasShield,
        bool Unique,
        List<Element> ElementalWeaknesses,
        List<Element> ElementalResistances,
        List<Element> ElementalImmunities,
        ResourceLink? LootPool)
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
        ResourceLink Self,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        [Range(1, 200)]
        int? Level,
        string? Affiliation,
        List<ResourceLink> Locations,
        string? Prefix,
        bool HasShield,
        List<Element> ElementalWeaknesses,
        List<Element> ElementalResistances,
        List<Element> ElementalImmunities,
        ResourceLink? LootPool,
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

