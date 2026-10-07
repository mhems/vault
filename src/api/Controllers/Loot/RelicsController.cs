using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelicsController(IRelicApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetRelicsRoute = "GetRelics";
        internal const string GetRelicRoute = "GetRelic";

        #endregion

        private readonly IRelicApi api = api;

        #region queries
        [HttpGet(Name = GetRelicsRoute)]
        [ProducesResponseType(typeof(List<RelicResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RelicResponse>>> GetRelics(
            Guid? playerId,
            Guid? modelId,
            string? name,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            CancellationToken ct)
        {
            var relics = await api.GetRelicsAsync(
                playerId,
                modelId,
                name,
                subcategory,
                manufacturer,
                dlc,
                unique,
                rarity,
                ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("{id}", Name = GetRelicRoute)]
        [ProducesResponseType(typeof(RelicResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RelicResponse>> GetRelic(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetRelicAsync(id, ct);
                var linkedRelic = ConvertRelic(equipmentItem);
                return Ok(linkedRelic);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
