using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace DapperPaging.Migrations
{
    public partial class CreateSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine("Script.sql"); migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
