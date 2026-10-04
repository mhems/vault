namespace Vault.Domain
{
    public abstract class EquipmentItem
    {
        public Guid Id { get; protected init; } = Guid.NewGuid();

        public Guid ModelId { get; protected set; }
        public EquipmentModel Model { get; protected set; }

        public byte? Level { get; protected init; }

        public Guid RarityId { get; protected set; }
        public Rarity Rarity { get; protected init; }

        public uint? BuyPrice { get; protected init; }
        public uint? SellPrice { get; protected init; }

        public Guid PlayerId { get; protected set; }
        public Player Player { get; protected init; }

        public Guid? DropId { get; set; }
        public LootDrop? Drop { get; init; }

        public List<Effect> Effects { get; set; } = [];

        protected EquipmentItem() { }

        public EquipmentItem(Player player,
            EquipmentModel model,
            byte? level,
            Rarity rarity,
            uint? buyPrice = null,
            uint? sellPrice = null)
        {
            Player = player;
            PlayerId = player.Id;
            Model = model;
            ModelId = model.Id;
            Level = level;
            Rarity = rarity;
            RarityId = rarity.Id;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
        }

        public void AddEffect(Effect effect)
        {
            Effects.Add(effect);
        }
    }

    public sealed record ElementalDamage(Element Element, double DamagePerSecond);

    public sealed record Effect(string Description, double? Amount = null, string? Units = null);

    public class LootDrop
    {
        public bool Specified { get; set; } = false;

        public Guid? MissionId { get; private set; }
        public Mission? Mission { get; private set; }

        public Guid? AreaId { get; private set; }
        public Area? Area { get; private set; }

        public Guid? EnemyId { get; private set; }
        public Enemy? Enemy { get; private set; }

        public void SetMissionSource(Mission mission)
        {
            MissionId = mission.Id;
            Mission = mission;
            Specified = true;
        }

        public void SetAreaSource(Area area)
        {
            AreaId = area.Id;
            Area = area;
            Specified = true;
        }

        public void SetEnemySource(Enemy enemy)
        {
            EnemyId = enemy.Id;
            Enemy = enemy;
            Specified = true;
        }
    }
}
