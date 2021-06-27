using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class GetProductOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                    IF OBJECT_ID('GetProductOrders', 'P') IS NOT NULL
                        DROP PROC GetProductOrders
                    GO
                
                CREATE PROCEDURE [dbo].[GetProductOrders]
                        @DateOfSale datetime2(7) = NULL,
                        @CountryCode char(3)  = NULL,
                        @RegionCode char(3)  = NULL,
                        @CityCode int = NULL
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT	o.CustomerName, 
							o.DateOfSale, 
							c.CountryName as Country, 
							r.RegionName as Region, 
							ct.CityName as City,
							p.ProductName as Product,
							o.OrderTotal as TotalSale,
							o.Quantity
						FROM Orders o
						JOIN Master_Country c ON o.CountryCode = c.CountryCode
						JOIN Master_Region r ON o.RegionCode = r.RegionCode
						JOIN Master_City ct ON o.CityCode = ct.CityCode
						JOIN Master_Product p ON o.ProductId = p.ProductId

						WHERE (@DateOfSale is null OR CAST(o.DateOfSale AS date) = CONVERT(date, @DateOfSale, 105))
							AND (@CountryCode is null OR o.CountryCode  like @CountryCode +'%')
							AND (@RegionCode is null OR o.RegionCode  like @RegionCode +'%')
							AND (@CityCode is null OR o.CityCode  = @CityCode)
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
