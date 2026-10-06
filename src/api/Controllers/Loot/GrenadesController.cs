using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrenadesController(IGrenadeApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetGrenadesRoute = "GetGrenades";
        internal const string GetGrenadesByPlayerRoute = "GetGrenadesByPlayer";
        internal const string GetGrenadesByModelRoute = "GetGrenadesByModel";
        internal const string GetGrenadesByRarityRoute = "GetGrenadesByRarity";
        internal const string GetGrenadesByLootDropRoute = "GetGrenadesByLootDrop";
        internal const string GetGrenadesByElementRoute = "GetGrenadesByElement";
        internal const string GetGrenadesByDeliveryRoute = "GetGrenadesByDelivery";
        internal const string GetGrenadeRoute = "GetGrenade";

        internal const string GetGrenadesByManufacturerRoute = "GetGrenadesByManufacturer";
        #endregion

        private readonly IGrenadeApi api = api;

        #region queries
        [HttpGet(Name = GetGrenadesRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenades(CancellationToken ct)
        {
            var grenades = await api.GetGrenadesAsync(ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("by/player/{id}", Name = GetGrenadesByPlayerRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByPlayer(Guid id, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByPlayerAsync(id, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("by/model/{id}", Name = GetGrenadesByModelRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByModel(Guid id, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByModelAsync(id, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("by/rarity/{id}", Name = GetGrenadesByRarityRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByRarity(Guid id, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByRarityAsync(id, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("by/loot_drop/{id}", Name = GetGrenadesByLootDropRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByLootDrop(Guid id, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByLootDropAsync(id, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("by/element/{element}", Name = GetGrenadesByElementRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByElement(string element, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByElementAsync(element, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("by/delivery/{delivery}", Name = GetGrenadesByDeliveryRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByType(string delivery, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByDeliveryAsync(delivery, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }



        [HttpGet("by/manufacturer/{manufacturer}", Name = GetGrenadesByManufacturerRoute)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenadesByManufacturer(string manufacturer, CancellationToken ct)
        {
            var grenades = await api.GetGrenadesByManufacturerAsync(manufacturer, ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("{id}", Name = GetGrenadeRoute)]
        public async Task<ActionResult<GrenadeResponse>> GetGrenade(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetGrenadeAsync(id, ct);
                var linkedGrenade = ConvertGrenade(equipmentItem);
                return Ok(linkedGrenade);
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
