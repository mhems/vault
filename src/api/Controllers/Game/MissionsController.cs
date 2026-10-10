using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

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
        [ProducesResponseType(typeof(List<MissionResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MissionResponse>>> GetMissions(
            Dlc? dlc,
            bool? storyMission,
            bool? hasMissionItem,
            Guid? startAreaId,
            CancellationToken ct)
        {
            var missions = await api.GetMissionsAsync(
                dlc,
                storyMission,
                hasMissionItem,
                startAreaId,
                ct);
            var linkedMissions = missions.Select(ConvertMission).ToList();
            return Ok(linkedMissions);
        }

        [HttpGet("{id}", Name = GetMissionRoute)]
        [ProducesResponseType(typeof(MissionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MissionResponse>> GetMission(Guid id, CancellationToken ct)
        {
            try
            {
                var lootPool = await api.GetMissionAsync(id, ct);
                var linkedMission = ConvertMission(lootPool);
                return Ok(linkedMission);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
