using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballLeague.Data.Migrations
{
    public partial class AddGamesCollectionToTheTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamId",
                table: "Games",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_TeamId",
                table: "Games",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_TeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_TeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Games");
        }
    }
}
