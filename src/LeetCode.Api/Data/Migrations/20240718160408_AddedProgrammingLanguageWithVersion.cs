using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProgrammingLanguageWithVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemRealizeDetails_Languages_LanguageId",
                table: "ProblemRealizeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_Languages_LanguageId",
                table: "ProblemSolutions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Languages_Name_Version",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "AdditionalDetails",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Languages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Languages_Name",
                table: "Languages",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "LanguagesWithVersion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Version = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RealizedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesWithVersion", x => x.Id);
                    table.UniqueConstraint("AK_LanguagesWithVersion_Name_Version", x => new { x.Name, x.Version });
                    table.ForeignKey(
                        name: "FK_LanguagesWithVersion_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LanguagesWithVersion_Languages_Name",
                        column: x => x.Name,
                        principalTable: "Languages",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguagesWithVersion_LanguageId",
                table: "LanguagesWithVersion",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemRealizeDetails_LanguagesWithVersion_LanguageId",
                table: "ProblemRealizeDetails",
                column: "LanguageId",
                principalTable: "LanguagesWithVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_LanguagesWithVersion_LanguageId",
                table: "ProblemSolutions",
                column: "LanguageId",
                principalTable: "LanguagesWithVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemRealizeDetails_LanguagesWithVersion_LanguageId",
                table: "ProblemRealizeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemSolutions_LanguagesWithVersion_LanguageId",
                table: "ProblemSolutions");

            migrationBuilder.DropTable(
                name: "LanguagesWithVersion");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Languages_Name",
                table: "Languages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<Dictionary<string, string>>(
                name: "AdditionalDetails",
                table: "Languages",
                type: "hstore",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Languages",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Languages_Name_Version",
                table: "Languages",
                columns: new[] { "Name", "Version" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemRealizeDetails_Languages_LanguageId",
                table: "ProblemRealizeDetails",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemSolutions_Languages_LanguageId",
                table: "ProblemSolutions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
