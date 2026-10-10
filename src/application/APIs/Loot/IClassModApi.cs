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
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            string? prefix,
            Guid? boostsSkillId,
            int? boostsSkillBy,
            CancellationToken ct);

        Task<ClassModItemDto> GetClassModAsync(Guid id, CancellationToken ct);
    }
}
