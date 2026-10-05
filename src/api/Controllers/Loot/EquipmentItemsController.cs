using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{

    public class EquipmentItemsController(IEquipmentItemApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetEquipmentItemsRoute = "GetEquipmentItems";
        internal const string GetEquipmentItemsByPlayerRoute = "GetEquipmentItemsByPlayer";
        internal const string GetEquipmentItemsByModelRoute = "GetEquipmentItemsByModel";
        internal const string GetEquipmentItemsByRarityRoute = "GetEquipmentItemsByRarity";
        internal const string GetEquipmentItemsByLootDropRoute = "GetEquipmentItemsByLootDrop";
        internal const string GetEquipmentItemRoute = "GetEquipmentItem";

        internal const string GetEquipmentItemsByCategoryRoute = "GetEquipmentItemsByCategory";
        internal const string GetEquipmentItemsByManufacturerRoute = "GetEquipmentItemsByManufacturer";
        internal const string GetEquipmentItemsByRaritySetRoute = "GetEquipmentItemsByRaritySet";
        internal const string GetEquipmentItemsByElementSetRoute = "GetEquipmentItemsByElementSet";
        #endregion

        private readonly IEquipmentItemApi api = api;

        #region queries
        [HttpGet(Name = GetEquipmentItemsRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItems(CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsAsync(ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }

        [HttpGet("by/player/{id}", Name = GetEquipmentItemsByPlayerRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItemsByPlayer(Guid id, CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsByPlayerAsync(id, ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }

        [HttpGet("by/model/{id}", Name = GetEquipmentItemsByModelRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItemsByModel(Guid id, CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsByModelAsync(id, ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }

        [HttpGet("by/rarity/{id}", Name = GetEquipmentItemsByRarityRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItemsByRarity(Guid id, CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsByRarityAsync(id, ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }

        [HttpGet("by/loot_drop/{id}", Name = GetEquipmentItemsByLootDropRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItemsByLootDrop(Guid id, CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsByLootDropAsync(id, ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }



        [HttpGet("by/category/{category}", Name = GetEquipmentItemsByCategoryRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItemsByCategory(string category, CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsByCategoryAsync(category, ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }

        [HttpGet("by/manufacturer/{manufacturer}", Name = GetEquipmentItemsByManufacturerRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItemsByManufacturer(string manufacturer, CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsByManufacturerAsync(manufacturer, ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }

        [HttpGet("{id}", Name = GetEquipmentItemRoute)]
        public async Task<ActionResult<List<EquipmentItemControllerDto>>> GetEquipmentItem(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetEquipmentItemAsync(id, ct);
                var linkedEquipmentItem = ConvertEquipmentItem(equipmentItem);
                return Ok(linkedEquipmentItem);
            }
            catch (Exception ex) when (ex is KeyNotFoundException or ArgumentException)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
