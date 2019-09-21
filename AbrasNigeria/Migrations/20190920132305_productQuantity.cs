using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class productQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Quantities",
                columns: table => new
                {
                    QuantityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantities", x => x.QuantityId);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuantity",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    QuantityId = table.Column<int>(nullable: false),
                    ProductQuantityId = table.Column<int>(nullable: false),
                    SectionGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuantity", x => new { x.ProductId, x.QuantityId });
                    table.ForeignKey(
                        name: "FK_ProductQuantity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuantity_Quantities_QuantityId",
                        column: x => x.QuantityId,
                        principalTable: "Quantities",
                        principalColumn: "QuantityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuantity_SectionGroups_SectionGroupId",
                        column: x => x.SectionGroupId,
                        principalTable: "SectionGroups",
                        principalColumn: "SectionGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantity_QuantityId",
                table: "ProductQuantity",
                column: "QuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuantity_SectionGroupId",
                table: "ProductQuantity",
                column: "SectionGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQuantity");

            migrationBuilder.DropTable(
                name: "Quantities");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Products",
                nullable: true);
        }
    }
}
