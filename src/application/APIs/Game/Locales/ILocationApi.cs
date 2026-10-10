using Vault.Domain;

namespace Vault.Application
{
    public interface ILocationApi
    {
        #region queries
        Task<List<LocationDto>> GetLocationsAsync(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            CancellationToken ct);

        Task<LocationDto> GetLocationAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
