using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShieldsController(IShieldApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetShieldsRoute = "GetShields";
        internal const string GetShieldsByPlayerRoute = "GetShieldsByPlayer";
        internal const string GetShieldsByModelRoute = "GetShieldsByModel";
        internal const string GetShieldsByRarityRoute = "GetShieldsByRarity";
        internal const string GetShieldsByLootDropRoute = "GetShieldsByLootDrop";
        internal const string GetShieldsByElementRoute = "GetShieldsByElement";
        internal const string GetShieldsByTypeRoute = "GetShieldsByType";
        internal const string GetShieldRoute = "GetShield";

        internal const string GetShieldsByManufacturerRoute = "GetShieldsByManufacturer";
        #endregion

        private readonly IShieldApi api = api;

        #region queries
        [HttpGet(Name = GetShieldsRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShields(CancellationToken ct)
        {
            var shields = await api.GetShieldsAsync(ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("by/player/{id}", Name = GetShieldsByPlayerRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByPlayer(Guid id, CancellationToken ct)
        {
            var shields = await api.GetShieldsByPlayerAsync(id, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("by/model/{id}", Name = GetShieldsByModelRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByModel(Guid id, CancellationToken ct)
        {
            var shields = await api.GetShieldsByModelAsync(id, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("by/rarity/{id}", Name = GetShieldsByRarityRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByRarity(Guid id, CancellationToken ct)
        {
            var shields = await api.GetShieldsByRarityAsync(id, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("by/loot_drop/{id}", Name = GetShieldsByLootDropRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByLootDrop(Guid id, CancellationToken ct)
        {
            var shields = await api.GetShieldsByLootDropAsync(id, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("by/element/{element}", Name = GetShieldsByElementRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByElement(string element, CancellationToken ct)
        {
            var shields = await api.GetShieldsByElementAsync(element, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("by/type/{type}", Name = GetShieldsByTypeRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByType(string type, CancellationToken ct)
        {
            var shields = await api.GetShieldsByTypeAsync(type, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }



        [HttpGet("by/manufacturer/{manufacturer}", Name = GetShieldsByManufacturerRoute)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShieldsByManufacturer(string manufacturer, CancellationToken ct)
        {
            var shields = await api.GetShieldsByManufacturerAsync(manufacturer, ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("{id}", Name = GetShieldRoute)]
        public async Task<ActionResult<ShieldResponse>> GetShield(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetShieldAsync(id, ct);
                var linkedShield = ConvertShield(equipmentItem);
                return Ok(linkedShield);
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
