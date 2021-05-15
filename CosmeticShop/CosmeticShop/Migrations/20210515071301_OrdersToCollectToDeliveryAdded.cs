using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class OrdersToCollectToDeliveryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersToCollectId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdersToDeliveryId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Home",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OrdersToCollect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersToCollect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersToDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersToDelivery", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdersToCollectId",
                table: "Orders",
                column: "OrdersToCollectId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdersToDeliveryId",
                table: "Orders",
                column: "OrdersToDeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersToCollect_OrdersToCollectId",
                table: "Orders",
                column: "OrdersToCollectId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToCollect_OrdersToCollectId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersToDelivery_OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersToCollect");

            migrationBuilder.DropTable(
                name: "OrdersToDelivery");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdersToCollectId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersToCollectId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersToDeliveryId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Home",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "OrderPresonalData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
