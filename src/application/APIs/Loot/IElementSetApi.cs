namespace Vault.Application
{
    public interface IElementSetApi
    {
        #region queries
        Task<List<ElementSetDto>> GetElementSetsAsync(CancellationToken ct);

        Task<ElementSetDto> GetElementSetAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
