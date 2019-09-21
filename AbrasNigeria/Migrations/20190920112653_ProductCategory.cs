using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class ProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_stockProductHistories_StockProducts_StockProductId",
                table: "stockProductHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stockProductHistories",
                table: "stockProductHistories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "stockProductHistories",
                newName: "StockProductHistories");

            migrationBuilder.RenameIndex(
                name: "IX_stockProductHistories_StockProductId",
                table: "StockProductHistories",
                newName: "IX_StockProductHistories_StockProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockProductHistories",
                table: "StockProductHistories",
                column: "StockProductHistoryId");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockProductHistories_StockProducts_StockProductId",
                table: "StockProductHistories",
                column: "StockProductId",
                principalTable: "StockProducts",
                principalColumn: "StockProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockProductHistories_StockProducts_StockProductId",
                table: "StockProductHistories");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockProductHistories",
                table: "StockProductHistories");

            migrationBuilder.RenameTable(
                name: "StockProductHistories",
                newName: "stockProductHistories");

            migrationBuilder.RenameIndex(
                name: "IX_StockProductHistories_StockProductId",
                table: "stockProductHistories",
                newName: "IX_stockProductHistories_StockProductId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_stockProductHistories",
                table: "stockProductHistories",
                column: "StockProductHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stockProductHistories_StockProducts_StockProductId",
                table: "stockProductHistories",
                column: "StockProductId",
                principalTable: "StockProducts",
                principalColumn: "StockProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
