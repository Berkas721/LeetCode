using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUselessPropertiesInLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageName_VersionName",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "AdditionalDetails",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "RealizedAt",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "VersionName",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageName",
                schema: "leetcode",
                table: "Languages",
                column: "LanguageName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageName",
                schema: "leetcode",
                table: "Languages");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "AdditionalDetails",
                schema: "leetcode",
                table: "Languages",
                type: "hstore",
                nullable: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "RealizedAt",
                schema: "leetcode",
                table: "Languages",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "VersionName",
                schema: "leetcode",
                table: "Languages",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageName_VersionName",
                schema: "leetcode",
                table: "Languages",
                columns: new[] { "LanguageName", "VersionName" },
                unique: true);
        }
    }
}
