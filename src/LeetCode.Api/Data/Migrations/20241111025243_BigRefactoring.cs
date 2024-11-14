using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class BigRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_ProblemResolveSessions_SessionId",
                table: "ProblemSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_RunningDetailsId",
                table: "ProblemSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_LanguageVersions_LanguageId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropTable(
                name: "LanguageVersions");

            migrationBuilder.DropTable(
                name: "ProblemResolveSessions");

            migrationBuilder.DropIndex(
                name: "IX_ProblemSolutions_SessionId",
                table: "ProblemSolutions");

            migrationBuilder.DropCheckConstraint(
                name: "Status_constraint",
                table: "Problems");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Languages_Name",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ErrorType",
                table: "SolutionTests");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "IsPremiumRequired",
                table: "Problems");

            migrationBuilder.EnsureSchema(
                name: "leetcode");

            migrationBuilder.RenameTable(
                name: "TestCases",
                newName: "TestCases",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "SolutionTests",
                newName: "SolutionTests",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "SolutionsRunningDetails",
                newName: "SolutionsRunningDetails",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "ProblemTopics",
                newName: "ProblemTopics",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "ProblemSolutions",
                newName: "ProblemSolutions",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "Problems",
                newName: "Problems",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "ProblemProblemTopic",
                newName: "ProblemProblemTopic",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Languages",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "leetcode");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "leetcode");

            migrationBuilder.RenameColumn(
                name: "WorkingSolution",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                newName: "WorkingSolutionCode");

            migrationBuilder.RenameColumn(
                name: "RunningDetailsId",
                schema: "leetcode",
                table: "ProblemSolutions",
                newName: "ImplementedProblemId");

            migrationBuilder.RenameIndex(
                name: "IX_ProblemSolutions_RunningDetailsId",
                schema: "leetcode",
                table: "ProblemSolutions",
                newName: "IX_ProblemSolutions_ImplementedProblemId");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "leetcode",
                table: "Languages",
                newName: "VersionName");

            migrationBuilder.AlterColumn<long>(
                name: "UsedTime",
                schema: "leetcode",
                table: "SolutionTests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UsedMemory",
                schema: "leetcode",
                table: "SolutionTests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TotalUsedTime",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TotalUsedMemory",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "FailedTestIds",
                schema: "leetcode",
                table: "ProblemSolutions",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "AdditionalDetails",
                schema: "leetcode",
                table: "Languages",
                type: "hstore",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                schema: "leetcode",
                table: "Languages",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "RealizedAt",
                schema: "leetcode",
                table: "Languages",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageName_VersionName",
                schema: "leetcode",
                table: "Languages",
                columns: new[] { "LanguageName", "VersionName" },
                unique: true);

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
                name: "FK_SolutionsRunningDetails_Languages_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails",
                column: "LanguageId",
                principalSchema: "leetcode",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_ImplementedProblem~",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_Languages_LanguageId",
                schema: "leetcode",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageName_VersionName",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "FailedTestIds",
                schema: "leetcode",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "AdditionalDetails",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageName",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "RealizedAt",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "TestCases",
                schema: "leetcode",
                newName: "TestCases");

            migrationBuilder.RenameTable(
                name: "SolutionTests",
                schema: "leetcode",
                newName: "SolutionTests");

            migrationBuilder.RenameTable(
                name: "SolutionsRunningDetails",
                schema: "leetcode",
                newName: "SolutionsRunningDetails");

            migrationBuilder.RenameTable(
                name: "ProblemTopics",
                schema: "leetcode",
                newName: "ProblemTopics");

            migrationBuilder.RenameTable(
                name: "ProblemSolutions",
                schema: "leetcode",
                newName: "ProblemSolutions");

            migrationBuilder.RenameTable(
                name: "Problems",
                schema: "leetcode",
                newName: "Problems");

            migrationBuilder.RenameTable(
                name: "ProblemProblemTopic",
                schema: "leetcode",
                newName: "ProblemProblemTopic");

            migrationBuilder.RenameTable(
                name: "Languages",
                schema: "leetcode",
                newName: "Languages");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "leetcode",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "leetcode",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "leetcode",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "leetcode",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "leetcode",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "leetcode",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "leetcode",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameColumn(
                name: "WorkingSolutionCode",
                table: "SolutionsRunningDetails",
                newName: "WorkingSolution");

            migrationBuilder.RenameColumn(
                name: "ImplementedProblemId",
                table: "ProblemSolutions",
                newName: "RunningDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProblemSolutions_ImplementedProblemId",
                table: "ProblemSolutions",
                newName: "IX_ProblemSolutions_RunningDetailsId");

            migrationBuilder.RenameColumn(
                name: "VersionName",
                table: "Languages",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "UsedTime",
                table: "SolutionTests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsedMemory",
                table: "SolutionTests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErrorType",
                table: "SolutionTests",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalUsedTime",
                table: "ProblemSolutions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalUsedMemory",
                table: "ProblemSolutions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ProblemSolutions",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SessionId",
                table: "ProblemSolutions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsPremiumRequired",
                table: "Problems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Languages_Name",
                table: "Languages",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "LanguageVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RealizedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageVersions_Languages_LanguageName",
                        column: x => x.LanguageName,
                        principalTable: "Languages",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemResolveSessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProblemId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemResolveSessions", x => x.Id);
                    table.UniqueConstraint("AK_ProblemResolveSessions_UserId_ProblemId", x => new { x.UserId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_ProblemResolveSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemResolveSessions_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutions_SessionId",
                table: "ProblemSolutions",
                column: "SessionId");

            migrationBuilder.AddCheckConstraint(
                name: "Status_constraint",
                table: "Problems",
                sql: "(\"Status\" = 3 AND \"DeleteInfo_Date\" IS NOT NULL) OR (\"Status\" = 2 AND \"OpenInfo_Date\" IS NOT NULL) OR (\"Status\" = 1 AND \"DeleteInfo_Date\" IS NULL AND \"OpenInfo_Date\" IS NULL) OR + \"Status\" = 0");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageVersions_LanguageName",
                table: "LanguageVersions",
                column: "LanguageName");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageVersions_Name_LanguageName",
                table: "LanguageVersions",
                columns: new[] { "Name", "LanguageName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProblemResolveSessions_ProblemId",
                table: "ProblemResolveSessions",
                column: "ProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_ProblemResolveSessions_SessionId",
                table: "ProblemSolutions",
                column: "SessionId",
                principalTable: "ProblemResolveSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_RunningDetailsId",
                table: "ProblemSolutions",
                column: "RunningDetailsId",
                principalTable: "SolutionsRunningDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_LanguageVersions_LanguageId",
                table: "SolutionsRunningDetails",
                column: "LanguageId",
                principalTable: "LanguageVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
