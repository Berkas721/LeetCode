using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProblemRealizeDetailsAndLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Version = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.UniqueConstraint("AK_Languages_Name_Version", x => new { x.Name, x.Version });
                });

            migrationBuilder.CreateTable(
                name: "ProblemRealizeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    ProblemId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultCode = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    WorkingSolution = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    AdditionalDetails = table.Column<Dictionary<string, string>>(type: "hstore", nullable: false)
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
                        name: "FK_ProblemRealizeDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemRealizeDetails");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:hstore", ",,");
        }
    }
}
