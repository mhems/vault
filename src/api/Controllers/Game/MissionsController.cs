using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionsController(IMissionApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetMissionsRoute = "GetMissions";
        internal const string GetMissionRoute = "GetMission";
        #endregion

        private readonly IMissionApi api = api;

        [HttpGet(Name = GetMissionsRoute)]
        public async Task<ActionResult<List<MissionResponse>>> GetMissions(CancellationToken ct)
        {
            var missions = await api.GetMissionsAsync(ct);
            var linkedMissions = missions.Select(ConvertMission).ToList();
            return Ok(linkedMissions);
        }

        [HttpGet("{id}", Name = GetMissionRoute)]
        public async Task<ActionResult<MissionResponse>> GetMission(Guid id, CancellationToken ct)
        {
            var lootPool = await api.GetMissionAsync(id, ct);
            var linkedMission = ConvertMission(lootPool);
            return Ok(linkedMission);
        }
    }
}
