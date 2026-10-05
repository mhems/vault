namespace Vault.Domain
{
    public class Mission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Dlc Dlc { get; set; }
        public bool StoryMission { get; set; }

        public Guid StartAreaId { get; set; }
        public Area StartArea { get; set; } = null!;

        public Guid EndAreaId { get; set; }
        public Area EndArea { get; set; } = null!;

        public Guid? MissionGiverId { get; set; }
        public NonPlayableCharacter? MissionGiver { get; set; }
        public Guid? MissionRewarderId { get; set; }
        public NonPlayableCharacter? MissionRewarder { get; set; }

        public Guid? MissionItemId { get; set; }
        public EquipmentModel? MissionItem { get; set; }

        public Guid? LootPoolId { get; set; }
        public LootPool? LootPool { get; set; }

        public List<Map> Maps { get; set; } = [];

        public List<Mission> Predecessors { get; set; } = [];
        public List<Mission> Successors { get; set; } = [];

        private Mission() { }

        public Mission(string name, Area start, Area end, Dlc dlc = Dlc.BaseGame)
        {
            Name = name;
            StartArea = start;
            EndArea = end;
            Dlc = dlc;
        }
    }
}
