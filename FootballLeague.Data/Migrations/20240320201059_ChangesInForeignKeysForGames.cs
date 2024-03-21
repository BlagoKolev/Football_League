using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballLeague.Data.Migrations
{
    public partial class ChangesInForeignKeysForGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_GuestId",
                table: "Games",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeId",
                table: "Games",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_GuestId",
                table: "Games",
                column: "GuestId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_HomeId",
                table: "Games",
                column: "HomeId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_GuestId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_HomeId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GuestId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_HomeId",
                table: "Games");
        }
    }
}
