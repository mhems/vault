using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vault.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddElementAndRaritySets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Accounts_AccountId",
                table: "Equipment");

            migrationBuilder.AddColumn<Guid>(
                name: "PossibleElementsId",
                table: "EquipmentModels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PossibleRaritiesId",
                table: "EquipmentModels",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ElementSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComesWithoutElement = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInIncendiary = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInShock = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInCorrosive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInSlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInExplosive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaritySets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComesInWhite = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInGreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInBlue = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInPurple = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInLegendary = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInEffervescent = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInPearlescent = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInSeraph = table.Column<bool>(type: "INTEGER", nullable: false),
                    ComesInETech = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaritySets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModels_PossibleElementsId",
                table: "EquipmentModels",
                column: "PossibleElementsId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentModels_PossibleRaritiesId",
                table: "EquipmentModels",
                column: "PossibleRaritiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Accounts_AccountId",
                table: "Equipment",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentModels_ElementSets_PossibleElementsId",
                table: "EquipmentModels",
                column: "PossibleElementsId",
                principalTable: "ElementSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentModels_RaritySets_PossibleRaritiesId",
                table: "EquipmentModels",
                column: "PossibleRaritiesId",
                principalTable: "RaritySets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Accounts_AccountId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentModels_ElementSets_PossibleElementsId",
                table: "EquipmentModels");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentModels_RaritySets_PossibleRaritiesId",
                table: "EquipmentModels");

            migrationBuilder.DropTable(
                name: "ElementSets");

            migrationBuilder.DropTable(
                name: "RaritySets");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentModels_PossibleElementsId",
                table: "EquipmentModels");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentModels_PossibleRaritiesId",
                table: "EquipmentModels");

            migrationBuilder.DropColumn(
                name: "PossibleElementsId",
                table: "EquipmentModels");

            migrationBuilder.DropColumn(
                name: "PossibleRaritiesId",
                table: "EquipmentModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "Equipment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Accounts_AccountId",
                table: "Equipment",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
