using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LootPoolsController(ILootPoolApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetLootPoolsRoute = "GetLootPools";
        internal const string GetLootPoolRoute = "GetLootPool";
        #endregion

        private readonly ILootPoolApi api = api;

        [HttpGet(Name = GetLootPoolsRoute)]
        [ProducesResponseType(typeof(List<LootPoolResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LootPoolResponse>>> GetLootPools(
            Guid? modelId,
            CancellationToken ct)
        {
            var lootPools = await api.GetLootPoolsAsync(modelId, ct);
            var linkedLootPools = lootPools.Select(ConvertLootPool).ToList();
            return Ok(linkedLootPools);
        }


        [HttpGet("{id}", Name = GetLootPoolRoute)]
        [ProducesResponseType(typeof(LootPoolResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LootPoolResponse>> GetLootPool(Guid id, CancellationToken ct)
        {
            try
            {
                var lootPool = await api.GetLootPoolAsync(id, ct);
                var linkedLootPool = ConvertLootPool(lootPool);
                return Ok(linkedLootPool);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
