using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAlternateKeysToUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TestCases_ProblemId_Input",
                table: "TestCases");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Problems_Name",
                table: "Problems");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LanguageVersions_Name_LanguageName",
                table: "LanguageVersions");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_ProblemId_Input",
                table: "TestCases",
                columns: new[] { "ProblemId", "Input" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_Name",
                table: "Problems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageVersions_Name_LanguageName",
                table: "LanguageVersions",
                columns: new[] { "Name", "LanguageName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestCases_ProblemId_Input",
                table: "TestCases");

            migrationBuilder.DropIndex(
                name: "IX_Problems_Name",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_LanguageVersions_Name_LanguageName",
                table: "LanguageVersions");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TestCases_ProblemId_Input",
                table: "TestCases",
                columns: new[] { "ProblemId", "Input" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Problems_Name",
                table: "Problems",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LanguageVersions_Name_LanguageName",
                table: "LanguageVersions",
                columns: new[] { "Name", "LanguageName" });
        }
    }
}
