using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class productSerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SerialNos",
                columns: table => new
                {
                    SerialNoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNos", x => x.SerialNoId);
                });

            migrationBuilder.CreateTable(
                name: "ProductSectionGroupSerialNo",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    SectionGroupId = table.Column<int>(nullable: false),
                    SerialNoId = table.Column<int>(nullable: false),
                    ProductSectionGroupSerialNoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSectionGroupSerialNo", x => new { x.ProductId, x.SectionGroupId, x.SerialNoId });
                    table.ForeignKey(
                        name: "FK_ProductSectionGroupSerialNo_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSectionGroupSerialNo_SectionGroups_SectionGroupId",
                        column: x => x.SectionGroupId,
                        principalTable: "SectionGroups",
                        principalColumn: "SectionGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSectionGroupSerialNo_SerialNos_SerialNoId",
                        column: x => x.SerialNoId,
                        principalTable: "SerialNos",
                        principalColumn: "SerialNoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSectionGroupSerialNo_SectionGroupId",
                table: "ProductSectionGroupSerialNo",
                column: "SectionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSectionGroupSerialNo_SerialNoId",
                table: "ProductSectionGroupSerialNo",
                column: "SerialNoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSectionGroupSerialNo");

            migrationBuilder.DropTable(
                name: "SerialNos");
        }
    }
}
