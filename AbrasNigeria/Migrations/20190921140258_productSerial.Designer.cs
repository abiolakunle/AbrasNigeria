﻿// <auto-generated />
using System;
using AbrasNigeria.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AbrasNigeria.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190921140258_productSerial")]
    partial class productSerial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbrasNigeria.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("AbrasNigeria.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<int?>("OrderId");

                    b.Property<string>("PartNumber");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("ThumbUrl");

                    b.HasKey("CategoryId");

                    b.HasIndex("BrandId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("DocumentNo");

                    b.Property<string>("DocumentType");

                    b.Property<string>("Note");

                    b.Property<string>("RefDocumentNo");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("AbrasNigeria.Models.DocumentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("DocumentId");

                    b.Property<string>("PartNumber");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentItems");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("MachineTypeId");

                    b.Property<string>("ModelName");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("ThumbUrl");

                    b.HasKey("MachineId");

                    b.HasIndex("BrandId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineProductSectionGroupQuantity", b =>
                {
                    b.Property<int>("MachineId");

                    b.Property<int>("ProductId");

                    b.Property<int>("QuantityId");

                    b.Property<int>("SectionGroupId");

                    b.Property<int>("ProductQuantityId");

                    b.HasKey("MachineId", "ProductId", "QuantityId", "SectionGroupId");

                    b.HasIndex("ProductId");

                    b.HasIndex("QuantityId");

                    b.HasIndex("SectionGroupId");

                    b.ToTable("MachineProductSectionGroupQuantity");
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineSection", b =>
                {
                    b.Property<int>("MachineId");

                    b.Property<int>("SectionId");

                    b.Property<int>("MachineSectionId");

                    b.HasKey("MachineId", "SectionId");

                    b.HasIndex("SectionId");

                    b.ToTable("MachineSection");
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineSectionGroup", b =>
                {
                    b.Property<int>("MachineId");

                    b.Property<int>("SectionGroupId");

                    b.Property<int>("MachineSectionGroupId");

                    b.Property<int?>("SectionId");

                    b.HasKey("MachineId", "SectionGroupId");

                    b.HasIndex("SectionGroupId");

                    b.HasIndex("SectionId");

                    b.ToTable("MachineSectionGroup");
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineType", b =>
                {
                    b.Property<int>("MachineTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("MachineTypeName");

                    b.HasKey("MachineTypeId");

                    b.ToTable("MachineTypes");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CityState");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email");

                    b.Property<string>("Note");

                    b.Property<string>("OrderNo");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<string>("Description");

                    b.Property<string>("Detail");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("PartNumber");

                    b.Property<decimal>("Price");

                    b.Property<string>("Remarks");

                    b.Property<int?>("SectionId");

                    b.Property<string>("ThumbUrl");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("SectionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.Property<int>("ProductCategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductMachine", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("MachineId");

                    b.Property<int>("ProductMachineId");

                    b.HasKey("ProductId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("ProductMachine");
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductSectionGroup", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SectionGroupId");

                    b.Property<int>("ProductSectionGroupId");

                    b.HasKey("ProductId", "SectionGroupId");

                    b.HasIndex("SectionGroupId");

                    b.ToTable("ProductSectionGroup");
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductSectionGroupSerialNo", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("SectionGroupId");

                    b.Property<int>("SerialNoId");

                    b.Property<int>("ProductSectionGroupSerialNoId");

                    b.HasKey("ProductId", "SectionGroupId", "SerialNoId");

                    b.HasIndex("SectionGroupId");

                    b.HasIndex("SerialNoId");

                    b.ToTable("ProductSectionGroupSerialNo");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Quantity", b =>
                {
                    b.Property<int>("QuantityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("QuantityId");

                    b.ToTable("Quantities");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("SectionName");

                    b.Property<string>("ThumbUrl");

                    b.HasKey("SectionId");

                    b.HasIndex("BrandId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("AbrasNigeria.Models.SectionGroup", b =>
                {
                    b.Property<int>("SectionGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("SectionGroupName");

                    b.Property<int?>("SectionId");

                    b.Property<string>("ThumbUrl");

                    b.HasKey("SectionGroupId");

                    b.HasIndex("BrandId");

                    b.HasIndex("SectionId");

                    b.ToTable("SectionGroups");
                });

            modelBuilder.Entity("AbrasNigeria.Models.SerialNo", b =>
                {
                    b.Property<int>("SerialNoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.HasKey("SerialNoId");

                    b.ToTable("SerialNos");
                });

            modelBuilder.Entity("AbrasNigeria.Models.StockProduct", b =>
                {
                    b.Property<int>("StockProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand");

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Detail");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("PartNumber");

                    b.Property<decimal>("Price");

                    b.Property<string>("ThumbUrl");

                    b.HasKey("StockProductId");

                    b.ToTable("StockProducts");
                });

            modelBuilder.Entity("AbrasNigeria.Models.StockProductHistory", b =>
                {
                    b.Property<int>("StockProductHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedQuantity");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Note");

                    b.Property<int>("RemovedQuantity");

                    b.Property<int>("StockProductId");

                    b.HasKey("StockProductHistoryId");

                    b.HasIndex("StockProductId");

                    b.ToTable("StockProductHistories");
                });

            modelBuilder.Entity("AbrasNigeria.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AbrasNigeria.Models.CartItem", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Order")
                        .WithMany("CartItems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Category", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Brand")
                        .WithMany("Categories")
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.DocumentItem", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Document")
                        .WithMany("Table")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.Machine", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Brand", "Brand")
                        .WithMany("Machines")
                        .HasForeignKey("BrandId");

                    b.HasOne("AbrasNigeria.Models.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineProductSectionGroupQuantity", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.Product", "Product")
                        .WithMany("ProductQuantities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.Quantity", "Quantity")
                        .WithMany()
                        .HasForeignKey("QuantityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.SectionGroup", "SectionGroup")
                        .WithMany()
                        .HasForeignKey("SectionGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineSection", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Machine", "Machine")
                        .WithMany("MachineSections")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.Section", "Section")
                        .WithMany("MachineSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.MachineSectionGroup", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Machine", "Machine")
                        .WithMany("MachineSectionGroups")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.SectionGroup", "SectionGroup")
                        .WithMany("MachineSectionGroups")
                        .HasForeignKey("SectionGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.Section")
                        .WithMany("MachineSectionGroups")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Product", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("AbrasNigeria.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductCategory", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductMachine", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Machine", "Machine")
                        .WithMany("ProductMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.Product", "Product")
                        .WithMany("ProductMachines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductSectionGroup", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Product", "Product")
                        .WithMany("ProductSectionGroups")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.SectionGroup", "SectionGroup")
                        .WithMany("ProductSectionGroups")
                        .HasForeignKey("SectionGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.ProductSectionGroupSerialNo", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Product", "Product")
                        .WithMany("SectionGroupSerialNos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.SectionGroup", "SectionGroup")
                        .WithMany()
                        .HasForeignKey("SectionGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AbrasNigeria.Models.SerialNo", "SerialNo")
                        .WithMany()
                        .HasForeignKey("SerialNoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AbrasNigeria.Models.Section", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Brand")
                        .WithMany("Sections")
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.SectionGroup", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Brand")
                        .WithMany("SectionGroups")
                        .HasForeignKey("BrandId");

                    b.HasOne("AbrasNigeria.Models.Section", "Section")
                        .WithMany("SectionGroups")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("AbrasNigeria.Models.StockProductHistory", b =>
                {
                    b.HasOne("AbrasNigeria.Models.StockProduct")
                        .WithMany("StockProductHistories")
                        .HasForeignKey("StockProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
