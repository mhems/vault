using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentModelsController(IEquipmentModelApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetEquipmentModelsRoute = "GetEquipmentModels";
        internal const string GetEquipmentModelRoute = "GetEquipmentModel";
        #endregion

        private readonly IEquipmentModelApi api = api;

        #region queries
        [HttpGet(Name = GetEquipmentModelsRoute)]
        [ProducesResponseType(typeof(List<EquipmentModelResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EquipmentModelResponse>>> GetEquipmentModels(
            string? name,
            Equipment? category,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            Guid? raritySetId,
            Guid? elementSetId,
            string? canHaveRarity,
            string? canHaveElement,
            CancellationToken ct)
        {
            try
            {
                var equipmentModels = await api.GetEquipmentModelsAsync(
                name,
                category,
                subcategory,
                manufacturer,
                dlc,
                unique,
                raritySetId,
                elementSetId,
                canHaveRarity,
                canHaveElement,
                ct);
                var linkedEquipmentModels = equipmentModels.Select(ConvertEquipmentModel).ToList();
                return Ok(linkedEquipmentModels);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = GetEquipmentModelRoute)]
        [ProducesResponseType(typeof(EquipmentModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EquipmentModelResponse>> GetEquipmentModel(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentModel = await api.GetEquipmentModelAsync(id, ct);
                var linkedEquipmentModel = ConvertEquipmentModel(equipmentModel);
                return Ok(linkedEquipmentModel);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
