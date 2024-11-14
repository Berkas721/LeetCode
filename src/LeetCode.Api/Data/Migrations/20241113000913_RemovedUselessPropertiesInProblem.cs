using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUselessPropertiesInProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_ImplementedProblem~",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreateInfo_AgentId",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_Languages_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_Problems_ProblemId",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SolutionsRunningDetails_ProblemId_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionsRunningDetails",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropColumn(
                name: "AdditionalDetails",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.RenameTable(
                name: "SolutionsRunningDetails",
                schema: "leetcode",
                newName: "ImplementedProblems",
                newSchema: "leetcode");

            migrationBuilder.RenameColumn(
                name: "DefaultCode",
                schema: "leetcode",
                table: "ImplementedProblems",
                newName: "ProblemCode");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_LanguageId",
                schema: "leetcode",
                table: "ImplementedProblems",
                newName: "IX_ImplementedProblems_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems",
                newName: "IX_ImplementedProblems_DeleteInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems",
                newName: "IX_ImplementedProblems_CreateInfo_AgentId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ImplementedProblems_ProblemId_LanguageId",
                schema: "leetcode",
                table: "ImplementedProblems",
                columns: new[] { "ProblemId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImplementedProblems",
                schema: "leetcode",
                table: "ImplementedProblems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementedProblems_AspNetUsers_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems",
                column: "CreateInfo_AgentId",
                principalSchema: "leetcode",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementedProblems_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems",
                column: "DeleteInfo_AgentId",
                principalSchema: "leetcode",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementedProblems_Languages_LanguageId",
                schema: "leetcode",
                table: "ImplementedProblems",
                column: "LanguageId",
                principalSchema: "leetcode",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementedProblems_Problems_ProblemId",
                schema: "leetcode",
                table: "ImplementedProblems",
                column: "ProblemId",
                principalSchema: "leetcode",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_ImplementedProblems_ImplementedProblemId",
                schema: "leetcode",
                table: "ProblemSolutions",
                column: "ImplementedProblemId",
                principalSchema: "leetcode",
                principalTable: "ImplementedProblems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImplementedProblems_AspNetUsers_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementedProblems_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementedProblems_Languages_LanguageId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementedProblems_Problems_ProblemId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_ImplementedProblems_ImplementedProblemId",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ImplementedProblems_ProblemId_LanguageId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImplementedProblems",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.RenameTable(
                name: "ImplementedProblems",
                schema: "leetcode",
                newName: "SolutionsRunningDetails",
                newSchema: "leetcode");

            migrationBuilder.RenameColumn(
                name: "ProblemCode",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                newName: "DefaultCode");

            migrationBuilder.RenameIndex(
                name: "IX_ImplementedProblems_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ImplementedProblems_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_DeleteInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_ImplementedProblems_CreateInfo_AgentId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_CreateInfo_AgentId");

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "AdditionalDetails",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                type: "hstore",
                nullable: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SolutionsRunningDetails_ProblemId_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                columns: new[] { "ProblemId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionsRunningDetails",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_ImplementedProblem~",
                schema: "leetcode",
                table: "ProblemSolutions",
                column: "ImplementedProblemId",
                principalSchema: "leetcode",
                principalTable: "SolutionsRunningDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreateInfo_AgentId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                column: "CreateInfo_AgentId",
                principalSchema: "leetcode",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                column: "DeleteInfo_AgentId",
                principalSchema: "leetcode",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_Languages_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                column: "LanguageId",
                principalSchema: "leetcode",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_Problems_ProblemId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                column: "ProblemId",
                principalSchema: "leetcode",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
