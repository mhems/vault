using Vault.Domain;

namespace Vault.Application
{
    public interface IClassModApi
    {
        Task<List<ClassModItemDto>> GetClassModsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            string? @class,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            Guid? skillId,
            CancellationToken ct);

        Task<ClassModItemDto> GetClassModAsync(Guid id, CancellationToken ct);
    }
}
