using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController(IAreaApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetAreasRoute = "GetAreas";
        internal const string GetAreaRoute = "GetArea";
        #endregion

        private readonly IAreaApi api = api;

        [HttpGet(Name = GetAreasRoute)]
        [ProducesResponseType(typeof(List<AreaResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AreaResponse>>> GetAreas(
            Dlc? dlc,
            Guid? canSpawnCharacterId,
            bool? hasFastTravel,
            bool? hasUTurn,
            Guid? mapId,
            CancellationToken ct)
        {
            var areas = await api.GetAreasAsync(
                dlc,
                canSpawnCharacterId,
                hasFastTravel,
                hasUTurn,
                mapId,
                ct);
            var linkedAreas = areas.Select(ConvertArea).ToList();
            return Ok(linkedAreas);
        }

        [HttpGet("{id}", Name = GetAreaRoute)]
        [ProducesResponseType(typeof(AreaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AreaResponse>> GetArea(Guid id, CancellationToken ct)
        {
            try
            {
                var area = await api.GetAreaAsync(id, ct);
                var linkedArea = ConvertArea(area);
                return Ok(linkedArea);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
