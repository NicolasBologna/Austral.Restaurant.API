using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Austral.Restaurant.API.Migrations
{
    /// <inheritdoc />
    public partial class QuitarPropiedadSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
