using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapsController(IMapApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetMapsRoute = "GetMaps";
        internal const string GetMapRoute = "GetMap";
        #endregion

        private readonly IMapApi api = api;

        [HttpGet(Name = GetMapsRoute)]
        [ProducesResponseType(typeof(List<MapResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MapResponse>>> GetMaps(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            bool? hasFastTravel,
            bool? hasMultipleConnections,
            CancellationToken ct)
        {
            var maps = await api.GetMapsAsync(
                dlc,
                canSpawnCharacterId,
                hasFastTravel,
                hasMultipleConnections,
                ct);
            var linkedMaps = maps.Select(ConvertMap).ToList();
            return Ok(linkedMaps);
        }

        [HttpGet("{id}", Name = GetMapRoute)]
        [ProducesResponseType(typeof(MapResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MapResponse>> GetMap(Guid id, CancellationToken ct)
        {
            try
            {
                var map = await api.GetMapAsync(id, ct);
                var linkedMap = ConvertMap(map);
                return Ok(linkedMap);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
