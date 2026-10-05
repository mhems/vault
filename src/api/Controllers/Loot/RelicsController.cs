using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelicsController(IRelicApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetRelicsRoute = "GetRelics";
        internal const string GetRelicsByPlayerRoute = "GetRelicsByPlayer";
        internal const string GetRelicsByModelRoute = "GetRelicsByModel";
        internal const string GetRelicsByRarityRoute = "GetRelicsByRarity";
        internal const string GetRelicsByLootDropRoute = "GetRelicsByLootDrop";
        internal const string GetRelicsByTypeRoute = "GetRelicsByType";
        internal const string GetRelicRoute = "GetRelic";

        internal const string GetRelicsByManufacturerRoute = "GetRelicsByManufacturer";
        #endregion

        private readonly IRelicApi api = api;

        #region queries
        [HttpGet(Name = GetRelicsRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelics(CancellationToken ct)
        {
            var relics = await api.GetRelicsAsync(ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("by/player/{id}", Name = GetRelicsByPlayerRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelicsByPlayer(Guid id, CancellationToken ct)
        {
            var relics = await api.GetRelicsByPlayerAsync(id, ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("by/model/{id}", Name = GetRelicsByModelRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelicsByModel(Guid id, CancellationToken ct)
        {
            var relics = await api.GetRelicsByModelAsync(id, ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("by/rarity/{id}", Name = GetRelicsByRarityRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelicsByRarity(Guid id, CancellationToken ct)
        {
            var relics = await api.GetRelicsByRarityAsync(id, ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("by/loot_drop/{id}", Name = GetRelicsByLootDropRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelicsByLootDrop(Guid id, CancellationToken ct)
        {
            var relics = await api.GetRelicsByLootDropAsync(id, ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("by/type/{type}", Name = GetRelicsByTypeRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelicsByType(string type, CancellationToken ct)
        {
            var relics = await api.GetRelicsByTypeAsync(type, ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }


        [HttpGet("by/manufacturer/{manufacturer}", Name = GetRelicsByManufacturerRoute)]
        public async Task<ActionResult<List<RelicControllerDto>>> GetRelicsByManufacturer(string manufacturer, CancellationToken ct)
        {
            var relics = await api.GetRelicsByManufacturerAsync(manufacturer, ct);
            var linkedRelics = relics.Select(ConvertRelic).ToList();
            return Ok(linkedRelics);
        }

        [HttpGet("{id}", Name = GetRelicRoute)]
        public async Task<ActionResult<RelicControllerDto>> GetRelic(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetRelicAsync(id, ct);
                var linkedRelic = ConvertRelic(equipmentItem);
                return Ok(linkedRelic);
            }
            catch (Exception ex) when (ex is KeyNotFoundException or ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
