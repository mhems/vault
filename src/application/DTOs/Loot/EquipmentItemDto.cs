using System.ComponentModel.DataAnnotations;
using Vault.Domain;

namespace Vault.Application
{
    public record EquipmentItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects
        );

    public sealed record EffectDto(
        string Description,
        double? Amount,
        string? Units
        );

    public sealed record ElementalDamageDto(
        Element Element,
        [Range(0, double.MaxValue)]
        double DamagePerSecond
        );

    public sealed record ElementalDamageChanceDto(
        Element Element,
        [Range(0, double.MaxValue)]
        double DamagePerSecond,
        [Range(1, 100)]
        double Chance
        );

    public sealed record GunItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
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
        : EquipmentItemDto(Id,
            PlayerId,
            ModelId,
            RarityId,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record GrenadeItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
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
        : EquipmentItemDto(Id,
            PlayerId,
            ModelId,
            RarityId,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record ShieldItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
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
        : EquipmentItemDto(Id,
            PlayerId,
            ModelId,
            RarityId,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record RelicItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects
        )
        : EquipmentItemDto(Id,
            PlayerId,
            ModelId,
            RarityId,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record ClassModItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<EffectDto> Effects,
        string Prefix,
        List<SkillBoostDto> Boosts
        )
        : EquipmentItemDto(Id,
            PlayerId,
            ModelId,
            RarityId,
            Drop,
            Level,
            BuyPrice,
            SellPrice,
            Effects);

    public sealed record SkillBoostDto(
        Guid SkillId,
        [Range(1, 6)]
        int Amount
        );

    public sealed record LootDropDto(
        Guid? Mission,
        Guid? Area,
        Guid? Enemy
    )
    {
        public LootDropDto(LootDrop drop)
            : this(drop.MissionId,
                 drop.AreaId,
                 drop.EnemyId)
        {

        }
    }
}
