using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAndMaxStringLenghtCorrecting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguagesWithVersion_Languages_LanguageId",
                table: "LanguagesWithVersion");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_CreatorId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_DeleterId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreatorId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleterId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_AspNetUsers_CreatorId",
                table: "TestCases");

            migrationBuilder.DropCheckConstraint(
                name: "DeleteInfoConflictCheck",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropCheckConstraint(
                name: "DeleteInfoConflictCheck",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "TestCases",
                newName: "CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "TestCases",
                newName: "CreateInfo_Date");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_CreatorId",
                table: "TestCases",
                newName: "IX_TestCases_CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "DeleterId",
                table: "SolutionsRunningDetails",
                newName: "DeleteInfo_DeleterId");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "SolutionsRunningDetails",
                newName: "DeleteInfo_Date");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "SolutionsRunningDetails",
                newName: "CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SolutionsRunningDetails",
                newName: "CreateInfo_Date");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_DeleterId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_DeleteInfo_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_CreatorId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "DeleterId",
                table: "Problems",
                newName: "DeleteInfo_DeleterId");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Problems",
                newName: "UpdateInfo_Date");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Problems",
                newName: "CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Problems",
                newName: "DeleteInfo_Date");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_DeleterId",
                table: "Problems",
                newName: "IX_Problems_DeleteInfo_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_CreatorId",
                table: "Problems",
                newName: "IX_Problems_CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "LanguagesWithVersion",
                newName: "ProgrammingLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguagesWithVersion_LanguageId",
                table: "LanguagesWithVersion",
                newName: "IX_LanguagesWithVersion_ProgrammingLanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Output",
                table: "TestCases",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Input",
                table: "TestCases",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultCode",
                table: "SolutionsRunningDetails",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProblemSolutions",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteInfo_Date",
                table: "Problems",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateInfo_Date",
                table: "Problems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenAt",
                table: "Problems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateInfo_UpdaterId",
                table: "Problems",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_UpdateInfo_UpdaterId",
                table: "Problems",
                column: "UpdateInfo_UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagesWithVersion_Languages_ProgrammingLanguageId",
                table: "LanguagesWithVersion",
                column: "ProgrammingLanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_CreateInfo_CreatorId",
                table: "Problems",
                column: "CreateInfo_CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_DeleteInfo_DeleterId",
                table: "Problems",
                column: "DeleteInfo_DeleterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_UpdateInfo_UpdaterId",
                table: "Problems",
                column: "UpdateInfo_UpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreateInfo_CreatorId",
                table: "SolutionsRunningDetails",
                column: "CreateInfo_CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleteInfo_DeleterId",
                table: "SolutionsRunningDetails",
                column: "DeleteInfo_DeleterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_AspNetUsers_CreateInfo_CreatorId",
                table: "TestCases",
                column: "CreateInfo_CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguagesWithVersion_Languages_ProgrammingLanguageId",
                table: "LanguagesWithVersion");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_CreateInfo_CreatorId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_DeleteInfo_DeleterId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_UpdateInfo_UpdaterId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreateInfo_CreatorId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleteInfo_DeleterId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_AspNetUsers_CreateInfo_CreatorId",
                table: "TestCases");

            migrationBuilder.DropIndex(
                name: "IX_Problems_UpdateInfo_UpdaterId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "CreateInfo_Date",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "OpenAt",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "UpdateInfo_UpdaterId",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_Date",
                table: "TestCases",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_CreatorId",
                table: "TestCases",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_CreateInfo_CreatorId",
                table: "TestCases",
                newName: "IX_TestCases_CreatorId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_DeleterId",
                table: "SolutionsRunningDetails",
                newName: "DeleterId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_Date",
                table: "SolutionsRunningDetails",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_Date",
                table: "SolutionsRunningDetails",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_CreatorId",
                table: "SolutionsRunningDetails",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_DeleteInfo_DeleterId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_CreateInfo_CreatorId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_CreatorId");

            migrationBuilder.RenameColumn(
                name: "UpdateInfo_Date",
                table: "Problems",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_DeleterId",
                table: "Problems",
                newName: "DeleterId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_Date",
                table: "Problems",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_CreatorId",
                table: "Problems",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_DeleteInfo_DeleterId",
                table: "Problems",
                newName: "IX_Problems_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_CreateInfo_CreatorId",
                table: "Problems",
                newName: "IX_Problems_CreatorId");

            migrationBuilder.RenameColumn(
                name: "ProgrammingLanguageId",
                table: "LanguagesWithVersion",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguagesWithVersion_ProgrammingLanguageId",
                table: "LanguagesWithVersion",
                newName: "IX_LanguagesWithVersion_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Output",
                table: "TestCases",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "Input",
                table: "TestCases",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultCode",
                table: "SolutionsRunningDetails",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProblemSolutions",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Problems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "DeleteInfoConflictCheck",
                table: "SolutionsRunningDetails",
                sql: "(\"DeletedAt\" IS NULL AND \"DeleterId\" IS NULL) OR (\"DeletedAt\" IS NOT NULL AND \"DeleterId\" IS NOT NULL)");

            migrationBuilder.AddCheckConstraint(
                name: "DeleteInfoConflictCheck",
                table: "Problems",
                sql: "(\"DeletedAt\" IS NULL AND \"DeleterId\" IS NULL) OR (\"DeletedAt\" IS NOT NULL AND \"DeleterId\" IS NOT NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagesWithVersion_Languages_LanguageId",
                table: "LanguagesWithVersion",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_CreatorId",
                table: "Problems",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_DeleterId",
                table: "Problems",
                column: "DeleterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreatorId",
                table: "SolutionsRunningDetails",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleterId",
                table: "SolutionsRunningDetails",
                column: "DeleterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_AspNetUsers_CreatorId",
                table: "TestCases",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
