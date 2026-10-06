using Microsoft.AspNetCore.Mvc;
using Vault.Application;

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
        public async Task<ActionResult<List<MapResponse>>> GetMaps(CancellationToken ct)
        {
            var maps = await api.GetMapsAsync(ct);
            var linkedMaps = maps.Select(ConvertMap).ToList();
            return Ok(linkedMaps);
        }

        [HttpGet("{id}", Name = GetMapRoute)]
        public async Task<ActionResult<MapResponse>> GetMap(Guid id, CancellationToken ct)
        {
            var map = await api.GetMapAsync(id, ct);
            var linkedMap = ConvertMap(map);
            return Ok(linkedMap);
        }
    }
}
