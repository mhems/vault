using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class GunsController(IGunApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetGunsRoute = "GetGuns";
        internal const string GetGunRoute = "GetGun";

        #endregion

        private readonly IGunApi api = api;

        #region queries
        [HttpGet(Name = GetGunsRoute)]
        [ProducesResponseType(typeof(List<GunResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GunResponse>>> GetGuns(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Gun? category,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            string? element,
            double? minElementalEffectChance,
            string? prefix,
            bool? missionItem,
            double? minAccuracy,
            double? minFireRate,
            int? minMagazineSize,
            int? maxMagazineSize,
            Manufacturer? barrel,
            Manufacturer? stock,
            Manufacturer? grip,
            Manufacturer? scope,
            Manufacturer? body,
            CancellationToken ct)
        {
            var guns = await api.GetGunsAsync(
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
                minElementalEffectChance,
                prefix,
                missionItem,
                minAccuracy,
                minFireRate,
                minMagazineSize,
                maxMagazineSize,
                barrel,
                stock,
                grip,
                scope,
                body,
                ct);
            var linkedGuns = guns.Select(ConvertGun).ToList();
            return Ok(linkedGuns);
        }

        [HttpGet("{id}", Name = GetGunRoute)]
        [ProducesResponseType(typeof(GunResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GunResponse>> GetGun(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetGunAsync(id, ct);
                var linkedGun = ConvertGun(equipmentItem);
                return Ok(linkedGun);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
