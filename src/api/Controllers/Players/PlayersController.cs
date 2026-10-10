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
        [ProducesResponseType(typeof(List<PlayerResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PlayerResponse>>> GetPlayers(
            Guid? accountId,
            string? @class,
            int? minLevel,
            CancellationToken ct)
        {
            var players = await api.GetPlayersAsync(
                accountId,
                @class,
                minLevel,
                ct);
            var linkedPlayers = players.Select(ConvertPlayer).ToList();
            return Ok(linkedPlayers);
        }

        [HttpGet("{id}", Name = GetPlayerRoute)]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerResponse>> GetPlayer(Guid id, CancellationToken ct)
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
        }

        [HttpGet("{id}/items", Name = GetPlayerItemsRoute)]
        [ProducesResponseType(typeof(List<EquipmentItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<EquipmentItemResponse>>> GetPlayerItems(Guid id, CancellationToken ct)
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
        }

        [HttpGet("{id}/guns", Name = GetPlayerGunsRoute)]
        [ProducesResponseType(typeof(List<GunResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<GunResponse>>> GetPlayerGuns(Guid id, CancellationToken ct)
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
        }

        [HttpGet("{id}/grenades", Name = GetPlayerGrenadesRoute)]
        [ProducesResponseType(typeof(List<GrenadeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetPlayerGrenades(Guid id, CancellationToken ct)
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
        }

        [HttpGet("{id}/shields", Name = GetPlayerShieldsRoute)]
        [ProducesResponseType(typeof(List<ShieldResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ShieldResponse>>> GetPlayerShields(Guid id, CancellationToken ct)
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
        }

        [HttpGet("{id}/class_mods", Name = GetPlayerClassModsRoute)]
        [ProducesResponseType(typeof(List<ClassModResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ClassModResponse>>> GetPlayerClassMods(Guid id, CancellationToken ct)
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
        }

        [HttpGet("{id}/relics", Name = GetPlayerRelicsRoute)]
        [ProducesResponseType(typeof(List<RelicResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<RelicResponse>>> GetPlayerRelics(Guid id, CancellationToken ct)
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
        }
        #endregion

        #region commands
        [HttpPost(Name = AddPlayerRoute)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        }

        [HttpPost("{id}/level/up", Name = LevelUpPlayerRoute)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddGunToPlayer(Guid id, AddGunRequest item, CancellationToken ct)
        {
            try
            {
                var dto = ConvertGun(item);
                var createdId = await api.AddGunToPlayerAsync(id, dto, ct);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddGrenadeToPlayer(Guid id, AddGrenadeRequest item, CancellationToken ct)
        {
            try
            {
                var dto = ConvertGrenade(item);
                var createdId = await api.AddGrenadeToPlayerAsync(id, dto, ct);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddShieldToPlayer(Guid id, AddShieldRequest item, CancellationToken ct)
        {
            try
            {
                var dto = ConvertShield(item);
                var createdId = await api.AddShieldToPlayerAsync(id, dto, ct);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddGunToPlayer(Guid id, AddClassModRequest item, CancellationToken ct)
        {
            try
            {
                var dto = ConvertClassMod(item);
                var createdId = await api.AddClassModToPlayerAsync(id, dto, ct);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddRelicToPlayer(Guid id, AddRelicRequest item, CancellationToken ct)
        {
            try
            {
                var dto = ConvertRelic(item);
                var createdId = await api.AddRelicToPlayerAsync(id, dto, ct);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PlayerInvestInSkill(Guid id, InvestPlayerSkillRequest investment, CancellationToken ct)
        {
            try
            {
                var dto = ConvertPlayerSkill(investment);
                await api.PlayerInvestInSkillAsync(id, dto, ct);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        }
        #endregion
    }
}
