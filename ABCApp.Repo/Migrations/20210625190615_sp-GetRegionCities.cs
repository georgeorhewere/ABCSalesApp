using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class spGetRegionCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetRegionCities]
                    @RegionCode char(3)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Select * from Master_City where RegionCode like @RegionCode +'%'
                     Order By CityName
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
