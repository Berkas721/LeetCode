using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUselessDeleteInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImplementedProblems_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_ImplementedProblems_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropColumn(
                name: "DeleteInfo_AgentId",
                schema: "leetcode",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "DeleteInfo_Date",
                schema: "leetcode",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems");

            migrationBuilder.DropColumn(
                name: "DeleteInfo_Date",
                schema: "leetcode",
                table: "ImplementedProblems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleteInfo_AgentId",
                schema: "leetcode",
                table: "Problems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteInfo_Date",
                schema: "leetcode",
                table: "Problems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteInfo_Date",
                schema: "leetcode",
                table: "ImplementedProblems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "Problems",
                column: "DeleteInfo_AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementedProblems_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "ImplementedProblems",
                column: "DeleteInfo_AgentId");

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
                name: "FK_Problems_AspNetUsers_DeleteInfo_AgentId",
                schema: "leetcode",
                table: "Problems",
                column: "DeleteInfo_AgentId",
                principalSchema: "leetcode",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
