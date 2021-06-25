using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class spGetCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetCountries]                    
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Master_Country Order By CountryName
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
