using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class MachineProductSerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSectionGroupSerialNo",
                table: "ProductSectionGroupSerialNo");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "ProductSectionGroupSerialNo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSectionGroupSerialNo",
                table: "ProductSectionGroupSerialNo",
                columns: new[] { "ProductId", "SectionGroupId", "SerialNoId", "MachineId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSectionGroupSerialNo_MachineId",
                table: "ProductSectionGroupSerialNo",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSectionGroupSerialNo_Machines_MachineId",
                table: "ProductSectionGroupSerialNo",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSectionGroupSerialNo_Machines_MachineId",
                table: "ProductSectionGroupSerialNo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSectionGroupSerialNo",
                table: "ProductSectionGroupSerialNo");

            migrationBuilder.DropIndex(
                name: "IX_ProductSectionGroupSerialNo_MachineId",
                table: "ProductSectionGroupSerialNo");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "ProductSectionGroupSerialNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSectionGroupSerialNo",
                table: "ProductSectionGroupSerialNo",
                columns: new[] { "ProductId", "SectionGroupId", "SerialNoId" });
        }
    }
}
