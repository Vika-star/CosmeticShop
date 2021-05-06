using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class ResetRelationsOrderProductAccounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProuctAccountings_OrderProuctAccountingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductContainers_OrderProuctAccountings_OrderProuctAccountingId",
                table: "ProductContainers");

            migrationBuilder.DropIndex(
                name: "IX_ProductContainers_OrderProuctAccountingId",
                table: "ProductContainers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProuctAccountingId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProuctAccountingId",
                table: "ProductContainers");

            migrationBuilder.DropColumn(
                name: "OrderProuctAccountingId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderProuctAccountings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductContainerId",
                table: "OrderProuctAccountings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProuctAccountings_OrderId",
                table: "OrderProuctAccountings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProuctAccountings_ProductContainerId",
                table: "OrderProuctAccountings",
                column: "ProductContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProuctAccountings_Orders_OrderId",
                table: "OrderProuctAccountings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProuctAccountings_ProductContainers_ProductContainerId",
                table: "OrderProuctAccountings",
                column: "ProductContainerId",
                principalTable: "ProductContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProuctAccountings_Orders_OrderId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProuctAccountings_ProductContainers_ProductContainerId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropIndex(
                name: "IX_OrderProuctAccountings_OrderId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropIndex(
                name: "IX_OrderProuctAccountings_ProductContainerId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropColumn(
                name: "ProductContainerId",
                table: "OrderProuctAccountings");

            migrationBuilder.AddColumn<int>(
                name: "OrderProuctAccountingId",
                table: "ProductContainers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProuctAccountingId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductContainers_OrderProuctAccountingId",
                table: "ProductContainers",
                column: "OrderProuctAccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderProuctAccountingId",
                table: "Orders",
                column: "OrderProuctAccountingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderProuctAccountings_OrderProuctAccountingId",
                table: "Orders",
                column: "OrderProuctAccountingId",
                principalTable: "OrderProuctAccountings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductContainers_OrderProuctAccountings_OrderProuctAccountingId",
                table: "ProductContainers",
                column: "OrderProuctAccountingId",
                principalTable: "OrderProuctAccountings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
