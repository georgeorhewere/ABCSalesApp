using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class spInsertSalesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[InsertOrderInfo]
                                 -- Add the parameters for the stored procedure here
                                    @CustomerName nvarchar(255),
                                    @DateOfSale datetime2(7),
                                    @ProductId int,
                                    @Quantity int,
                                    @OrderTotal decimal(18,2),
                                    @CountryCode char(3),
                                    @RegionCode char(3),
                                    @CityCode int,
                                    @OrderId int output   
                          AS
                            BEGIN
                                -- SET NOCOUNT ON added to prevent extra result sets from
                                -- interfering with SELECT statements.
                                SET NOCOUNT ON;

                                    INSERT INTO [dbo].[Orders]
                                       ([CustomerName]
                                       ,[ProductId]
                                       ,[Quantity]
                                       ,[DateOfSale]
                                       ,[OrderTotal]
                                       ,[RegionCode]
                                       ,[CityCode]
                                       ,[CountryCode])
                                 VALUES
                                       (@CustomerName
                                       ,@ProductId
                                       ,@Quantity
                                       ,@DateOfSale
                                       ,@OrderTotal
                                       ,@RegionCode
                                       ,@CityCode
                                       ,@CountryCode)

                                SET @OrderId=SCOPE_IDENTITY()
								RETURN  @OrderId
                            END
                         ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
