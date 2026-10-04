using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    public class SkillsController(ISkillApi api, LinkGenerator links) : VaultController(links)
    {
        #region route names
        internal const string GetSkillsRoute = "GetSkills";
        internal const string GetSkillsByClassRoute = "GetSkillsByClass";
        internal const string GetSkillRoute = "GetSkill";
        #endregion

        private readonly ISkillApi api = api;

        #region queries
        [HttpGet(Name = GetSkillsRoute)]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSKills(CancellationToken ct)
        {
            var skills = await api.GetSkillsAsync(ct);
            var linkedSkills = skills.Select(ConvertSkill).ToList();
            return Ok(linkedSkills);
        }

        [HttpGet("by/class/{class}", Name = GetSkillsByClassRoute)]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkillsByPlayerClass(string @class, CancellationToken ct)
        {
            var skills = await api.GetSkillsByPlayerClassAsync(@class, ct);
            var linkedSkills = skills.Select(ConvertSkill).ToList();
            return Ok(linkedSkills);
        }

        [HttpGet("{id}", Name = GetSkillRoute)]
        public async Task<ActionResult<SkillDto>> GetSkill(Guid id, CancellationToken ct)
        {
            try
            {
                var skill = await api.GetSkillAsync(id, ct);
                var linkedSkill = ConvertSkill(skill);
                return Ok(linkedSkill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException or ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion


    }
}
