using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerClassesController(IPlayerClassApi api, LinkGenerator links) : VaultController(links)
    {
        #region route names
        internal const string GetPlayerClassesRoute = "GetPlayerClasses";
        internal const string GetPlayerClassRoute = "GetPlayerClass";
        #endregion

        private readonly IPlayerClassApi api = api;

        #region queries
        [HttpGet(Name = GetPlayerClassesRoute)]
        public async Task<ActionResult<IEnumerable<PlayerClassDto>>> GetPlayerClasses(CancellationToken ct)
        {
            var classes = await api.GetPlayerClassesAsync(ct);
            var linkedClasses = classes.Select(ConvertPlayerClass).ToList();
            return Ok(linkedClasses);
        }

        [HttpGet("{id}", Name = GetPlayerClassRoute)]
        public async Task<ActionResult<PlayerClassDto>> GetPlayerClass(Guid id, CancellationToken ct)
        {
            try
            {
                var @class = await api.GetPlayerClassAsync(id, ct);
                var linkedClass = ConvertPlayerClass(@class);
                return Ok(linkedClass);
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
