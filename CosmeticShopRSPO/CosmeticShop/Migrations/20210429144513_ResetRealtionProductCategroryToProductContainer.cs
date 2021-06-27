using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class ResetRealtionProductCategroryToProductContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Order_OrderId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_OrderId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductCategories");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductContainers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductContainers_OrderId",
                table: "ProductContainers",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductContainers_Order_OrderId",
                table: "ProductContainers",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductContainers_Order_OrderId",
                table: "ProductContainers");

            migrationBuilder.DropIndex(
                name: "IX_ProductContainers_OrderId",
                table: "ProductContainers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductContainers");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_OrderId",
                table: "ProductCategories",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Order_OrderId",
                table: "ProductCategories",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
