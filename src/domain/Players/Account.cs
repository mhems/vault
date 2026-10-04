namespace Vault.Domain
{
    public class Account(string name)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = name;

        public List<Player> Players { get; set; } = [];

        public long? BadassRank { get; set; }

        public List<EquipmentItem> Stash { get; set; } = [];

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void TransferToStash(EquipmentItem item)
        {
            if (Stash.Count >= 4)
            {
                throw new InvalidOperationException("cannot stash more than 4 items");
            }
            Stash.Add(item);
        }
    }
}
