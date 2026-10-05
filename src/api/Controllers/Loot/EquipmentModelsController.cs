using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentModelsController(IEquipmentModelApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetEquipmentModelsRoute = "GetEquipmentModels";
        internal const string GetEquipmentModelsByCategoryRoute = "GetEquipmentModelsByCategory";
        internal const string GetEquipmentModelsByManufacturerRoute = "GetEquipmentModelsByManufacturer";
        internal const string GetEquipmentModelsByRaritySetRoute = "GetEquipmentModelsByRaritySet";
        internal const string GetEquipmentModelsByElementSetRoute = "GetEquipmentModelsByElementSet";
        internal const string GetEquipmentModelRoute = "GetEquipmentModel";
        #endregion

        private readonly IEquipmentModelApi api = api;

        #region queries
        [HttpGet(Name = GetEquipmentModelsRoute)]
        public async Task<ActionResult<List<EquipmentModelControllerDto>>> GetEquipmentModels(CancellationToken ct)
        {
            var equipmentModels = await api.GetEquipmentModelsAsync(ct);
            var linkedEquipmentModels = equipmentModels.Select(ConvertEquipmentModel).ToList();
            return Ok(linkedEquipmentModels);
        }

        [HttpGet("by/category/{category}", Name = GetEquipmentModelsByCategoryRoute)]
        public async Task<ActionResult<List<EquipmentModelControllerDto>>> GetEquipmentModelsByCategory(string category, CancellationToken ct)
        {
            var equipmentModels = await api.GetEquipmentModelsByCategoryAsync(category, ct);
            var linkedEquipmentModels = equipmentModels.Select(ConvertEquipmentModel).ToList();
            return Ok(linkedEquipmentModels);
        }

        [HttpGet("by/manufacturer/{manufacturer}", Name = GetEquipmentModelsByManufacturerRoute)]
        public async Task<ActionResult<List<EquipmentModelControllerDto>>> GetEquipmentModelsByManufacturer(string manufacturer, CancellationToken ct)
        {
            var equipmentModels = await api.GetEquipmentModelsByManufacturerAsync(manufacturer, ct);
            var linkedEquipmentModels = equipmentModels.Select(ConvertEquipmentModel).ToList();
            return Ok(linkedEquipmentModels);
        }

        [HttpGet("by/rarity_set/{id}", Name = GetEquipmentModelsByRaritySetRoute)]
        public async Task<ActionResult<List<EquipmentModelControllerDto>>> GetEquipmentModelsByRaritySet(Guid id, CancellationToken ct)
        {
            var equipmentModels = await api.GetEquipmentModelsByRaritySetAsync(id, ct);
            var linkedEquipmentModels = equipmentModels.Select(ConvertEquipmentModel).ToList();
            return Ok(linkedEquipmentModels);
        }

        [HttpGet("by/element_set/{id}", Name = GetEquipmentModelsByElementSetRoute)]
        public async Task<ActionResult<List<EquipmentModelControllerDto>>> GetEquipmentModelsByElementSet(Guid id, CancellationToken ct)
        {
            var equipmentModels = await api.GetEquipmentModelsByElementSetAsync(id, ct);
            var linkedEquipmentModels = equipmentModels.Select(ConvertEquipmentModel).ToList();
            return Ok(linkedEquipmentModels);
        }

        [HttpGet("{id}", Name = GetEquipmentModelRoute)]
        public async Task<ActionResult<EquipmentModelControllerDto>> GetEquipmentModel(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentModel = await api.GetEquipmentModelAsync(id, ct);
                var linkedEquipmentModel = ConvertEquipmentModel(equipmentModel);
                return Ok(linkedEquipmentModel);
            }
            catch (Exception ex) when (ex is KeyNotFoundException or ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
