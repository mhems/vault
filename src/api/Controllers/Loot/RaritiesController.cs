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
        public async Task<ActionResult<IEnumerable<RarityDto>>> GetRarities(CancellationToken ct)
        {
            var Rarities = await api.GetRaritiesAsync(ct);
            var linkedRarities = Rarities.Select(ConvertRarity).ToList();
            return Ok(linkedRarities);
        }

        [HttpGet("{id}", Name = GetRarityRoute)]
        public async Task<ActionResult<RarityDto>> GetRarity(Guid id, CancellationToken ct)
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
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
