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
    [DbContext(typeof(QuoteDbContext))]
    [Migration("20190711183755_Intital")]
    partial class Intital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbrasNigeria.Models.Quotation", b =>
                {
                    b.Property<int>("QuotationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("DocType");

                    b.Property<string>("Note");

                    b.Property<string>("QuoteNo");

                    b.HasKey("QuotationId");

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("AbrasNigeria.Models.QuotationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("PartNumber");

                    b.Property<int>("Quantity");

                    b.Property<int>("QuotationId");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("QuotationItems");
                });

            modelBuilder.Entity("AbrasNigeria.Models.QuotationItem", b =>
                {
                    b.HasOne("AbrasNigeria.Models.Quotation")
                        .WithMany("Table")
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}