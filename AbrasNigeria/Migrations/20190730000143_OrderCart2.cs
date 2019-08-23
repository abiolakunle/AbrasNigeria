using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class OrderCart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CartItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartItems");
        }
    }
}
