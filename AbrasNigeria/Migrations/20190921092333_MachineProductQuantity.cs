using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class MachineProductQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQuantity");

            migrationBuilder.CreateTable(
                name: "MachineProductSectionGroupQuantity",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    QuantityId = table.Column<int>(nullable: false),
                    SectionGroupId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    ProductQuantityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineProductSectionGroupQuantity", x => new { x.MachineId, x.ProductId, x.QuantityId, x.SectionGroupId });
                    table.ForeignKey(
                        name: "FK_MachineProductSectionGroupQuantity_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineProductSectionGroupQuantity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineProductSectionGroupQuantity_Quantities_QuantityId",
                        column: x => x.QuantityId,
                        principalTable: "Quantities",
                        principalColumn: "QuantityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineProductSectionGroupQuantity_SectionGroups_SectionGroupId",
                        column: x => x.SectionGroupId,
                        principalTable: "SectionGroups",
                        principalColumn: "SectionGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineProductSectionGroupQuantity_ProductId",
                table: "MachineProductSectionGroupQuantity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineProductSectionGroupQuantity_QuantityId",
                table: "MachineProductSectionGroupQuantity",
                column: "QuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineProductSectionGroupQuantity_SectionGroupId",
                table: "MachineProductSectionGroupQuantity",
                column: "SectionGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineProductSectionGroupQuantity");

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
    }
}
