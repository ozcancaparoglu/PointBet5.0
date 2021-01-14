using Microsoft.EntityFrameworkCore.Migrations;

namespace PointBet.Data.Migrations
{
    public partial class TeamVenueFieldCustomApiId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomApiId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomApiId",
                table: "Teams");
        }
    }
}
