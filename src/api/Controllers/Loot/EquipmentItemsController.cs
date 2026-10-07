using Microsoft.AspNetCore.Mvc;
using Vault.Application;
using Vault.Domain;

namespace Vault.Api
{

    public class EquipmentItemsController(IEquipmentItemApi api, LinkGenerator links) : VaultController(links)
    {
        #region routes
        internal const string GetEquipmentItemsRoute = "GetEquipmentItems";
        internal const string GetEquipmentItemRoute = "GetEquipmentItem";
        #endregion

        private readonly IEquipmentItemApi api = api;

        #region queries
        [HttpGet(Name = GetEquipmentItemsRoute)]
        [ProducesResponseType(typeof(List<EquipmentItemResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EquipmentItemResponse>>> GetEquipmentItems(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Equipment? category,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            CancellationToken ct)
        {
            var equipmentItems = await api.GetEquipmentItemsAsync(
                playerId,
                modelId,
                name,
                category,
                subcategory,
                manufacturer,
                dlc,
                unique,
                rarity,
                ct);
            var linkedEquipmentItems = equipmentItems.Select(ConvertEquipmentItem).ToList();
            return Ok(linkedEquipmentItems);
        }



        [HttpGet("{id}", Name = GetEquipmentItemRoute)]
        [ProducesResponseType(typeof(EquipmentItemResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EquipmentItemResponse>> GetEquipmentItem(Guid id, CancellationToken ct)
        {
            try
            {
                var equipmentItem = await api.GetEquipmentItemAsync(id, ct);
                var linkedEquipmentItem = ConvertEquipmentItem(equipmentItem);
                return Ok(linkedEquipmentItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}
