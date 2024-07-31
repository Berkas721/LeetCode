using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusAndOpenInfoInProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenAt",
                table: "Problems",
                newName: "OpenInfo_Date");

            migrationBuilder.AddColumn<Guid>(
                name: "OpenInfo_AgentId",
                table: "Problems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Problems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_OpenInfo_AgentId",
                table: "Problems",
                column: "OpenInfo_AgentId");

            migrationBuilder.AddCheckConstraint(
                name: "Status_constraint",
                table: "Problems",
                sql: "(\"Status\" = 3 AND \"DeleteInfo_Date\" IS NOT NULL) OR (\"Status\" = 2 AND \"OpenInfo_Date\" IS NOT NULL) OR (\"Status\" = 1 AND \"DeleteInfo_Date\" IS NULL AND \"OpenInfo_Date\" IS NULL) OR + \"Status\" = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_OpenInfo_AgentId",
                table: "Problems",
                column: "OpenInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_OpenInfo_AgentId",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_OpenInfo_AgentId",
                table: "Problems");

            migrationBuilder.DropCheckConstraint(
                name: "Status_constraint",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "OpenInfo_AgentId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "OpenInfo_Date",
                table: "Problems",
                newName: "OpenAt");
        }
    }
}
