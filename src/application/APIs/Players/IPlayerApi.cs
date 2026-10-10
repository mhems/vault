namespace Vault.Application
{
    public interface IPlayerApi
    {
        #region queries
        Task<PlayerDto> GetPlayerAsync(Guid id, CancellationToken ct);
        Task<List<PlayerDto>> GetPlayersAsync(
            Guid? accountId,
            string? @class,
            int? minLevel,
            CancellationToken ct);
        Task<List<EquipmentItemDto>> GetPlayerItemsAsync(Guid id, CancellationToken ct);
        Task<List<GunItemDto>> GetPlayerGunsAsync(Guid id, CancellationToken ct);
        Task<List<GrenadeItemDto>> GetPlayerGrenadesAsync(Guid id, CancellationToken ct);
        Task<List<ShieldItemDto>> GetPlayerShieldsAsync(Guid id, CancellationToken ct);
        Task<List<ClassModItemDto>> GetPlayerClassModsAsync(Guid id, CancellationToken ct);
        Task<List<RelicItemDto>> GetPlayerRelicsAsync(Guid id, CancellationToken ct);
        #endregion

        #region commands
        Task<Guid> AddPlayerAsync(AddPlayerRequest dto, CancellationToken ct);

        Task LevelUpPlayerAsync(Guid id, CancellationToken ct);

        Task SetPlayerLevelAsync(Guid id, int level, CancellationToken ct);

        Task<Guid> AddGunToPlayerAsync(Guid id, GunItemDto item, CancellationToken ct);

        Task<Guid> AddGrenadeToPlayerAsync(Guid id, GrenadeItemDto item, CancellationToken ct);

        Task<Guid> AddShieldToPlayerAsync(Guid id, ShieldItemDto item, CancellationToken ct);

        Task<Guid> AddClassModToPlayerAsync(Guid id, ClassModItemDto item, CancellationToken ct);

        Task<Guid> AddRelicToPlayerAsync(Guid id, RelicItemDto item, CancellationToken ct);

        Task PlayerInvestInSkillAsync(Guid id, PlayerSkillDto investment, CancellationToken ct);

        Task ClearPlayerSkillTreeAsync(Guid id, CancellationToken ct);
        #endregion

    }
}
