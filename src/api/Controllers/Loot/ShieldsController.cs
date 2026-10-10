using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShieldsController(IShieldApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetShieldsRoute = "GetShields";
        internal const string GetShieldRoute = "GetShield";

        #endregion

        private readonly IShieldApi api = api;

        #region queries
        [HttpGet(Name = GetShieldsRoute)]
        [ProducesResponseType(typeof(List<ShieldResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ShieldResponse>>> GetShields(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Shield? category,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            string? element,
            int? minRechargeRatePercent,
            int? maxRechargeRatePercent,
            double? minRechargeDelay,
            double? maxRechargeDelay,
            string? prefix,
            Element? immunity,
            Element? reduction,
            Manufacturer? battery,
            Manufacturer? capacitor,
            Manufacturer? body,
            CancellationToken ct)
        {
            var shields = await api.GetShieldsAsync(
                playerId,
                modelId,
                name,
                category,
                manufacturer,
                dlc,
                minLevel,
                maxLevel,
                unique,
                rarity,
                element,
                minRechargeRatePercent,
                maxRechargeRatePercent,
                minRechargeDelay,
                maxRechargeDelay,
                prefix,
                immunity,
                reduction,
                battery,
                capacitor,
                body,
                ct);
            var linkedShields = shields.Select(ConvertShield).ToList();
            return Ok(linkedShields);
        }

        [HttpGet("{id}", Name = GetShieldRoute)]
        [ProducesResponseType(typeof(ShieldResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        }
        #endregion
    }
}
