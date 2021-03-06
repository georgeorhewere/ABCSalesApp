using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class spGetCountryRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetCountryRegions]
                    @CountryCode char(3)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Select * from Master_Region where CountryCode like @CountryCode +'%'
                    Order By RegionName
                END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
