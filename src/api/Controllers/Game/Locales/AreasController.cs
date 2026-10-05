using Microsoft.AspNetCore.Mvc;
using Vault.Application;

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
        public async Task<ActionResult<List<AreaControllerDto>>> GetAreas(CancellationToken ct)
        {
            var areas = await api.GetAreasAsync(ct);
            var linkedAreas = areas.Select(ConvertArea).ToList();
            return Ok(linkedAreas);
        }

        [HttpGet("{id}", Name = GetAreaRoute)]
        public async Task<ActionResult<AreaControllerDto>> GetArea(Guid id, CancellationToken ct)
        {
            var area = await api.GetAreaAsync(id, ct);
            var linkedArea = ConvertArea(area);
            return Ok(linkedArea);
        }
    }
}
