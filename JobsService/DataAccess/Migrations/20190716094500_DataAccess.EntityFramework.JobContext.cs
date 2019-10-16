using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DataAccessEntityFrameworkJobContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Argon");

            migrationBuilder.CreateTable(
                name: "Actions",
                schema: "Argon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                schema: "Argon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "Argon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobDetails",
                schema: "Argon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobDetails_JobTypes_Type",
                        column: x => x.Type,
                        principalSchema: "Argon",
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionStates",
                schema: "Argon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    ActionDateTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    EIN = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionStates_Actions_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "Argon",
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionStates_JobDetails_JobId",
                        column: x => x.JobId,
                        principalSchema: "Argon",
                        principalTable: "JobDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionStates_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Argon",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionStates_ActionId",
                schema: "Argon",
                table: "ActionStates",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionStates_JobId",
                schema: "Argon",
                table: "ActionStates",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionStates_StatusId",
                schema: "Argon",
                table: "ActionStates",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_Type",
                schema: "Argon",
                table: "JobDetails",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionStates",
                schema: "Argon");

            migrationBuilder.DropTable(
                name: "Actions",
                schema: "Argon");

            migrationBuilder.DropTable(
                name: "JobDetails",
                schema: "Argon");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "Argon");

            migrationBuilder.DropTable(
                name: "JobTypes",
                schema: "Argon");
        }
    }
}
