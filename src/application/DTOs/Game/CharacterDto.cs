using Vault.Domain;

namespace Vault.Application
{
    public record NonPlayableCharacterDto(
    Guid Id,
    string? Name,
    string Species,
    string? SubSpecies,
    Dlc DLC,
    int? Level,
    string? Affiliation,
    bool Enemy,
    List<Guid> Locations
    );

    public record EnemyDto(
        Guid Id,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        int? Level,
        string? Affiliation,
        List<Guid> Locations,
        string? Prefix,
        bool HasShield,
        bool Unique,
        List<Element> ElementalWeaknesses,
        List<Element> ElementalResistances,
        List<Element> ElementalImmunities,
        Guid LootPoolId)
        : NonPlayableCharacterDto(
            Id,
            Name,
            Species,
            SubSpecies,
            DLC,
            Level,
            Affiliation,
            true,
            Locations);

    public sealed record UniqueEnemyDto(
        Guid Id,
        string? Name,
        string Species,
        string? SubSpecies,
        Dlc DLC,
        int? Level,
        string? Affiliation,
        List<Guid> Locations,
        string? Prefix,
        bool HasShield,
        List<Element> ElementalWeaknesses,
        List<Element> ElementalResistances,
        List<Element> ElementalImmunities,
        Guid LootPoolId,
        bool Boss,
        bool RaidBoss
        )
        : EnemyDto(
            Id,
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
            LootPoolId);
}

