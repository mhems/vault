using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassModsController(IClassModApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetClassModsRoute = "GetClassMods";
        internal const string GetClassModRoute = "GetClassMod";
        #endregion

        private readonly IClassModApi api = api;

        #region queries
        [HttpGet(Name = GetClassModsRoute)]
        [ProducesResponseType(typeof(List<ClassModResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClassModResponse>>> GetClassMods(
            Guid? playerId,
            Guid? modelId,
            string? name,
            string? @class,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            Guid? skillId,
            CancellationToken ct)
        {
            var classMods = await api.GetClassModsAsync(
                playerId,
                modelId,
                name,
                @class,
                manufacturer,
                dlc,
                unique,
                rarity,
                skillId,
                ct);
            var linkedClassMods = classMods.Select(ConvertClassMod).ToList();
            return Ok(linkedClassMods);
        }

        [HttpGet("{id}", Name = GetClassModRoute)]
        [ProducesResponseType(typeof(ClassModResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClassModResponse>> GetClassMod(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetClassModAsync(id, ct);
                var linkedClassMod = ConvertClassMod(equipmentItem);
                return Ok(linkedClassMod);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
