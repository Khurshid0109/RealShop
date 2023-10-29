using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class colorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Categories",
                newName: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "Categories",
                newName: "Category");
        }
    }
}
