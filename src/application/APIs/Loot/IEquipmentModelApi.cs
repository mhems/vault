using Vault.Domain;

namespace Vault.Application
{
    public interface IEquipmentModelApi
    {
        Task<List<EquipmentModelDto>> GetEquipmentModelsAsync(
            string? name,
            Equipment? category,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            Guid? raritySetId,
            Guid? elementSetId,
            CancellationToken ct);

        Task<EquipmentModelDto> GetEquipmentModelAsync(Guid id, CancellationToken ct);
    }
}
