using System.ComponentModel.DataAnnotations;
using Vault.Domain;

namespace Vault.Api
{
    public record EquipmentItemResponse(
        ResourceLink Self,
        ResourceLink Player,
        ResourceLink Model,
        ResourceLink Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects
        );

    public sealed record Effect(
        string Description,
        double? Amount,
        string? Units
        );

    public sealed record GunResponse(
        ResourceLink Self,
        ResourceLink Player,
        ResourceLink Model,
        ResourceLink Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects,
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
        ElementalDamageChance? ElementalDamage,
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

    public sealed record ElementalDamageChance(
        Element Element,
        [Range(0, double.MaxValue)]
        double DamagePerSecond,
        [Range(1, 100)]
        double Chance
    );

    public sealed record GrenadeResponse(
        ResourceLink Self,
        ResourceLink Player,
        ResourceLink Model,
        ResourceLink Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects,
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
        ElementalDamage? ElementalDamage
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

    public sealed record ElementalDamage(
        Element Element,
        [Range(0, double.MaxValue)]
        double DamagePerSecond
        );

    public sealed record ShieldResponse(
        ResourceLink Self,
        ResourceLink Player,
        ResourceLink Model,
        ResourceLink Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects,
        [Range(0, int.MaxValue)]
        int Capacity,
        [Range(0, int.MaxValue)]
        int RechargeRate,
        [Range(0, double.MaxValue)]
        double RechargeDelay,
        string? Prefix,
        ElementalDamage? ElementalDamage,
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
        ResourceLink Self,
        ResourceLink Player,
        ResourceLink Model,
        ResourceLink Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects
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
        ResourceLink Self,
        ResourceLink Player,
        ResourceLink Model,
        ResourceLink Rarity,
        LootDropResponse? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects,
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
        ResourceLink Skill,
        [Range(1, 6)]
        int Amount
        );

    public sealed record LootDropResponse(
        ResourceLink? Mission,
        ResourceLink? Area,
        ResourceLink? Enemy
    );
}
