using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddeInheritanceInProblemSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_LanguagesWithVersion_LanguageId",
                table: "ProblemSolutions");

            migrationBuilder.DropTable(
                name: "ProblemRealizeDetails");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProblemSolutions_SessionId_SubmittedAt",
                table: "ProblemSolutions");

            migrationBuilder.DropIndex(
                name: "IX_ProblemSolutions_LanguageId",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProblemSolutions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedAt",
                table: "ProblemSolutions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "RunningDetailsId",
                table: "ProblemSolutions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProblemSolutions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalUsedMemory",
                table: "ProblemSolutions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalUsedTime",
                table: "ProblemSolutions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProblemSolutions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SolutionsRunningDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DefaultCode = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    WorkingSolution = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProblemId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionsRunningDetails", x => x.Id);
                    table.UniqueConstraint("AK_SolutionsRunningDetails_ProblemId_LanguageId", x => new { x.ProblemId, x.LanguageId });
                    table.CheckConstraint("DeleteInfoConflictCheck", "(\"DeletedAt\" IS NULL AND \"DeleterId\" IS NULL) OR (\"DeletedAt\" IS NOT NULL AND \"DeleterId\" IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_SolutionsRunningDetails_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionsRunningDetails_AspNetUsers_DeleterId",
                        column: x => x.DeleterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionsRunningDetails_LanguagesWithVersion_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguagesWithVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionsRunningDetails_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutions_RunningDetailsId",
                table: "ProblemSolutions",
                column: "RunningDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutions_SessionId",
                table: "ProblemSolutions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionsRunningDetails_CreatorId",
                table: "SolutionsRunningDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionsRunningDetails_DeleterId",
                table: "SolutionsRunningDetails",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionsRunningDetails_LanguageId",
                table: "SolutionsRunningDetails",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_RunningDetailsId",
                table: "ProblemSolutions",
                column: "RunningDetailsId",
                principalTable: "SolutionsRunningDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_SolutionsRunningDetails_RunningDetailsId",
                table: "ProblemSolutions");

            migrationBuilder.DropTable(
                name: "SolutionsRunningDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProblemSolutions_RunningDetailsId",
                table: "ProblemSolutions");

            migrationBuilder.DropIndex(
                name: "IX_ProblemSolutions_SessionId",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "RunningDetailsId",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "TotalUsedMemory",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "TotalUsedTime",
                table: "ProblemSolutions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProblemSolutions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmittedAt",
                table: "ProblemSolutions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                table: "ProblemSolutions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProblemSolutions_SessionId_SubmittedAt",
                table: "ProblemSolutions",
                columns: new[] { "SessionId", "SubmittedAt" });

            migrationBuilder.CreateTable(
                name: "ProblemRealizeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    ProblemId = table.Column<long>(type: "bigint", nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    DefaultCode = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    WorkingSolution = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemRealizeDetails", x => x.Id);
                    table.UniqueConstraint("AK_ProblemRealizeDetails_ProblemId_LanguageId", x => new { x.ProblemId, x.LanguageId });
                    table.CheckConstraint("DeleteInfoConflictCheck", "(\"DeletedAt\" IS NULL AND \"DeleterId\" IS NULL) OR (\"DeletedAt\" IS NOT NULL AND \"DeleterId\" IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_ProblemRealizeDetails_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemRealizeDetails_AspNetUsers_DeleterId",
                        column: x => x.DeleterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemRealizeDetails_LanguagesWithVersion_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguagesWithVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemRealizeDetails_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemSolutions_LanguageId",
                table: "ProblemSolutions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemRealizeDetails_CreatorId",
                table: "ProblemRealizeDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemRealizeDetails_DeleterId",
                table: "ProblemRealizeDetails",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemRealizeDetails_LanguageId",
                table: "ProblemRealizeDetails",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_LanguagesWithVersion_LanguageId",
                table: "ProblemSolutions",
                column: "LanguageId",
                principalTable: "LanguagesWithVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
