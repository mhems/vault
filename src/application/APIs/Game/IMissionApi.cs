using Vault.Domain;

namespace Vault.Application
{
    public interface IMissionApi
    {
        #region queries
        Task<List<MissionDto>> GetMissionsAsync(
            Dlc? dlc,
            bool? storyMission,
            bool? hasMissionItem,
            Guid? startAreaId,
            CancellationToken ct);

        Task<MissionDto> GetMissionAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
