using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeTopicPotentialKeyAsIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProblemTopics_Name",
                table: "ProblemTopics");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemTopics_Name",
                table: "ProblemTopics",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProblemTopics_Name",
                table: "ProblemTopics");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProblemTopics_Name",
                table: "ProblemTopics",
                column: "Name");
        }
    }
}
