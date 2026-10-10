using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

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
        [ProducesResponseType(typeof(List<EnemyResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EnemyResponse>>> GetEnemies(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            bool? hasShield,
            string? weakToElement,
            string? resistsElement,
            string? immuneToElement,
            Guid? canDropModelId,
            CancellationToken ct)
        {
            var enemies = await api.GetEnemiesAsync(
                dlc,
                species,
                affiliation,
                spawnLocationId,
                hasShield,
                weakToElement,
                resistsElement,
                immuneToElement,
                canDropModelId,
                ct);
            var linkedEnemies = enemies.Select(ConvertEnemy).ToList();
            return Ok(linkedEnemies);
        }

        [HttpGet("{id}", Name = GetEnemyRoute)]
        [ProducesResponseType(typeof(EnemyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnemyResponse>> GetEnemy(Guid id, CancellationToken ct)
        {
            try
            {
                var enemy = await api.GetEnemyAsync(id, ct);
                var linkedEnemy = ConvertEnemy(enemy);
                return Ok(linkedEnemy);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
