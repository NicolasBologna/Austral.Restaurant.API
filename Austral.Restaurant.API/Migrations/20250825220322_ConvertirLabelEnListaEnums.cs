using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Austral.Restaurant.API.Migrations
{
    public partial class ConvertirLabelEnListaEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Labels",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Labels",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Label",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
