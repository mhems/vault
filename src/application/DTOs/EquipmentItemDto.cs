namespace Vault.Application
{
    public sealed record EquipmentItemDto(
        Guid Id,
        Guid PlayerId,
        Guid ModelId,
        Guid RarityId,
        byte Level,
        int? BuyPrice,
        int? SellPrice
        );
}
