using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class QuotationNowDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_DocumentId",
                table: "QuotationItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quotations",
                table: "Quotations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuotationItems",
                table: "QuotationItems");

            migrationBuilder.RenameTable(
                name: "Quotations",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "QuotationItems",
                newName: "DocumentItems");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_DocumentId",
                table: "DocumentItems",
                newName: "IX_DocumentItems_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentItems",
                table: "DocumentItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentItems_Documents_DocumentId",
                table: "DocumentItems",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentItems_Documents_DocumentId",
                table: "DocumentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentItems",
                table: "DocumentItems");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Quotations");

            migrationBuilder.RenameTable(
                name: "DocumentItems",
                newName: "QuotationItems");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentItems_DocumentId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quotations",
                table: "Quotations",
                column: "DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuotationItems",
                table: "QuotationItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_DocumentId",
                table: "QuotationItems",
                column: "DocumentId",
                principalTable: "Quotations",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
