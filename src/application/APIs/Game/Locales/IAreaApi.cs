namespace Vault.Application
{
    public interface IAreaApi
    {
        #region queries
        Task<List<AreaDto>> GetAreasAsync(CancellationToken ct);

        Task<AreaDto> GetAreaAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
