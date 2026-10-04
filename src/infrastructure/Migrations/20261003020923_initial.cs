using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vault.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    BadassRank = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true, collation: "NOCASE"),
                    Category = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    SubCategory = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    Manufacturer = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    Dlc = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Unique = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlavorText = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Dlc = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LootPools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LootPools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonPlayableCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    Dlc = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Level = table.Column<byte>(type: "INTEGER", nullable: true),
                    Species = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    SubSpecies = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    Affiliation = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    Enemy = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonPlayableCharacters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    Dlc = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    ColorName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    Red = table.Column<byte>(type: "INTEGER", nullable: false),
                    Green = table.Column<byte>(type: "INTEGER", nullable: false),
                    Blue = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumFastTravels = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Map_Location_Id",
                        column: x => x.Id,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentModelLootPool",
                columns: table => new
                {
                    LootPoolsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModelsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentModelLootPool", x => new { x.LootPoolsId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_EquipmentModelLootPool_EquipmentModels_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "EquipmentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentModelLootPool_LootPools_LootPoolsId",
                        column: x => x.LootPoolsId,
                        principalTable: "LootPools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    HasShield = table.Column<bool>(type: "INTEGER", nullable: false),
                    Unique = table.Column<bool>(type: "INTEGER", nullable: false),
                    LootPoolId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemy_LootPools_LootPoolId",
                        column: x => x.LootPoolId,
                        principalTable: "LootPools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enemy_NonPlayableCharacters_Id",
                        column: x => x.Id,
                        principalTable: "NonPlayableCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationNonPlayableCharacter",
                columns: table => new
                {
                    CharactersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocationsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationNonPlayableCharacter", x => new { x.CharactersId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_LocationNonPlayableCharacter_Location_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationNonPlayableCharacter_NonPlayableCharacters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "NonPlayableCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerClassId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Level = table.Column<byte>(type: "INTEGER", nullable: false),
                    Experience = table.Column<uint>(type: "INTEGER", nullable: true),
                    Money = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_PlayerClasses_PlayerClassId",
                        column: x => x.PlayerClassId,
                        principalTable: "PlayerClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    OnePointMax = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlayerClassId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tree = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Tier = table.Column<byte>(type: "INTEGER", nullable: false),
                    Column = table.Column<byte>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_PlayerClasses_PlayerClassId",
                        column: x => x.PlayerClassId,
                        principalTable: "PlayerClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HasFastTravel = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasUTurn = table.Column<bool>(type: "INTEGER", nullable: false),
                    MapId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LootPoolId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Location_Id",
                        column: x => x.Id,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Area_LootPools_LootPoolId",
                        column: x => x.LootPoolId,
                        principalTable: "LootPools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapMap",
                columns: table => new
                {
                    ConnectionsInId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConnectionsOutId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapMap", x => new { x.ConnectionsInId, x.ConnectionsOutId });
                    table.ForeignKey(
                        name: "FK_MapMap_Map_ConnectionsInId",
                        column: x => x.ConnectionsInId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapMap_Map_ConnectionsOutId",
                        column: x => x.ConnectionsOutId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy_Immunities",
                columns: table => new
                {
                    EnemyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Element = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy_Immunities", x => new { x.EnemyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Enemy_Immunities_Enemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy_Resistances",
                columns: table => new
                {
                    EnemyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Element = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy_Resistances", x => new { x.EnemyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Enemy_Resistances_Enemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy_Weaknesses",
                columns: table => new
                {
                    EnemyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Element = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy_Weaknesses", x => new { x.EnemyId, x.Id });
                    table.ForeignKey(
                        name: "FK_Enemy_Weaknesses_Enemy_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniqueEnemy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Boss = table.Column<bool>(type: "INTEGER", nullable: false),
                    RaidBoss = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueEnemy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniqueEnemy_Enemy_Id",
                        column: x => x.Id,
                        principalTable: "Enemy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkill",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkill", x => new { x.PlayerId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_PlayerSkill_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Dlc = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    StoryMission = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartAreaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EndAreaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MissionGiverId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MissionRewarderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MissionItemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LootPoolId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Area_EndAreaId",
                        column: x => x.EndAreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_Area_StartAreaId",
                        column: x => x.StartAreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Missions_EquipmentModels_MissionItemId",
                        column: x => x.MissionItemId,
                        principalTable: "EquipmentModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Missions_LootPools_LootPoolId",
                        column: x => x.LootPoolId,
                        principalTable: "LootPools",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Missions_NonPlayableCharacters_MissionGiverId",
                        column: x => x.MissionGiverId,
                        principalTable: "NonPlayableCharacters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Missions_NonPlayableCharacters_MissionRewarderId",
                        column: x => x.MissionRewarderId,
                        principalTable: "NonPlayableCharacters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Level = table.Column<byte>(type: "INTEGER", nullable: true),
                    RarityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BuyPrice = table.Column<uint>(type: "INTEGER", nullable: true),
                    SellPrice = table.Column<uint>(type: "INTEGER", nullable: true),
                    PlayerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DropId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Drop_Specified = table.Column<bool>(type: "INTEGER", nullable: true),
                    Drop_MissionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Drop_AreaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Drop_EnemyId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Area_Drop_AreaId",
                        column: x => x.Drop_AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Enemy_Drop_EnemyId",
                        column: x => x.Drop_EnemyId,
                        principalTable: "Enemy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "EquipmentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Missions_Drop_MissionId",
                        column: x => x.Drop_MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Rarities_RarityId",
                        column: x => x.RarityId,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapMission",
                columns: table => new
                {
                    MapsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MissionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapMission", x => new { x.MapsId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_MapMission_Map_MapsId",
                        column: x => x.MapsId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapMission_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionMission",
                columns: table => new
                {
                    PredecessorsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SuccessorsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionMission", x => new { x.PredecessorsId, x.SuccessorsId });
                    table.ForeignKey(
                        name: "FK_MissionMission_Missions_PredecessorsId",
                        column: x => x.PredecessorsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionMission_Missions_SuccessorsId",
                        column: x => x.SuccessorsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassMod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerClassId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassMod_Equipment_Id",
                        column: x => x.Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassMod_PlayerClasses_PlayerClassId",
                        column: x => x.PlayerClassId,
                        principalTable: "PlayerClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    Units = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    EquipmentItemId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effect_Equipment_EquipmentItemId",
                        column: x => x.EquipmentItemId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grenade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    BlastRadius = table.Column<int>(type: "INTEGER", nullable: false),
                    Fuse = table.Column<double>(type: "REAL", nullable: false),
                    Delivery = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false, collation: "NOCASE"),
                    Sticky = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChildCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementalDamagePerSecond = table.Column<double>(type: "REAL", nullable: true),
                    Element = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true, collation: "NOCASE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grenade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grenade_Equipment_Id",
                        column: x => x.Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gun",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<double>(type: "REAL", nullable: false),
                    FireRate = table.Column<double>(type: "REAL", nullable: false),
                    ReloadSpeed = table.Column<double>(type: "REAL", nullable: false),
                    MagazineSize = table.Column<int>(type: "INTEGER", nullable: false),
                    PelletCount = table.Column<int>(type: "INTEGER", nullable: true),
                    ElementalChance = table.Column<double>(type: "REAL", nullable: true),
                    Prefix = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    MissionItem = table.Column<bool>(type: "INTEGER", nullable: false),
                    Barrel = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    Stock = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    Grip = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    Scope = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    Body = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    ElementalDamagePerSecond = table.Column<double>(type: "REAL", nullable: true),
                    Element = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true, collation: "NOCASE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gun_Equipment_Id",
                        column: x => x.Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relic_Equipment_Id",
                        column: x => x.Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shield",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Capacity = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false, collation: "NOCASE"),
                    RechargeRate = table.Column<int>(type: "INTEGER", nullable: false),
                    RechargeDelay = table.Column<double>(type: "REAL", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    ElementalImmunity = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true, collation: "NOCASE"),
                    ElementalReduction = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true, collation: "NOCASE"),
                    Battery = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    Capacitor = table.Column<int>(type: "INTEGER", nullable: true),
                    Body = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true, collation: "NOCASE"),
                    ElementalDamagePerSecond = table.Column<double>(type: "REAL", nullable: true),
                    Element = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true, collation: "NOCASE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shield", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shield_Equipment_Id",
                        column: x => x.Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillBoost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SkillId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<byte>(type: "INTEGER", nullable: false),
                    ClassModItemId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillBoost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillBoost_ClassMod_ClassModItemId",
                        column: x => x.ClassModItemId,
                        principalTable: "ClassMod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillBoost_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_LootPoolId",
                table: "Area",
                column: "LootPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_MapId",
                table: "Area",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassMod_PlayerClassId",
                table: "ClassMod",
                column: "PlayerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Effect_EquipmentItemId",
                table: "Effect",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Enemy_LootPoolId",
                table: "Enemy",
                column: "LootPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_AccountId",
                table: "Equipment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Drop_AreaId",
                table: "Equipment",
                column: "Drop_AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Drop_EnemyId",
                table: "Equipment",
                column: "Drop_EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Drop_MissionId",
                table: "Equipment",
                column: "Drop_MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ModelId",
                table: "Equipment",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PlayerId",
                table: "Equipment",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RarityId",
                table: "Equipment",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModelLootPool_ModelsId",
                table: "EquipmentModelLootPool",
                column: "ModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationNonPlayableCharacter_LocationsId",
                table: "LocationNonPlayableCharacter",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_MapMap_ConnectionsOutId",
                table: "MapMap",
                column: "ConnectionsOutId");

            migrationBuilder.CreateIndex(
                name: "IX_MapMission_MissionId",
                table: "MapMission",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionMission_SuccessorsId",
                table: "MissionMission",
                column: "SuccessorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_EndAreaId",
                table: "Missions",
                column: "EndAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_LootPoolId",
                table: "Missions",
                column: "LootPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionGiverId",
                table: "Missions",
                column: "MissionGiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionItemId",
                table: "Missions",
                column: "MissionItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionRewarderId",
                table: "Missions",
                column: "MissionRewarderId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_StartAreaId",
                table: "Missions",
                column: "StartAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerClassId",
                table: "Players",
                column: "PlayerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkill_SkillId",
                table: "PlayerSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillBoost_ClassModItemId",
                table: "SkillBoost",
                column: "ClassModItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillBoost_SkillId",
                table: "SkillBoost",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PlayerClassId",
                table: "Skills",
                column: "PlayerClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effect");

            migrationBuilder.DropTable(
                name: "Enemy_Immunities");

            migrationBuilder.DropTable(
                name: "Enemy_Resistances");

            migrationBuilder.DropTable(
                name: "Enemy_Weaknesses");

            migrationBuilder.DropTable(
                name: "EquipmentModelLootPool");

            migrationBuilder.DropTable(
                name: "Grenade");

            migrationBuilder.DropTable(
                name: "Gun");

            migrationBuilder.DropTable(
                name: "LocationNonPlayableCharacter");

            migrationBuilder.DropTable(
                name: "MapMap");

            migrationBuilder.DropTable(
                name: "MapMission");

            migrationBuilder.DropTable(
                name: "MissionMission");

            migrationBuilder.DropTable(
                name: "PlayerSkill");

            migrationBuilder.DropTable(
                name: "Relic");

            migrationBuilder.DropTable(
                name: "Shield");

            migrationBuilder.DropTable(
                name: "SkillBoost");

            migrationBuilder.DropTable(
                name: "UniqueEnemy");

            migrationBuilder.DropTable(
                name: "ClassMod");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Enemy");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "EquipmentModels");

            migrationBuilder.DropTable(
                name: "NonPlayableCharacters");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "PlayerClasses");

            migrationBuilder.DropTable(
                name: "LootPools");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
