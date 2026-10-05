using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class GunsController(IGunApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetGunsRoute = "GetGuns";
        internal const string GetGunsByPlayerRoute = "GetGunsByPlayer";
        internal const string GetGunsByModelRoute = "GetGunsByModel";
        internal const string GetGunsByRarityRoute = "GetGunsByRarity";
        internal const string GetGunsByLootDropRoute = "GetGunsByLootDrop";
        internal const string GetGunsByElementRoute = "GetGunsByElement";
        internal const string GetGunsByTypeRoute = "GetGunsByType";
        internal const string GetGunRoute = "GetGun";

        internal const string GetGunsByManufacturerRoute = "GetGunsByManufacturer";
        #endregion

        private readonly IGunApi api = api;

        #region queries
        [HttpGet(Name = GetGunsRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGuns(CancellationToken ct)
        {
            var guns = await api.GetGunsAsync(ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/player/{id}", Name = GetGunsByPlayerRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByPlayer(Guid id, CancellationToken ct)
        {
            var guns = await api.GetGunsByPlayerAsync(id, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/model/{id}", Name = GetGunsByModelRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByModel(Guid id, CancellationToken ct)
        {
            var guns = await api.GetGunsByModelAsync(id, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/rarity/{id}", Name = GetGunsByRarityRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByRarity(Guid id, CancellationToken ct)
        {
            var guns = await api.GetGunsByRarityAsync(id, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/loot_drop/{id}", Name = GetGunsByLootDropRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByLootDrop(Guid id, CancellationToken ct)
        {
            var guns = await api.GetGunsByLootDropAsync(id, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/element/{element}", Name = GetGunsByElementRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByElement(string element, CancellationToken ct)
        {
            var guns = await api.GetGunsByElementAsync(element, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/type/{type}", Name = GetGunsByTypeRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByType(string type, CancellationToken ct)
        {
            var guns = await api.GetGunsByTypeAsync(type, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("by/manufacturer/{manufacturer}", Name = GetGunsByManufacturerRoute)]
        public async Task<ActionResult<List<GunControllerDto>>> GetGunsByManufacturer(string manufacturer, CancellationToken ct)
        {
            var guns = await api.GetGunsByManufacturerAsync(manufacturer, ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }


        [HttpGet("{id}", Name = GetGunRoute)]
        public async Task<ActionResult<GunControllerDto>> GetGun(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetGunAsync(id, ct);
                var linkedGun = ConvertGun(equipmentItem);
                return Ok(linkedGun);
            }
            catch (Exception ex) when (ex is KeyNotFoundException or ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
