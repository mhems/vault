namespace Vault.Domain
{
    public class Area : Location
    {
        public bool HasFastTravel { get; set; }
        public bool HasUTurn { get; set; }

        public Guid MapId { get; set; }
        public Map Map { get; set; }

        public Guid? LootPoolId { get; set; }
        public LootPool? LootPool { get; set; }

        private Area() : this(null!, null!) { }

        public Area(Map map, string name, Dlc dlc = Dlc.BaseGame) : base(name, dlc)
        {
            Map = map;
            MapId = map.Id;
        }
    }
}
