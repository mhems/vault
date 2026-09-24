namespace Vault.Application
{
    public sealed record EquipableInstanceDto(
        Guid Id,
        string Name,
        string Category,
        string Manufacturer,
        byte Level,
        bool Unique,
        int? BuyPrice,
        int? SellPrice,
        string? FlavorText
        );
}
