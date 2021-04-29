using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class CountProductsToProductContainerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountProducts",
                table: "ProductContainers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountProducts",
                table: "ProductContainers");
        }
    }
}
