namespace Vault.Application
{
    public interface IMissionApi
    {
        #region queries
        Task<List<MissionDto>> GetMissionsAsync(CancellationToken ct);

        Task<MissionDto> GetMissionAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
