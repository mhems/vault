namespace Vault.Domain
{
    public class UniqueEnemy : Enemy
    {
        public bool Boss { get; set; }
        public bool RaidBoss { get; set; }

        private UniqueEnemy(string species, string name) : this(species, name, null!) { }

        public UniqueEnemy(string species, string name, Area spawnSite,
            bool boss = false, bool raidBoss = false) : base(name, species, true)
        {
            Locations.Add(spawnSite);
            Boss = boss || raidBoss;
            RaidBoss = raidBoss;
        }
    }
}
