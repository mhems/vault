using System.ComponentModel.DataAnnotations;
using Vault.Domain;

namespace Vault.Api
{
    public sealed record LootDrop(
        Guid? Mission,
        Guid? Area,
        Guid? Enemy
    );

    public sealed record AddGunRequest(
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDrop? Drop,
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
    );

    public sealed record AddGrenadeRequest(
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDrop? Drop,
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
        );

    public sealed record AddShieldRequest(
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDrop? Drop,
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
        );

    public sealed record AddRelicRequest(
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDrop? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects
        );

    public sealed record AddClassModRequest(
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        LootDrop? Drop,
        [Range(1, 90)]
        int? Level,
        [Range(1, int.MaxValue)]
        int? BuyPrice,
        [Range(1, int.MaxValue)]
        int? SellPrice,
        List<Effect> Effects,
        string Prefix,
        List<SkillBoost> Boosts
        );

    public sealed record SkillBoost(
        Guid SkillId,
        [Range(1, 6)]
        int Amount
        );

    public sealed record InvestPlayerSkillRequest(
        Guid SkillId,
        [Range(1, 5)]
        int Amount
        );
}
