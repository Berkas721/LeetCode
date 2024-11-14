using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultCodeInLanguageAndImplementedProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultProblemCode",
                schema: "leetcode",
                table: "Languages",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultSolutionCode",
                schema: "leetcode",
                table: "Languages",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultSolutionCode",
                schema: "leetcode",
                table: "ImplementedProblems",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultProblemCode",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DefaultSolutionCode",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DefaultSolutionCode",
                schema: "leetcode",
                table: "ImplementedProblems");
        }
    }
}
