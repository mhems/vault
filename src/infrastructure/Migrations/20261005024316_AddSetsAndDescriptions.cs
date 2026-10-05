using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vault.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSetsAndDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Missions_MissionItemId",
                table: "Missions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RaritySets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ElementSets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionItemId",
                table: "Missions",
                column: "MissionItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Missions_MissionItemId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RaritySets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ElementSets");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionItemId",
                table: "Missions",
                column: "MissionItemId",
                unique: true);
        }
    }
}
