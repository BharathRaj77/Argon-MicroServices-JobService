using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DataAccessEntityFrameworkSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Argon",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                schema: "Argon",
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "OFFER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Argon",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                schema: "Argon",
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "OFFER" });
        }
    }
}
