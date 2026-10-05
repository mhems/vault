using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public record EquipmentItemControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropControllerDto? Drop,
        byte? Level,
        int? BuyPrice,
        int? SellPrice,
        List<EffectDto> Effects
        );

    public sealed record GunControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropControllerDto? Drop,
        byte? Level,
        int? BuyPrice,
        int? SellPrice,
        List<EffectDto> Effects,
        int Damage,
        double Accuracy,
        double FireRate,
        double ReloadSpeed,
        int MagazineSize,
        int? PelletCount,
        ElementalDamageChanceDto? ElementalDamage,
        string? Prefix,
        bool MissionItem,
        Manufacturer? Barrel,
        Manufacturer? Stock,
        Manufacturer? Grip,
        Manufacturer? Scope,
        Manufacturer? Body
        )
        : EquipmentItemControllerDto(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record GrenadeControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropControllerDto? Drop,
        byte? Level,
        int? BuyPrice,
        int? SellPrice,
        List<EffectDto> Effects,
        int Damage,
        int BlastRadius,
        double Fuse,
        GrenadeDelivery Delivery,
        bool Sticky,
        int? ChildCount,
        ElementalDamageDto? ElementalDamage
        )
        : EquipmentItemControllerDto(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record ShieldControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropControllerDto? Drop,
        byte? Level,
        int? BuyPrice,
        int? SellPrice,
        List<EffectDto> Effects,
        int Capacity,
        int RechargeRate,
        double RechargeDelay,
        string? Prefix,
        ElementalDamageDto? ElementalDamage,
        Element? ElementalImmunity,
        Element? ElementalReduction,
        Manufacturer? Battery,
        Manufacturer? Capacitor,
        Manufacturer? Body
        )
        : EquipmentItemControllerDto(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record RelicControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropControllerDto? Drop,
        byte? Level,
        int? BuyPrice,
        int? SellPrice,
        List<EffectDto> Effects
        )
        : EquipmentItemControllerDto(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record ClassModControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropControllerDto? Drop,
        byte? Level,
        int? BuyPrice,
        int? SellPrice,
        List<EffectDto> Effects,
        string Prefix,
        List<SkillBoostControllerDto> Boosts
        )
        : EquipmentItemControllerDto(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record SkillBoostControllerDto(
        ResourceLinkDto Skill,
        int Amount
        );

    public sealed record LootDropControllerDto(
        bool Specified,
        ResourceLinkDto? Mission,
        ResourceLinkDto? Area,
        ResourceLinkDto? Enemy
    );
}
