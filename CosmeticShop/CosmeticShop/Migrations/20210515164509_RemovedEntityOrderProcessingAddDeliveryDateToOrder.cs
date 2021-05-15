using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class RemovedEntityOrderProcessingAddDeliveryDateToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_OrderProcessing_OrderProcessingId",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToCollect_OrdersToCollectId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersToCollect_OrderProcessing_OrderProcessingId",
                table: "OrdersToCollect");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersToDelivery_OrderProcessing_OrderProcessingId",
                table: "OrdersToDelivery");

            migrationBuilder.DropTable(
                name: "OrderProcessing");

            migrationBuilder.DropIndex(
                name: "IX_OrdersToDelivery_OrderProcessingId",
                table: "OrdersToDelivery");

            migrationBuilder.DropIndex(
                name: "IX_OrdersToCollect_OrderProcessingId",
                table: "OrdersToCollect");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdersToCollectId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_OrderProcessingId",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "OrderProcessingId",
                table: "OrdersToDelivery");

            migrationBuilder.DropColumn(
                name: "OrderProcessingId",
                table: "OrdersToCollect");

            migrationBuilder.DropColumn(
                name: "OrderProcessingId",
                table: "OrderHistories");

            migrationBuilder.RenameColumn(
                name: "OrdersToCollectId",
                table: "Orders",
                newName: "OrderToCollectId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdersToDeliveryId",
                table: "Orders",
                column: "OrdersToDeliveryId",
                unique: true,
                filter: "[OrdersToDeliveryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderToCollectId",
                table: "Orders",
                column: "OrderToCollectId",
                unique: true,
                filter: "[OrderToCollectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToCollect_OrderToCollectId",
                table: "Orders",
                column: "OrderToCollectId",
                principalTable: "OrdersToCollect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToCollect_OrderToCollectId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderToCollectId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderToCollectId",
                table: "Orders",
                newName: "OrdersToCollectId");

            migrationBuilder.AddColumn<int>(
                name: "OrderProcessingId",
                table: "OrdersToDelivery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderProcessingId",
                table: "OrdersToCollect",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderProcessingId",
                table: "OrderHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProcessing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProcessing", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersToDelivery_OrderProcessingId",
                table: "OrdersToDelivery",
                column: "OrderProcessingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersToCollect_OrderProcessingId",
                table: "OrdersToCollect",
                column: "OrderProcessingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdersToCollectId",
                table: "Orders",
                column: "OrdersToCollectId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdersToDeliveryId",
                table: "Orders",
                column: "OrdersToDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderProcessingId",
                table: "OrderHistories",
                column: "OrderProcessingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_OrderProcessing_OrderProcessingId",
                table: "OrderHistories",
                column: "OrderProcessingId",
                principalTable: "OrderProcessing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToCollect_OrdersToCollectId",
                table: "Orders",
                column: "OrdersToCollectId",
                principalTable: "OrdersToCollect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersToCollect_OrderProcessing_OrderProcessingId",
                table: "OrdersToCollect",
                column: "OrderProcessingId",
                principalTable: "OrderProcessing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersToDelivery_OrderProcessing_OrderProcessingId",
                table: "OrdersToDelivery",
                column: "OrderProcessingId",
                principalTable: "OrderProcessing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
