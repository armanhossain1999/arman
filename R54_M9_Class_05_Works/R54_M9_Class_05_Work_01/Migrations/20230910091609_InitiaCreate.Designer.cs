﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using R54_M9_Class_05_Work_01.Models;

#nullable disable

namespace R54_M9_Class_05_Work_01.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230910091609_InitiaCreate")]
    partial class InitiaCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("R54_M9_Class_05_Work_01.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SellUnit")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "P01",
                            Picture = "1.jpg",
                            SellUnit = 1,
                            UnitPrice = 950.00m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "P02",
                            Picture = "2.jpg",
                            SellUnit = 1,
                            UnitPrice = 1900.00m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "P03",
                            Picture = "3.jpg",
                            SellUnit = 1,
                            UnitPrice = 2850.00m
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "P04",
                            Picture = "4.jpg",
                            SellUnit = 1,
                            UnitPrice = 3800.00m
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "P05",
                            Picture = "5.jpg",
                            SellUnit = 1,
                            UnitPrice = 4750.00m
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "P06",
                            Picture = "6.jpg",
                            SellUnit = 1,
                            UnitPrice = 5700.00m
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "P07",
                            Picture = "7.jpg",
                            SellUnit = 1,
                            UnitPrice = 6650.00m
                        });
                });

            modelBuilder.Entity("R54_M9_Class_05_Work_01.Models.ProductInventory", b =>
                {
                    b.Property<int>("ProductInventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductInventoryId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductInventoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInventories");

                    b.HasData(
                        new
                        {
                            ProductInventoryId = 1,
                            Date = new DateTime(2023, 8, 18, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3165),
                            ProductId = 1,
                            Quantity = 50
                        },
                        new
                        {
                            ProductInventoryId = 2,
                            Date = new DateTime(2023, 7, 26, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3191),
                            ProductId = 2,
                            Quantity = 100
                        },
                        new
                        {
                            ProductInventoryId = 3,
                            Date = new DateTime(2023, 7, 3, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3199),
                            ProductId = 3,
                            Quantity = 150
                        },
                        new
                        {
                            ProductInventoryId = 4,
                            Date = new DateTime(2023, 6, 10, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3206),
                            ProductId = 4,
                            Quantity = 200
                        },
                        new
                        {
                            ProductInventoryId = 5,
                            Date = new DateTime(2023, 5, 18, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3212),
                            ProductId = 5,
                            Quantity = 250
                        },
                        new
                        {
                            ProductInventoryId = 6,
                            Date = new DateTime(2023, 4, 25, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3220),
                            ProductId = 6,
                            Quantity = 300
                        },
                        new
                        {
                            ProductInventoryId = 7,
                            Date = new DateTime(2023, 4, 2, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3227),
                            ProductId = 7,
                            Quantity = 350
                        },
                        new
                        {
                            ProductInventoryId = 8,
                            Date = new DateTime(2023, 3, 10, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3234),
                            ProductId = 1,
                            Quantity = 400
                        },
                        new
                        {
                            ProductInventoryId = 9,
                            Date = new DateTime(2023, 2, 15, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3242),
                            ProductId = 2,
                            Quantity = 450
                        },
                        new
                        {
                            ProductInventoryId = 10,
                            Date = new DateTime(2023, 1, 23, 15, 16, 9, 494, DateTimeKind.Local).AddTicks(3249),
                            ProductId = 3,
                            Quantity = 500
                        });
                });

            modelBuilder.Entity("R54_M9_Class_05_Work_01.Models.ProductInventory", b =>
                {
                    b.HasOne("R54_M9_Class_05_Work_01.Models.Product", "Product")
                        .WithMany("ProductInventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("R54_M9_Class_05_Work_01.Models.Product", b =>
                {
                    b.Navigation("ProductInventories");
                });
#pragma warning restore 612, 618
        }
    }
}
