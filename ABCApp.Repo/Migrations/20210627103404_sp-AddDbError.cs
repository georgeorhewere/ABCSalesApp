using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCApp.Repo.Migrations
{
    public partial class spAddDbError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[AddErrorInfo]
                                 -- Add the parameters for the stored procedure here
                                    @ErrorDetail nvarchar(255),
                                    @ErrorBy nvarchar(255),
                                    @ErrorOn datetime2(7)                                    
                          AS
                            BEGIN
                                -- SET NOCOUNT ON added to prevent extra result sets from
                                -- interfering with SELECT statements.
                                SET NOCOUNT ON;

                                    INSERT INTO [dbo].[Errors]
                                           ([ErrorDetail]
                                           ,[ErrorBy]
                                           ,[ErrorOn])
                                 VALUES
                                       (@ErrorDetail
                                       ,@ErrorBy
                                       ,@ErrorOn
                                       )                                
                            END
                         ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
