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
        internal const string GetLootPoolsByMembershipRoute = "GetLootPoolsByMembership";
        internal const string GetLootPoolRoute = "GetLootPool";
        #endregion

        private readonly ILootPoolApi api = api;

        [HttpGet(Name = GetLootPoolsRoute)]
        public async Task<ActionResult<List<LootPoolControllerDto>>> GetLootPools(CancellationToken ct)
        {
            var lootPools = await api.GetLootPoolsAsync(ct);
            var linkedLootPools = lootPools.Select(ConvertLootPool).ToList();
            return Ok(linkedLootPools);
        }

        [HttpGet("contains/{id}", Name = GetLootPoolsByMembershipRoute)]
        public async Task<ActionResult<List<LootPoolControllerDto>>> GetLootPoolsByMembership(Guid id, CancellationToken ct)
        {
            var lootPools = await api.GetLootPoolsByMembershipAsync(id, ct);
            var linkedLootPools = lootPools.Select(ConvertLootPool).ToList();
            return Ok(linkedLootPools);
        }

        [HttpGet("{id}", Name = GetLootPoolRoute)]
        public async Task<ActionResult<LootPoolControllerDto>> GetLootPool(Guid id, CancellationToken ct)
        {
            var lootPool = await api.GetLootPoolAsync(id, ct);
            var linkedLootPool = ConvertLootPool(lootPool);
            return Ok(linkedLootPool);
        }
    }
}
