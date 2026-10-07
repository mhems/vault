using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaritiesController(IRarityApi api, LinkGenerator links) : VaultController(links)
    {
        #region route names
        internal const string GetRaritiesRoute = "GetRarities";
        internal const string GetRarityRoute = "GetRarity";
        #endregion

        private readonly IRarityApi api = api;

        #region queries
        [HttpGet(Name = GetRaritiesRoute)]
        [ProducesResponseType(typeof(List<RarityResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RarityResponse>>> GetRarities(CancellationToken ct)
        {
            var Rarities = await api.GetRaritiesAsync(ct);
            var linkedRarities = Rarities.Select(ConvertRarity).ToList();
            return Ok(linkedRarities);
        }

        [HttpGet("{id}", Name = GetRarityRoute)]
        [ProducesResponseType(typeof(RarityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RarityResponse>> GetRarity(Guid id, CancellationToken ct)
        {
            try
            {
                var Rarity = await api.GetRarityAsync(id, ct);
                var linkedRarity = ConvertRarity(Rarity);
                return Ok(linkedRarity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion
    }
}
