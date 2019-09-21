using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class MachineProductRemark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remarks",
                columns: table => new
                {
                    RemarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remarks", x => x.RemarkId);
                });

            migrationBuilder.CreateTable(
                name: "ProductMachineRemark",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    RemarkId = table.Column<int>(nullable: false),
                    ProductMachineRemarkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMachineRemark", x => new { x.ProductId, x.MachineId, x.RemarkId });
                    table.ForeignKey(
                        name: "FK_ProductMachineRemark_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMachineRemark_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMachineRemark_Remarks_RemarkId",
                        column: x => x.RemarkId,
                        principalTable: "Remarks",
                        principalColumn: "RemarkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMachineRemark_MachineId",
                table: "ProductMachineRemark",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMachineRemark_RemarkId",
                table: "ProductMachineRemark",
                column: "RemarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMachineRemark");

            migrationBuilder.DropTable(
                name: "Remarks");
        }
    }
}
