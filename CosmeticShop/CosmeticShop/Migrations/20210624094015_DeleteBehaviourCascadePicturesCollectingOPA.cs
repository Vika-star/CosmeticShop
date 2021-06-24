using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class DeleteBehaviourCascadePicturesCollectingOPA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPresonalData_Orders_OrderId",
                table: "OrderPresonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProuctAccountings_Orders_OrderId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProuctAccountings_ProductContainers_ProductContainerId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToCollect_OrderToCollectId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToDelivery_OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_ProductPictures_ProductPicturesId",
                table: "Pictures");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPresonalData_Orders_OrderId",
                table: "OrderPresonalData",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProuctAccountings_Orders_OrderId",
                table: "OrderProuctAccountings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProuctAccountings_ProductContainers_ProductContainerId",
                table: "OrderProuctAccountings",
                column: "ProductContainerId",
                principalTable: "ProductContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToCollect_OrderToCollectId",
                table: "Orders",
                column: "OrderToCollectId",
                principalTable: "OrdersToCollect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToDelivery_OrdersToDeliveryId",
                table: "Orders",
                column: "OrdersToDeliveryId",
                principalTable: "OrdersToDelivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_ProductPictures_ProductPicturesId",
                table: "Pictures",
                column: "ProductPicturesId",
                principalTable: "ProductPictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPresonalData_Orders_OrderId",
                table: "OrderPresonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProuctAccountings_Orders_OrderId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProuctAccountings_ProductContainers_ProductContainerId",
                table: "OrderProuctAccountings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToCollect_OrderToCollectId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToDelivery_OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_ProductPictures_ProductPicturesId",
                table: "Pictures");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPresonalData_Orders_OrderId",
                table: "OrderPresonalData",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToCollect_OrderToCollectId",
                table: "Orders",
                column: "OrderToCollectId",
                principalTable: "OrdersToCollect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToDelivery_OrdersToDeliveryId",
                table: "Orders",
                column: "OrdersToDeliveryId",
                principalTable: "OrdersToDelivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_ProductPictures_ProductPicturesId",
                table: "Pictures",
                column: "ProductPicturesId",
                principalTable: "ProductPictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
