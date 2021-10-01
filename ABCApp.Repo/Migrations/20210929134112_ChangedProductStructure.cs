using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class ChangedProductStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Master_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Master_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Master_Product_ProductName",
                table: "Master_Product",
                column: "ProductName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Master_Product_ProductName",
                table: "Master_Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Master_Product");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Master_Product");
        }
    }
}
