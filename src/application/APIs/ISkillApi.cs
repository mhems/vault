namespace Vault.Application
{
    public interface ISkillApi
    {
        #region queries
        Task<List<SkillDto>> GetSkillsAsync(CancellationToken ct);

        Task<List<SkillDto>> GetSkillsByPlayerClassAsync(string @class, CancellationToken ct);

        Task<SkillDto> GetSkillAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
