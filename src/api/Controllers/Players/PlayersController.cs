using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController(IPlayerApi api, LinkGenerator links) : VaultController(links)
    {
        #region route names
        internal const string GetPlayersRoute = "GetPlayers";
        internal const string GetPlayersByClassRoute = "GetPlayersByClass";
        internal const string GetPlayerRoute = "GetPlayer";
        internal const string GetPlayerItemsRoute = "GetPlayerItems";
        internal const string GetPlayerGunsRoute = "GetPlayerGuns";
        internal const string GetPlayerGrenadesRoute = "GetPlayerGrenades";
        internal const string GetPlayerShieldsRoute = "GetPlayerShields";
        internal const string GetPlayerClassModsRoute = "GetPlayerClassMods";
        internal const string GetPlayerRelicsRoute = "GetPlayerRelics";

        internal const string AddPlayerRoute = "AddPlayer";
        internal const string LevelUpPlayerRoute = "LevelUpPlayer";
        internal const string SetPlayerLevelRoute = "SetPlayerLevel";
        internal const string AddGunToPlayerRoute = "AddGunToPlayer";
        internal const string AddGrenadeToPlayerRoute = "AddGrenadeToPlayer";
        internal const string AddShieldToPlayerRoute = "AddShieldToPlayer";
        internal const string AddClassModToPlayerRoute = "AddClassModToPlayer";
        internal const string AddRelicToPlayerRoute = "AddRelicToPlayer";
        internal const string PlayerInvestInSkillRoute = "PlayerInvestInSkill";
        internal const string ClearPlayerSkillTreeRoute = "ClearPlayerSkills";
        #endregion

        private readonly IPlayerApi api = api;

        #region queries
        [HttpGet(Name = GetPlayersRoute)]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers(CancellationToken ct)
        {
            var players = await api.GetPlayersAsync(ct);
            var linkedPlayers = players.Select(ConvertPlayer).ToList();
            return Ok(linkedPlayers);
        }

        [HttpGet("by/class/{class}", Name = GetPlayersByClassRoute)]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayersByClass(string @class, CancellationToken ct)
        {
            var players = await api.GetPlayersByClassAsync(@class, ct);
            var linkedPlayers = players.Select(ConvertPlayer).ToList();
            return Ok(linkedPlayers);
        }

        [HttpGet("{id}", Name = GetPlayerRoute)]
        public async Task<ActionResult<PlayerDto>> GetPlayer(Guid id, CancellationToken ct)
        {
            try
            {
                var player = await api.GetPlayerAsync(id, ct);
                var linkedPlayer = ConvertPlayer(player);
                return Ok(linkedPlayer);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/items", Name = GetPlayerItemsRoute)]
        public async Task<ActionResult<IEnumerable<EquipmentItemDto>>> GetPlayerItems(Guid id, CancellationToken ct)
        {
            try
            {
                var items = await api.GetPlayerItemsAsync(id, ct);
                return Ok(items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/guns", Name = GetPlayerGunsRoute)]
        public async Task<ActionResult<IEnumerable<GunItemDto>>> GetPlayerGuns(Guid id, CancellationToken ct)
        {
            try
            {
                var items = await api.GetPlayerGunsAsync(id, ct);
                return Ok(items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/grenades", Name = GetPlayerGrenadesRoute)]
        public async Task<ActionResult<IEnumerable<GrenadeItemDto>>> GetPlayerGrenades(Guid id, CancellationToken ct)
        {
            try
            {
                var items = await api.GetPlayerGrenadesAsync(id, ct);
                return Ok(items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/shields", Name = GetPlayerShieldsRoute)]
        public async Task<ActionResult<IEnumerable<ShieldItemDto>>> GetPlayerShields(Guid id, CancellationToken ct)
        {
            try
            {
                var items = await api.GetPlayerShieldsAsync(id, ct);
                return Ok(items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/class_mods", Name = GetPlayerClassModsRoute)]
        public async Task<ActionResult<IEnumerable<ClassModItemDto>>> GetPlayerClassMods(Guid id, CancellationToken ct)
        {
            try
            {
                var items = await api.GetPlayerClassModsAsync(id, ct);
                return Ok(items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/relics", Name = GetPlayerRelicsRoute)]
        public async Task<ActionResult<IEnumerable<RelicItemDto>>> GetPlayerRelics(Guid id, CancellationToken ct)
        {
            try
            {
                var items = await api.GetPlayerRelicsAsync(id, ct);
                return Ok(items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region commands
        [HttpPost(Name = AddPlayerRoute)]
        public async Task<ActionResult<Guid>> AddPlayer(AddPlayerRequest player, CancellationToken ct)
        {
            try
            {
                var id = await api.AddPlayerAsync(player, ct);
                return CreatedAtRoute(
                    GetPlayerRoute,
                    new { id },
                    new { id });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/level/up", Name = LevelUpPlayerRoute)]
        public async Task<ActionResult> LevelUpPlayer(Guid id, CancellationToken ct)
        {
            try
            {
                await api.LevelUpPlayerAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/level/{level}", Name = SetPlayerLevelRoute)]
        public async Task<ActionResult> SetPlayerLevel(Guid id, int level, CancellationToken ct)
        {
            try
            {
                await api.SetPlayerLevelAsync(id, level, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/guns", Name = AddGunToPlayerRoute)]
        public async Task<ActionResult> AddGunToPlayer(Guid id, GunItemDto item, CancellationToken ct)
        {
            try
            {
                var createdId = await api.AddGunToPlayerAsync(id, item, ct);
                return CreatedAtRoute(
                    GunsController.GetGunRoute,
                    new { createdId },
                    new { createdId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/grenades", Name = AddGrenadeToPlayerRoute)]
        public async Task<ActionResult> AddGrenadeToPlayer(Guid id, GrenadeItemDto item, CancellationToken ct)
        {
            try
            {
                var createdId = await api.AddGrenadeToPlayerAsync(id, item, ct);
                return CreatedAtRoute(
                    GrenadesController.GetGrenadeRoute,
                    new { createdId },
                    new { createdId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/shields", Name = AddShieldToPlayerRoute)]
        public async Task<ActionResult> AddShieldToPlayer(Guid id, ShieldItemDto item, CancellationToken ct)
        {
            try
            {
                var createdId = await api.AddShieldToPlayerAsync(id, item, ct);
                return CreatedAtRoute(
                    ShieldsController.GetShieldRoute,
                    new { createdId },
                    new { createdId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/class_mods", Name = AddClassModToPlayerRoute)]
        public async Task<ActionResult> AddGunToPlayer(Guid id, ClassModItemDto item, CancellationToken ct)
        {
            try
            {
                var createdId = await api.AddClassModToPlayerAsync(id, item, ct);
                return CreatedAtRoute(
                    ClassModsController.GetClassModRoute,
                    new { createdId },
                    new { createdId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/relics", Name = AddRelicToPlayerRoute)]
        public async Task<ActionResult> AddRelicToPlayer(Guid id, RelicItemDto item, CancellationToken ct)
        {
            try
            {
                var createdId = await api.AddRelicToPlayerAsync(id, item, ct);
                return CreatedAtRoute(
                    RelicsController.GetRelicRoute,
                    new { createdId },
                    new { createdId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/skills/invest", Name = PlayerInvestInSkillRoute)]
        public async Task<ActionResult> PlayerInvestInSkill(Guid id, PlayerSkillDto investment, CancellationToken ct)
        {
            try
            {
                await api.PlayerInvestInSkillAsync(id, investment, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/skills/clear", Name = ClearPlayerSkillTreeRoute)]
        public async Task<ActionResult> ClearPlayerSkillTree(Guid id, CancellationToken ct)
        {
            try
            {
                await api.ClearPlayerSkillTreeAsync(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
