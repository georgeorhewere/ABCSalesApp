using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace ABCApp.Repo.Migrations
{
    public partial class AddCountriesSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Scripts/countries.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
            var sqlStateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Scripts/states.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlStateFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
