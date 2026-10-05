using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassModsController(IClassModApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetClassModsRoute = "GetClassMods";
        internal const string GetClassModsByPlayerRoute = "GetClassModsByPlayer";
        internal const string GetClassModsByModelRoute = "GetClassModsByModel";
        internal const string GetClassModsByRarityRoute = "GetClassModsByRarity";
        internal const string GetClassModsByLootDropRoute = "GetClassModsByLootDrop";
        internal const string GetClassModsByClassRoute = "GetClassModsByClass";
        internal const string GetClassModRoute = "GetClassMod";

        internal const string GetClassModsByManufacturerRoute = "GetClassModsByManufacturer";
        #endregion

        private readonly IClassModApi api = api;

        #region queries
        [HttpGet(Name = GetClassModsRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassMods(CancellationToken ct)
        {
            var classMods = await api.GetClassModsAsync(ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("by/player/{id}", Name = GetClassModsByPlayerRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassModsByPlayer(Guid id, CancellationToken ct)
        {
            var classMods = await api.GetClassModsByPlayerAsync(id, ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("by/model/{id}", Name = GetClassModsByModelRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassModsByModel(Guid id, CancellationToken ct)
        {
            var classMods = await api.GetClassModsByModelAsync(id, ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("by/rarity/{id}", Name = GetClassModsByRarityRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassModsByRarity(Guid id, CancellationToken ct)
        {
            var classMods = await api.GetClassModsByRarityAsync(id, ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("by/loot_drop/{id}", Name = GetClassModsByLootDropRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassModsByLootDrop(Guid id, CancellationToken ct)
        {
            var classMods = await api.GetClassModsByLootDropAsync(id, ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("by/class/{class}", Name = GetClassModsByClassRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassModsByType(string @class, CancellationToken ct)
        {
            var classMods = await api.GetClassModsByClassAsync(@class, ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("by/manufacturer/{manufacturer}", Name = GetClassModsByManufacturerRoute)]
        public async Task<ActionResult<List<ClassModControllerDto>>> GetClassModsByManufacturer(string manufacturer, CancellationToken ct)
        {
            var classMods = await api.GetClassModsByManufacturerAsync(manufacturer, ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("{id}", Name = GetClassModRoute)]
        public async Task<ActionResult<ClassModControllerDto>> GetClassMod(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetClassModAsync(id, ct);
                var linkedClassMod = ConvertClassMod(equipmentItem);
                return Ok(linkedClassMod);
            }
            catch (Exception ex) when (ex is KeyNotFoundException or ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
