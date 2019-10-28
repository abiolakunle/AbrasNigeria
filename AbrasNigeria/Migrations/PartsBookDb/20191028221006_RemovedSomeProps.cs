using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations.PartsBookDb
{
    public partial class RemovedSomeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ThumbUrl",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SectionGroups");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SectionGroups");

            migrationBuilder.DropColumn(
                name: "ThumbUrl",
                table: "SectionGroups");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "ThumbUrl",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "BrandName");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandName",
                table: "Brands",
                column: "BrandName",
                unique: true,
                filter: "[BrandName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Brands_BrandName",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "Brands",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbUrl",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SectionGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SectionGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbUrl",
                table: "SectionGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Descriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbUrl",
                table: "Descriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brands",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
