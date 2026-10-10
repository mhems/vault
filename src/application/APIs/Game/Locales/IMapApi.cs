using Vault.Domain;

namespace Vault.Application
{
    public interface IMapApi
    {
        #region queries
        Task<List<MapDto>> GetMapsAsync(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            bool? hasFastTravel,
            bool? hasMultipleConnections,
            CancellationToken ct);

        Task<MapDto> GetMapAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
