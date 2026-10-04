namespace Vault.Domain
{
    public class RelicItem : EquipmentItem
    {
        private RelicItem() : base() { }

        public RelicItem(Player player,
            RelicModel model,
            byte? level,
            Rarity rarity,
            uint? buyPrice = null,
            uint? sellPrice = null) : base(player, model, level, rarity, buyPrice, sellPrice)
        {

        }
    }
}
