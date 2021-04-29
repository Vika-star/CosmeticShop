using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class ProductRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderHistory_OrderHistoryId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_AspNetUsers_UserId",
                table: "OrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Order_OrderId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductContainers_ProductCategory_ProductCategoryId",
                table: "ProductContainers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "OrderHistory",
                newName: "OrderHistories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_OrderId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "ProductContainers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ProductContainers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductContainers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "ProductContainers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderHistories_OrderHistoryId",
                table: "Order",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_AspNetUsers_UserId",
                table: "OrderHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Order_OrderId",
                table: "ProductCategories",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductContainers_ProductCategories_ProductCategoryId",
                table: "ProductContainers",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderHistories_OrderHistoryId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_AspNetUsers_UserId",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Order_OrderId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductContainers_ProductCategories_ProductCategoryId",
                table: "ProductContainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ProductContainers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ProductContainers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductContainers");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "ProductContainers");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "OrderHistories",
                newName: "OrderHistory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_OrderId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_UserId",
                table: "OrderHistory",
                newName: "IX_OrderHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductContainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductContainers_ProductContainerId",
                        column: x => x.ProductContainerId,
                        principalTable: "ProductContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductContainerId",
                table: "Products",
                column: "ProductContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderHistory_OrderHistoryId",
                table: "Order",
                column: "OrderHistoryId",
                principalTable: "OrderHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_AspNetUsers_UserId",
                table: "OrderHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Order_OrderId",
                table: "ProductCategory",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductContainers_ProductCategory_ProductCategoryId",
                table: "ProductContainers",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
