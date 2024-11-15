using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUselessPropertiesInProblemSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedTestIds",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "TotalUsedMemory",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "TotalUsedTime",
                schema: "leetcode",
                table: "ProblemSolutions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long[]>(
                name: "FailedTestIds",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalUsedMemory",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalUsedTime",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "bigint",
                nullable: true);
        }
    }
}
