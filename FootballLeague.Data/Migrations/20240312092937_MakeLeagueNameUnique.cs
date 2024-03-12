using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballLeague.Data.Migrations
{
    public partial class MakeLeagueNameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Leagues_Name",
                table: "Leagues",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leagues_Name",
                table: "Leagues");
        }
    }
}
