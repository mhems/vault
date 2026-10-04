namespace Vault.Domain
{
    public class Map : Location
    {
        public int NumFastTravels { get; set; }

        public List<Area> Areas { get; set; } = [];

        public List<Map> ConnectionsIn { get; set; } = [];
        public List<Map> ConnectionsOut { get; set; } = [];

        public Map(string name, Dlc dlc = Dlc.BaseGame) : base(name, dlc)
        {

        }
    }
}
