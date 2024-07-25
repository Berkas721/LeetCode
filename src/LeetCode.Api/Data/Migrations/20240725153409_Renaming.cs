using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class Renaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_LanguagesWithVersion_LanguageId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropTable(
                name: "LanguagesWithVersion");

            migrationBuilder.CreateTable(
                name: "LanguageVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RealizedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    LanguageName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageVersions", x => x.Id);
                    table.UniqueConstraint("AK_LanguageVersions_Name_LanguageName", x => new { x.Name, x.LanguageName });
                    table.ForeignKey(
                        name: "FK_LanguageVersions_Languages_LanguageName",
                        column: x => x.LanguageName,
                        principalTable: "Languages",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageVersions_LanguageName",
                table: "LanguageVersions",
                column: "LanguageName");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_LanguageVersions_LanguageId",
                table: "SolutionsRunningDetails",
                column: "LanguageId",
                principalTable: "LanguageVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_LanguageVersions_LanguageId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropTable(
                name: "LanguageVersions");

            migrationBuilder.CreateTable(
                name: "LanguagesWithVersion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    ProgrammingLanguageId = table.Column<long>(type: "bigint", nullable: true),
                    RealizedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Version = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesWithVersion", x => x.Id);
                    table.UniqueConstraint("AK_LanguagesWithVersion_Name_Version", x => new { x.Name, x.Version });
                    table.ForeignKey(
                        name: "FK_LanguagesWithVersion_Languages_Name",
                        column: x => x.Name,
                        principalTable: "Languages",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagesWithVersion_Languages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguagesWithVersion_ProgrammingLanguageId",
                table: "LanguagesWithVersion",
                column: "ProgrammingLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_LanguagesWithVersion_LanguageId",
                table: "SolutionsRunningDetails",
                column: "LanguageId",
                principalTable: "LanguagesWithVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
