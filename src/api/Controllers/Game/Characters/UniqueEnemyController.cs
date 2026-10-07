using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniqueEnemiesController(IUniqueEnemyApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetUniqueEnemiesRoute = "GetUniqueEnemies";
        internal const string GetUniqueEnemyRoute = "GetUniqueEnemy";
        #endregion

        private readonly IUniqueEnemyApi api = api;

        [HttpGet(Name = GetUniqueEnemiesRoute)]
        [ProducesResponseType(typeof(List<UniqueEnemyResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UniqueEnemyResponse>>> GetUniqueEnemies(CancellationToken ct)
        {
            var enemies = await api.GetUniqueEnemiesAsync(ct);
            var linkedUniqueEnemies = enemies.Select(ConvertUniqueEnemy).ToList();
            return Ok(linkedUniqueEnemies);
        }

        [HttpGet("{id}", Name = GetUniqueEnemyRoute)]
        [ProducesResponseType(typeof(UniqueEnemyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UniqueEnemyResponse>> GetUniqueEnemy(Guid id, CancellationToken ct)
        {
            try
            {
                var enemy = await api.GetUniqueEnemyAsync(id, ct);
                var linkedUniqueEnemy = ConvertUniqueEnemy(enemy);
                return Ok(linkedUniqueEnemy);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
