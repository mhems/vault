using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController(ISkillApi api, LinkGenerator links) : VaultController(links)
    {
        #region route names
        internal const string GetSkillsRoute = "GetSkills";
        internal const string GetSkillRoute = "GetSkill";
        #endregion

        private readonly ISkillApi api = api;

        #region queries
        [HttpGet(Name = GetSkillsRoute)]
        [ProducesResponseType(typeof(List<SkillResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SkillResponse>>> GetSkills(
            string? @class,
            CancellationToken ct)
        {
            var skills = await api.GetSkillsAsync(@class, ct);
            var linkedSkills = skills.Select(ConvertSkill).ToList();
            return Ok(linkedSkills);
        }

        [HttpGet("{id}", Name = GetSkillRoute)]
        [ProducesResponseType(typeof(SkillResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SkillResponse>> GetSkill(Guid id, CancellationToken ct)
        {
            try
            {
                var skill = await api.GetSkillAsync(id, ct);
                var linkedSkill = ConvertSkill(skill);
                return Ok(linkedSkill);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        #endregion


    }
}
