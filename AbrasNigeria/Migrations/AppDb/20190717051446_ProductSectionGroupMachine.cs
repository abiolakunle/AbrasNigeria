using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations.AppDb
{
    public partial class ProductSectionGroupMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductMachine",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    ProductMachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMachine", x => new { x.ProductId, x.MachineId });
                    table.ForeignKey(
                        name: "FK_ProductMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMachine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSectionGroup",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    SectionGroupId = table.Column<int>(nullable: false),
                    ProductSectionGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSectionGroup", x => new { x.ProductId, x.SectionGroupId });
                    table.ForeignKey(
                        name: "FK_ProductSectionGroup_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSectionGroup_SectionGroups_SectionGroupId",
                        column: x => x.SectionGroupId,
                        principalTable: "SectionGroups",
                        principalColumn: "SectionGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMachine_MachineId",
                table: "ProductMachine",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSectionGroup_SectionGroupId",
                table: "ProductSectionGroup",
                column: "SectionGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMachine");

            migrationBuilder.DropTable(
                name: "ProductSectionGroup");
        }
    }
}
