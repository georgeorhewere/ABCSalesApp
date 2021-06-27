using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class addCityRegionOrderIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_DateOfSale_CountryCode_RegionCode_CityCode",
                table: "Orders",
                columns: new[] { "DateOfSale", "CountryCode", "RegionCode", "CityCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_DateOfSale_CountryCode_RegionCode_CityCode",
                table: "Orders");
        }
    }
}
