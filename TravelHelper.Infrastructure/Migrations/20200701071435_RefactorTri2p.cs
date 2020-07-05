using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelper.Infrastructure.Migrations
{
    public partial class RefactorTri2p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Budgets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Budgets");
        }
    }
}
