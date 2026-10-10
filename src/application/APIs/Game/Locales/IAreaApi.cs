using Vault.Domain;

namespace Vault.Application
{
    public interface IAreaApi
    {
        #region queries
        Task<List<AreaDto>> GetAreasAsync(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            bool? hasFastTravel,
            bool? hasUTurn,
            Guid? mapId,
            CancellationToken ct);

        Task<AreaDto> GetAreaAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
