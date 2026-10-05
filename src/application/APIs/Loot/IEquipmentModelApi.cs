namespace Vault.Application
{
    public interface IEquipmentModelApi
    {
        Task<List<EquipmentModelDto>> GetEquipmentModelsAsync(CancellationToken ct);

        Task<List<EquipmentModelDto>> GetEquipmentModelsByCategoryAsync(string category, CancellationToken ct);

        Task<List<EquipmentModelDto>> GetEquipmentModelsByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<List<EquipmentModelDto>> GetEquipmentModelsByRaritySetAsync(Guid id, CancellationToken ct);

        Task<List<EquipmentModelDto>> GetEquipmentModelsByElementSetAsync(Guid id, CancellationToken ct);

        Task<EquipmentModelDto> GetEquipmentModelAsync(Guid id, CancellationToken ct);
    }
}
