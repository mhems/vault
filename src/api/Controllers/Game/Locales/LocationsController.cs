using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController(ILocationApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetLocationsRoute = "GetLocations";
        internal const string GetLocationRoute = "GetLocation";
        #endregion

        private readonly ILocationApi api = api;

        [HttpGet(Name = GetLocationsRoute)]
        public async Task<ActionResult<List<LocationControllerDto>>> GetLocations(CancellationToken ct)
        {
            var maps = await api.GetLocationsAsync(ct);
            var linkedLocations = maps.Select(ConvertLocation).ToList();
            return Ok(linkedLocations);
        }

        [HttpGet("{id}", Name = GetLocationRoute)]
        public async Task<ActionResult<LocationControllerDto>> GetLocation(Guid id, CancellationToken ct)
        {
            var map = await api.GetLocationAsync(id, ct);
            var linkedLocation = ConvertLocation(map);
            return Ok(linkedLocation);
        }
    }
}
