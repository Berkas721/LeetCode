using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSolutionTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProblemTopics",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "SolutionTests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SolutionId = table.Column<long>(type: "bigint", nullable: false),
                    TestCaseId = table.Column<long>(type: "bigint", nullable: false),
                    ResultStatus = table.Column<int>(type: "integer", nullable: false),
                    ErrorMessage = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    IncorrectAnswer = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    UsedMemory = table.Column<int>(type: "integer", nullable: true),
                    UsedTime = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionTests", x => x.Id);
                    table.UniqueConstraint("AK_SolutionTests_SolutionId_TestCaseId", x => new { x.SolutionId, x.TestCaseId });
                    table.ForeignKey(
                        name: "FK_SolutionTests_ProblemSolutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "ProblemSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionTests_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionTests_TestCaseId",
                table: "SolutionTests",
                column: "TestCaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolutionTests");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProblemTopics",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
