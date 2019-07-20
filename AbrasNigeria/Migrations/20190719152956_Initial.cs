using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbrasNigeria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    MachineTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineTypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.MachineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    QuotationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuoteNo = table.Column<string>(nullable: true),
                    DocType = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.QuotationId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ThumbUrl = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ThumbUrl = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ThumbUrl = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    MachineTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "MachineTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(nullable: false),
                    PartNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationItems_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "QuotationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartNumber = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ThumbUrl = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionGroups",
                columns: table => new
                {
                    SectionGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionGroupName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ThumbUrl = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    BrandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionGroups", x => x.SectionGroupId);
                    table.ForeignKey(
                        name: "FK_SectionGroups_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionGroups_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineSection",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    MachineSectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineSection", x => new { x.MachineId, x.SectionId });
                    table.ForeignKey(
                        name: "FK_MachineSection_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineSection_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "MachineSectionGroup",
                columns: table => new
                {
                    MachineId = table.Column<int>(nullable: false),
                    SectionGroupId = table.Column<int>(nullable: false),
                    MachineSectionGroupId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineSectionGroup", x => new { x.MachineId, x.SectionGroupId });
                    table.ForeignKey(
                        name: "FK_MachineSectionGroup_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineSectionGroup_SectionGroups_SectionGroupId",
                        column: x => x.SectionGroupId,
                        principalTable: "SectionGroups",
                        principalColumn: "SectionGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineSectionGroup_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Categories_BrandId",
                table: "Categories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_BrandId",
                table: "Machines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSection_SectionId",
                table: "MachineSection",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSectionGroup_SectionGroupId",
                table: "MachineSectionGroup",
                column: "SectionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSectionGroup_SectionId",
                table: "MachineSectionGroup",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMachine_MachineId",
                table: "ProductMachine",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SectionId",
                table: "Products",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSectionGroup_SectionGroupId",
                table: "ProductSectionGroup",
                column: "SectionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_QuotationId",
                table: "QuotationItems",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionGroups_BrandId",
                table: "SectionGroups",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionGroups_SectionId",
                table: "SectionGroups",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_BrandId",
                table: "Sections",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineSection");

            migrationBuilder.DropTable(
                name: "MachineSectionGroup");

            migrationBuilder.DropTable(
                name: "ProductMachine");

            migrationBuilder.DropTable(
                name: "ProductSectionGroup");

            migrationBuilder.DropTable(
                name: "QuotationItems");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SectionGroups");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "MachineTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
