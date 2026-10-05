using Vault.Domain;

namespace Vault.Application
{
    public record EquipmentItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
        byte? Level,
        int? BuyPrice,
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
        double DamagePerSecond
        );

    public sealed record ElementalDamageChanceDto(
        Element Element,
        double DamagePerSecond,
        double Chance
        );

    public sealed record GunItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDropDto? Drop,
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
        byte? Level,
        int? BuyPrice,
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
        byte? Level,
        int? BuyPrice,
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
        int Amount
        );

    public sealed record LootDropDto(
        bool Specified,
        Guid? Mission,
        Guid? Area,
        Guid? Enemy
    )
    {
        public LootDropDto(LootDrop drop)
            : this(drop.Specified,
                 drop.MissionId,
                 drop.AreaId,
                 drop.EnemyId)
        {

        }
    }
}
