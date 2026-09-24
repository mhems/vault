using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController(IPlayerQueries queries): ControllerBase
    {
        private readonly IPlayerQueries queries = queries;

        [HttpGet]
        public ActionResult<IEnumerable<PlayerDto>> GetPlayers()
        {
            var players = queries.GetPlayersAsync(CancellationToken.None).Result;
            return Ok(players);
        }

        [HttpGet("{class}")]
        public ActionResult<IEnumerable<PlayerDto>> GetPlayersByClass(string @class)
        {
            var players = queries.GetPlayersByClassAsync(@class, CancellationToken.None).Result;
            return Ok(players);
        }
     }
}
