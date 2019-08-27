using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class QuotationNowDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationId",
                table: "QuotationItems");

            migrationBuilder.RenameColumn(
                name: "QuoteNo",
                table: "Quotations",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "DocType",
                table: "Quotations",
                newName: "DocumentNo");

            migrationBuilder.RenameColumn(
                name: "QuotationId",
                table: "Quotations",
                newName: "DocumentId");

            migrationBuilder.RenameColumn(
                name: "QuotationId",
                table: "QuotationItems",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_QuotationId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_DocumentId",
                table: "QuotationItems",
                column: "DocumentId",
                principalTable: "Quotations",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Quotations_DocumentId",
                table: "QuotationItems");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "Quotations",
                newName: "QuoteNo");

            migrationBuilder.RenameColumn(
                name: "DocumentNo",
                table: "Quotations",
                newName: "DocType");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Quotations",
                newName: "QuotationId");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "QuotationItems",
                newName: "QuotationId");

            migrationBuilder.RenameIndex(
                name: "IX_QuotationItems_DocumentId",
                table: "QuotationItems",
                newName: "IX_QuotationItems_QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Quotations_QuotationId",
                table: "QuotationItems",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "QuotationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
