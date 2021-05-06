using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class OrderProductAccountingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductContainers_Orders_OrderId",
                table: "ProductContainers");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "ProductContainers",
                newName: "OrderProuctAccountingId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductContainers_OrderId",
                table: "ProductContainers",
                newName: "IX_ProductContainers_OrderProuctAccountingId");

            migrationBuilder.AddColumn<int>(
                name: "OrderProuctAccountingId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProuctAccountings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProuctAccountings", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProuctAccountings_OrderProuctAccountingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductContainers_OrderProuctAccountings_OrderProuctAccountingId",
                table: "ProductContainers");

            migrationBuilder.DropTable(
                name: "OrderProuctAccountings");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProuctAccountingId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProuctAccountingId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderProuctAccountingId",
                table: "ProductContainers",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductContainers_OrderProuctAccountingId",
                table: "ProductContainers",
                newName: "IX_ProductContainers_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductContainers_Orders_OrderId",
                table: "ProductContainers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
