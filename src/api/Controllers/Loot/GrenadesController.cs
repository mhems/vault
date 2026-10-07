using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrenadesController(IGrenadeApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetGrenadesRoute = "GetGrenades";
        internal const string GetGrenadeRoute = "GetGrenade";

        #endregion

        private readonly IGrenadeApi api = api;

        #region queries
        [HttpGet(Name = GetGrenadesRoute)]
        [ProducesResponseType(typeof(List<GrenadeResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GrenadeResponse>>> GetGrenades(
            Guid? playerId,
            Guid? modelId,
            string? name,
            GrenadeDelivery? delivery,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            string? element,
            bool? sticky,
            CancellationToken ct)
        {
            var grenades = await api.GetGrenadesAsync(
                playerId,
                modelId,
                name,
                delivery,
                manufacturer,
                dlc,
                unique,
                rarity,
                element,
                sticky,
                ct);
            var linkedGrenades = grenades.Select(ConvertGrenade).ToList();
            return Ok(linkedGrenades);
        }

        [HttpGet("{id}", Name = GetGrenadeRoute)]
        [ProducesResponseType(typeof(GrenadeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        }
        #endregion
    }
}
