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
        [ProducesResponseType(typeof(List<LocationResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LocationResponse>>> GetLocations(CancellationToken ct)
        {
            var maps = await api.GetLocationsAsync(ct);
            var linkedLocations = maps.Select(ConvertLocation).ToList();
            return Ok(linkedLocations);
        }

        [HttpGet("{id}", Name = GetLocationRoute)]
        [ProducesResponseType(typeof(LocationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationResponse>> GetLocation(Guid id, CancellationToken ct)
        {
            try
            {
                var map = await api.GetLocationAsync(id, ct);
                var linkedLocation = ConvertLocation(map);
                return Ok(linkedLocation);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
