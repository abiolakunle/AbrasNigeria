using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations.PartsBookDb
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "ThumbUrl",
                table: "Machines");

            migrationBuilder.AlterColumn<string>(
                name: "SectionName",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectionGroupName",
                table: "SectionGroups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartNumber",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "Machines",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionName",
                table: "Descriptions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionName",
                table: "Sections",
                column: "SectionName",
                unique: true,
                filter: "[SectionName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SectionGroups_SectionGroupName",
                table: "SectionGroups",
                column: "SectionGroupName",
                unique: true,
                filter: "[SectionGroupName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PartNumber",
                table: "Products",
                column: "PartNumber",
                unique: true,
                filter: "[PartNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_ModelName",
                table: "Machines",
                column: "ModelName",
                unique: true,
                filter: "[ModelName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_DescriptionName",
                table: "Descriptions",
                column: "DescriptionName",
                unique: true,
                filter: "[DescriptionName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_SectionName",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_SectionGroups_SectionGroupName",
                table: "SectionGroups");

            migrationBuilder.DropIndex(
                name: "IX_Products_PartNumber",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Machines_ModelName",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_DescriptionName",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                table: "Brands");

            migrationBuilder.AlterColumn<string>(
                name: "SectionName",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectionGroupName",
                table: "SectionGroups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartNumber",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "Machines",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbUrl",
                table: "Machines",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionName",
                table: "Descriptions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
