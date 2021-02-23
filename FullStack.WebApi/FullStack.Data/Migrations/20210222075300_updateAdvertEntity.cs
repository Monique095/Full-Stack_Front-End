using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class updateAdvertEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Adverts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
