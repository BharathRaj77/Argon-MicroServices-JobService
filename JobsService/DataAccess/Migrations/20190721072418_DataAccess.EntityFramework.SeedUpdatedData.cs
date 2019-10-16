using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DataAccessEntityFrameworkSeedUpdatedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobIdentiferSequences",
                schema: "Argon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobIdentiferSequences", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Argon",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "DISCOUNT_OFFER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobIdentiferSequences",
                schema: "Argon");

            migrationBuilder.UpdateData(
                schema: "Argon",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "OFFER");
        }
    }
}
