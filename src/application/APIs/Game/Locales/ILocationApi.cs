namespace Vault.Application
{
    public interface ILocationApi
    {
        #region queries
        Task<List<LocationDto>> GetLocationsAsync(CancellationToken ct);

        Task<LocationDto> GetLocationAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
