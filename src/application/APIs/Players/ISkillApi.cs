namespace Vault.Application
{
    public interface ISkillApi
    {
        #region queries
        Task<List<SkillDto>> GetSkillsAsync(
            string? @class,
            string? tree,
            bool? onePointMax,
            int? tier,
            CancellationToken ct);
        Task<SkillDto> GetSkillAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
