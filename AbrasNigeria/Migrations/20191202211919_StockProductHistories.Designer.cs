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
    [Migration("20191202211919_StockProductHistories")]
    partial class StockProductHistories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbrasNigeria.Models.CartItem", b =>
                {
                    b.Property<long>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriptions");

                    b.Property<long?>("OrderId");

                    b.Property<string>("PartNumber");

                    b.Property<long>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Document", b =>
                {
                    b.Property<long>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company");

                    b.Property<string>("CompanyRef");

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
                    b.Property<long>("DocumentItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriptions");

                    b.Property<long>("DocumentId");

                    b.Property<string>("PartNumber");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("DocumentItemId");

                    b.HasIndex("DocumentId");

                    b.ToTable("DocumentItems");
                });

            modelBuilder.Entity("AbrasNigeria.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
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

            modelBuilder.Entity("AbrasNigeria.Models.StockProduct", b =>
                {
                    b.Property<long>("StockProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand");

                    b.Property<string>("Descriptions");

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
                    b.Property<long>("StockProductHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedQuantity");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Note");

                    b.Property<int>("RemovedQuantity");

                    b.Property<long>("StockProductId");

                    b.HasKey("StockProductHistoryId");

                    b.HasIndex("StockProductId");

                    b.ToTable("StockProductHistories");
                });

            modelBuilder.Entity("AbrasNigeria.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Role");

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

            modelBuilder.Entity("AbrasNigeria.Models.DocumentItem", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Document")
                        .WithMany("Table")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
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