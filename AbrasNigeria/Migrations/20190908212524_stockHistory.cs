using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class stockHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentQuantity",
                table: "StockProducts");

            migrationBuilder.CreateTable(
                name: "stockProductHistories",
                columns: table => new
                {
                    StockProductHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StockProductId = table.Column<int>(nullable: false),
                    AddedQuantity = table.Column<int>(nullable: false),
                    RemovedQuantity = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockProductHistories", x => x.StockProductHistoryId);
                    table.ForeignKey(
                        name: "FK_stockProductHistories_StockProducts_StockProductId",
                        column: x => x.StockProductId,
                        principalTable: "StockProducts",
                        principalColumn: "StockProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stockProductHistories_StockProductId",
                table: "stockProductHistories",
                column: "StockProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stockProductHistories");

            migrationBuilder.AddColumn<string>(
                name: "CurrentQuantity",
                table: "StockProducts",
                nullable: true);
        }
    }
}
