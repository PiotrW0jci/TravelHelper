using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelper.Infrastructure.Migrations
{
    public partial class RefactorTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Trips",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Trips");
        }
    }
}
