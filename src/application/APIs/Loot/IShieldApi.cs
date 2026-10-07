using Vault.Domain;

namespace Vault.Application
{
    public interface IShieldApi
    {
        Task<List<ShieldItemDto>> GetShieldsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Shield? category,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            string? element,
            string? prefix,
            Element? immunity,
            Element? reduction,
            Manufacturer? battery,
            Manufacturer? capacitor,
            Manufacturer? body,
            CancellationToken ct);

        Task<ShieldItemDto> GetShieldAsync(Guid id, CancellationToken ct);
    }
}
