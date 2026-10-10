using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

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
        public async Task<ActionResult<List<UniqueEnemyResponse>>> GetUniqueEnemies(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            bool? hasShield,
            string? weakToElement,
            string? resistsElement,
            string? immuneToElement,
            Guid? canDropModelId,
            bool? boss,
            bool? raidBoss,
            CancellationToken ct)
        {
            var enemies = await api.GetUniqueEnemiesAsync(
                dlc,
                species,
                affiliation,
                spawnLocationId,
                hasShield,
                weakToElement,
                resistsElement,
                immuneToElement,
                canDropModelId,
                boss,
                raidBoss,
                ct);
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
