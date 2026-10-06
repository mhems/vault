using System.ComponentModel.DataAnnotations;
using Vault.Api;
using Vault.Domain;

namespace Vault.Application
{
    public record EquipmentItemResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects
        );

    public sealed record GunResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects,
        [Range(0, int.MaxValue)]
        int Damage,
        [Range(1, 100)]
        double Accuracy,
        [Range(0, double.MaxValue)]
        double FireRate,
        [Range(0, double.MaxValue)]
        double ReloadSpeed,
        [Range(1, int.MaxValue)]
        int MagazineSize,
        [Range(1, int.MaxValue)]
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
        : EquipmentItemResponse(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record GrenadeResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects,
        [Range(0, int.MaxValue)]
        int Damage,
        [Range(0, int.MaxValue)]
        int BlastRadius,
        [Range(0, double.MaxValue)]
        double Fuse,
        GrenadeDelivery Delivery,
        bool Sticky,
        [Range(0, int.MaxValue)]
        int? ChildCount,
        ElementalDamageDto? ElementalDamage
        )
        : EquipmentItemResponse(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record ShieldResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects,
        [Range(0, int.MaxValue)]
        int Capacity,
        [Range(0, int.MaxValue)]
        int RechargeRate,
        [Range(0, double.MaxValue)]
        double RechargeDelay,
        string? Prefix,
        ElementalDamageDto? ElementalDamage,
        Element? ElementalImmunity,
        Element? ElementalReduction,
        Manufacturer? Battery,
        Manufacturer? Capacitor,
        Manufacturer? Body
        )
        : EquipmentItemResponse(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record RelicResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects
        )
        : EquipmentItemResponse(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record ClassModResponse(
        ResourceLinkDto Self,
        ResourceLinkDto Player,
        ResourceLinkDto Model,
        ResourceLinkDto Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects,
        string Prefix,
        List<SkillBoostResponse> Boosts
        )
        : EquipmentItemResponse(Self,
            Player,
            Model,
            Rarity,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record SkillBoostResponse(
        ResourceLinkDto Skill,
        [Range(1, 6)]
        int Amount
        );

    public sealed record LootDropResponse(
        bool Specified,
        ResourceLinkDto? Mission,
        ResourceLinkDto? Area,
        ResourceLinkDto? Enemy
    );
}
