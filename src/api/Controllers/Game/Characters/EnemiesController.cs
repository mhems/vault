using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnemiesController(IEnemyApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetEnemiesRoute = "GetEnemies";
        internal const string GetEnemyRoute = "GetEnemy";
        #endregion

        private readonly IEnemyApi api = api;

        [HttpGet(Name = GetEnemiesRoute)]
        public async Task<ActionResult<List<EnemyResponse>>> GetEnemies(CancellationToken ct)
        {
            var enemies = await api.GetEnemiesAsync(ct);
            var linkedEnemies = enemies.Select(ConvertEnemy).ToList();
            return Ok(linkedEnemies);
        }

        [HttpGet("{id}", Name = GetEnemyRoute)]
        public async Task<ActionResult<EnemyResponse>> GetEnemy(Guid id, CancellationToken ct)
        {
            var enemy = await api.GetEnemyAsync(id, ct);
            var linkedEnemy = ConvertEnemy(enemy);
            return Ok(linkedEnemy);
        }
    }
}
