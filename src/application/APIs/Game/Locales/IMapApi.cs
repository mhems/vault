namespace Vault.Application
{
    public interface IMapApi
    {
        #region queries
        Task<List<MapDto>> GetMapsAsync(CancellationToken ct);

        Task<MapDto> GetMapAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
