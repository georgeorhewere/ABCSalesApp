using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class updateCountryStateCitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_City_Master_Region_RegionCode",
                table: "Master_City");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Region_Master_Country_CountryCode",
                table: "Master_Region");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Master_Country_CountryCode",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Master_Region_RegionCode",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CountryCode",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DateOfSale_CountryCode_RegionCode_CityCode",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RegionCode",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_Region",
                table: "Master_Region");

            migrationBuilder.DropIndex(
                name: "IX_Master_Region_CountryCode",
                table: "Master_Region");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_Country",
                table: "Master_Country");

            migrationBuilder.DropIndex(
                name: "IX_Master_City_RegionCode",
                table: "Master_City");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Master_Region");

            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "Master_City");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "RegionCode",
                table: "Master_Region",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Master_Region",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Master_Region",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Master_Country",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Master_Country",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Master_City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_Region",
                table: "Master_Region",
                column: "RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_Country",
                table: "Master_Country",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CountryId",
                table: "Orders",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DateOfSale_CountryId_RegionId_CityCode",
                table: "Orders",
                columns: new[] { "DateOfSale", "CountryId", "RegionId", "CityCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegionId",
                table: "Orders",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Region_CountryId",
                table: "Master_Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Master_City_RegionId",
                table: "Master_City",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Master_City_Master_Region_RegionId",
                table: "Master_City",
                column: "RegionId",
                principalTable: "Master_Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Region_Master_Country_CountryId",
                table: "Master_Region",
                column: "CountryId",
                principalTable: "Master_Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Master_Country_CountryId",
                table: "Orders",
                column: "CountryId",
                principalTable: "Master_Country",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Master_Region_RegionId",
                table: "Orders",
                column: "RegionId",
                principalTable: "Master_Region",
                principalColumn: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Master_City_Master_Region_RegionId",
                table: "Master_City");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Region_Master_Country_CountryId",
                table: "Master_Region");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Master_Country_CountryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Master_Region_RegionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CountryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DateOfSale_CountryId_RegionId_CityCode",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RegionId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_Region",
                table: "Master_Region");

            migrationBuilder.DropIndex(
                name: "IX_Master_Region_CountryId",
                table: "Master_Region");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Master_Country",
                table: "Master_Country");

            migrationBuilder.DropIndex(
                name: "IX_Master_City_RegionId",
                table: "Master_City");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Master_Region");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Master_Region");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Master_Country");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Master_City");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Orders",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegionCode",
                table: "Orders",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RegionCode",
                table: "Master_Region",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Master_Region",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Master_Country",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionCode",
                table: "Master_City",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_Region",
                table: "Master_Region",
                column: "RegionCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master_Country",
                table: "Master_Country",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CountryCode",
                table: "Orders",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DateOfSale_CountryCode_RegionCode_CityCode",
                table: "Orders",
                columns: new[] { "DateOfSale", "CountryCode", "RegionCode", "CityCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegionCode",
                table: "Orders",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Master_Region_CountryCode",
                table: "Master_Region",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Master_City_RegionCode",
                table: "Master_City",
                column: "RegionCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Master_City_Master_Region_RegionCode",
                table: "Master_City",
                column: "RegionCode",
                principalTable: "Master_Region",
                principalColumn: "RegionCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Master_Region_Master_Country_CountryCode",
                table: "Master_Region",
                column: "CountryCode",
                principalTable: "Master_Country",
                principalColumn: "CountryCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Master_Country_CountryCode",
                table: "Orders",
                column: "CountryCode",
                principalTable: "Master_Country",
                principalColumn: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Master_Region_RegionCode",
                table: "Orders",
                column: "RegionCode",
                principalTable: "Master_Region",
                principalColumn: "RegionCode");
        }
    }
}
