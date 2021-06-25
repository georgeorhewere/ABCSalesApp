using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class CreateABCDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "Master_Country",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Country", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "Master_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Master_Region",
                columns: table => new
                {
                    RegionCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Region", x => x.RegionCode);
                    table.ForeignKey(
                        name: "FK_Master_Region_Master_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Master_Country",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Master_City",
                columns: table => new
                {
                    CityCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RegionCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_City", x => x.CityCode);
                    table.ForeignKey(
                        name: "FK_Master_City_Master_Region_RegionCode",
                        column: x => x.RegionCode,
                        principalTable: "Master_Region",
                        principalColumn: "RegionCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegionCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Master_City_CityCode",
                        column: x => x.CityCode,
                        principalTable: "Master_City",
                        principalColumn: "CityCode");
                    table.ForeignKey(
                        name: "FK_Orders_Master_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Master_Country",
                        principalColumn: "CountryCode");
                    table.ForeignKey(
                        name: "FK_Orders_Master_Region_RegionCode",
                        column: x => x.RegionCode,
                        principalTable: "Master_Region",
                        principalColumn: "RegionCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Master_City_RegionCode",
                table: "Master_City",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Region_CountryCode",
                table: "Master_Region",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityCode",
                table: "Orders",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CountryCode",
                table: "Orders",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegionCode",
                table: "Orders",
                column: "RegionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "Master_Product");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Master_City");

            migrationBuilder.DropTable(
                name: "Master_Region");

            migrationBuilder.DropTable(
                name: "Master_Country");
        }
    }
}
