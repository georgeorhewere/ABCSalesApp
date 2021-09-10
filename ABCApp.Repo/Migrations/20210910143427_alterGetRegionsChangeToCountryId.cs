using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class alterGetRegionsChangeToCountryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[GetCountryRegions]
                    @CountryId int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Select * from Master_Region where CountryId = @CountryId
                    Order By RegionName
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
