namespace Vault.Domain
{
    public class LootPool
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<EquipmentModel> Models { get; set; } = [];
    }
}
