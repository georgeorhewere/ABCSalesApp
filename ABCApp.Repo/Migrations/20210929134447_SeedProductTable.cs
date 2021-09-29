using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace ABCApp.Repo.Migrations
{
    public partial class SeedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Scripts/products.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var deleteProducts = "Delete From Master_Product";
            migrationBuilder.Sql(deleteProducts);
        }
    }
}
