using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreateInfoInProblemSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreateInfo_AgentId",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateInfo_Date",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutions_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ProblemSolutions",
                column: "CreateInfo_AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_AspNetUsers_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ProblemSolutions",
                column: "CreateInfo_AgentId",
                principalSchema: "leetcode",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_AspNetUsers_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropIndex(
                name: "IX_ProblemSolutions_CreateInfo_AgentId",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "CreateInfo_AgentId",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "CreateInfo_Date",
                schema: "leetcode",
                table: "ProblemSolutions");
        }
    }
}
