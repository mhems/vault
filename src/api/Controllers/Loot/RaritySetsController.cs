using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaritySetsController(IRaritySetApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetRaritySetsRoute = "GetRaritySetsRoute";
        internal const string GetRaritySetRoute = "GetRaritySetRoute";
        #endregion

        private readonly IRaritySetApi api = api;

        [HttpGet(Name = GetRaritySetsRoute)]
        [ProducesResponseType(typeof(List<RaritySetResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RaritySetResponse>>> GetRaritySets(CancellationToken ct)
        {
            var raritySets = await api.GetRaritySetsAsync(ct);
            var linkedSets = raritySets.Select(ConvertRaritySet).ToList();
            return Ok(linkedSets);
        }

        [HttpGet("{id}", Name = GetRaritySetRoute)]
        [ProducesResponseType(typeof(RaritySetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RaritySetResponse>> GetRaritySet(Guid id, CancellationToken ct)
        {
            try
            {
                var raritySet = await api.GetRaritySetAsync(id, ct);
                var linkedSet = ConvertRaritySet(raritySet);
                return Ok(linkedSet);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
