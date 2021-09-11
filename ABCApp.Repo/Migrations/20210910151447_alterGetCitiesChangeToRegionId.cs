using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class alterGetCitiesChangeToRegionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[GetRegionCities]
                    @RegionId int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Select * from Master_City where RegionId = @RegionId
                     Order By CityName
                END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
