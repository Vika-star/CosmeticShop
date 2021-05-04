using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticShop.Migrations
{
    public partial class PicturesEntityToContinAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_ProductContainers_ProductContainerId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_ProductContainerId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ProductContainerId",
                table: "Pictures");

            migrationBuilder.AddColumn<int>(
                name: "ProductPicturesId",
                table: "Pictures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviewNnmber = table.Column<int>(type: "int", nullable: true),
                    ProductContainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictures_ProductContainers_ProductContainerId",
                        column: x => x.ProductContainerId,
                        principalTable: "ProductContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductPicturesId",
                table: "Pictures",
                column: "ProductPicturesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductContainerId",
                table: "ProductPictures",
                column: "ProductContainerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_ProductPictures_ProductPicturesId",
                table: "Pictures",
                column: "ProductPicturesId",
                principalTable: "ProductPictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_ProductPictures_ProductPicturesId",
                table: "Pictures");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_ProductPicturesId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ProductPicturesId",
                table: "Pictures");

            migrationBuilder.AddColumn<int>(
                name: "ProductContainerId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductContainerId",
                table: "Pictures",
                column: "ProductContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_ProductContainers_ProductContainerId",
                table: "Pictures",
                column: "ProductContainerId",
                principalTable: "ProductContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
