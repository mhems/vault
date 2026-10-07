using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementSetsController(IElementSetApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetElementSetsRoute = "GetElementSetsRoute";
        internal const string GetElementSetRoute = "GetElementSetRoute";
        #endregion

        private readonly IElementSetApi api = api;

        [HttpGet(Name = GetElementSetsRoute)]
        [ProducesResponseType(typeof(List<ElementSetResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ElementSetResponse>>> GetElementSets(CancellationToken ct)
        {
            var raritySets = await api.GetElementSetsAsync(ct);
            var linkedSets = raritySets.Select(ConvertElementSet).ToList();
            return Ok(linkedSets);
        }

        [HttpGet("{id}", Name = GetElementSetRoute)]
        [ProducesResponseType(typeof(ElementSetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ElementSetResponse>> GetElementSet(Guid id, CancellationToken ct)
        {
            try
            {
                var raritySet = await api.GetElementSetAsync(id, ct);
                var linkedSet = ConvertElementSet(raritySet);
                return Ok(linkedSet);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
