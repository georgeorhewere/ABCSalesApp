﻿// <auto-generated />
using System;
using ABCApp.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABCApp.Repo.Migrations
{
    [DbContext(typeof(ABCDbContext))]
    [Migration("20210910143427_alterGetRegionsChangeToCountryId")]
    partial class alterGetRegionsChangeToCountryId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABCApp.Data.City", b =>
                {
                    b.Property<int>("CityCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("CityCode");

                    b.HasIndex("RegionId");

                    b.ToTable("Master_City");
                });

            modelBuilder.Entity("ABCApp.Data.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("char(3)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CountryId");

                    b.ToTable("Master_Country");
                });

            modelBuilder.Entity("ABCApp.Data.DbError", b =>
                {
                    b.Property<int>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ErrorBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ErrorOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrorId");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("ABCApp.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityCode")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateOfSale")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CityCode");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.HasIndex("DateOfSale", "CountryId", "RegionId", "CityCode");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ABCApp.Data.OrderListItem", b =>
                {
                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfSale")
                        .HasColumnType("datetime2");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalSale")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("OrderListItems");
                });

            modelBuilder.Entity("ABCApp.Data.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ProductId");

                    b.ToTable("Master_Product");
                });

            modelBuilder.Entity("ABCApp.Data.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("RegionCode")
                        .HasMaxLength(3)
                        .HasColumnType("char(3)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("RegionId");

                    b.HasIndex("CountryId");

                    b.ToTable("Master_Region");
                });

            modelBuilder.Entity("ABCApp.Data.City", b =>
                {
                    b.HasOne("ABCApp.Data.Region", null)
                        .WithMany("CityList")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ABCApp.Data.Order", b =>
                {
                    b.HasOne("ABCApp.Data.City", null)
                        .WithMany("OrdersList")
                        .HasForeignKey("CityCode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ABCApp.Data.Country", null)
                        .WithMany("OrdersList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ABCApp.Data.Region", null)
                        .WithMany("OrdersList")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ABCApp.Data.Region", b =>
                {
                    b.HasOne("ABCApp.Data.Country", null)
                        .WithMany("RegionList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ABCApp.Data.City", b =>
                {
                    b.Navigation("OrdersList");
                });

            modelBuilder.Entity("ABCApp.Data.Country", b =>
                {
                    b.Navigation("OrdersList");

                    b.Navigation("RegionList");
                });

            modelBuilder.Entity("ABCApp.Data.Region", b =>
                {
                    b.Navigation("CityList");

                    b.Navigation("OrdersList");
                });
#pragma warning restore 612, 618
        }
    }
}