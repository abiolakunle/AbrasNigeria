using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class cartItemsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CartItemId",
                table: "Categories",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CartItems_CartItemId",
                table: "Categories",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "CartItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CartItems_CartItemId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CartItemId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "CartItems",
                nullable: true);
        }
    }
}
