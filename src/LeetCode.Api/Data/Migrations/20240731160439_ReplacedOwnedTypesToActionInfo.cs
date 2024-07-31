using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeetCode.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReplacedOwnedTypesToActionInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "CreateInfo_CreatorId",
                table: "TestCases",
                newName: "CreateInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_CreateInfo_CreatorId",
                table: "TestCases",
                newName: "IX_TestCases_CreateInfo_AgentId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_DeleterId",
                table: "SolutionsRunningDetails",
                newName: "DeleteInfo_AgentId");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_CreatorId",
                table: "SolutionsRunningDetails",
                newName: "CreateInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_DeleteInfo_DeleterId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_DeleteInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_CreateInfo_CreatorId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_CreateInfo_AgentId");

            migrationBuilder.RenameColumn(
                name: "UpdateInfo_UpdaterId",
                table: "Problems",
                newName: "UpdateInfo_AgentId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_DeleterId",
                table: "Problems",
                newName: "DeleteInfo_AgentId");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_CreatorId",
                table: "Problems",
                newName: "CreateInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_UpdateInfo_UpdaterId",
                table: "Problems",
                newName: "IX_Problems_UpdateInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_DeleteInfo_DeleterId",
                table: "Problems",
                newName: "IX_Problems_DeleteInfo_AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_CreateInfo_CreatorId",
                table: "Problems",
                newName: "IX_Problems_CreateInfo_AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_CreateInfo_AgentId",
                table: "Problems",
                column: "CreateInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_DeleteInfo_AgentId",
                table: "Problems",
                column: "DeleteInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_AspNetUsers_UpdateInfo_AgentId",
                table: "Problems",
                column: "UpdateInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreateInfo_AgentId",
                table: "SolutionsRunningDetails",
                column: "CreateInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleteInfo_AgentId",
                table: "SolutionsRunningDetails",
                column: "DeleteInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCases_AspNetUsers_CreateInfo_AgentId",
                table: "TestCases",
                column: "CreateInfo_AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_CreateInfo_AgentId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_DeleteInfo_AgentId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_AspNetUsers_UpdateInfo_AgentId",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_CreateInfo_AgentId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsRunningDetails_AspNetUsers_DeleteInfo_AgentId",
                table: "SolutionsRunningDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCases_AspNetUsers_CreateInfo_AgentId",
                table: "TestCases");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_AgentId",
                table: "TestCases",
                newName: "CreateInfo_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_TestCases_CreateInfo_AgentId",
                table: "TestCases",
                newName: "IX_TestCases_CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_AgentId",
                table: "SolutionsRunningDetails",
                newName: "DeleteInfo_DeleterId");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_AgentId",
                table: "SolutionsRunningDetails",
                newName: "CreateInfo_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_DeleteInfo_AgentId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_DeleteInfo_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsRunningDetails_CreateInfo_AgentId",
                table: "SolutionsRunningDetails",
                newName: "IX_SolutionsRunningDetails_CreateInfo_CreatorId");

            migrationBuilder.RenameColumn(
                name: "UpdateInfo_AgentId",
                table: "Problems",
                newName: "UpdateInfo_UpdaterId");

            migrationBuilder.RenameColumn(
                name: "DeleteInfo_AgentId",
                table: "Problems",
                newName: "DeleteInfo_DeleterId");

            migrationBuilder.RenameColumn(
                name: "CreateInfo_AgentId",
                table: "Problems",
                newName: "CreateInfo_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_UpdateInfo_AgentId",
                table: "Problems",
                newName: "IX_Problems_UpdateInfo_UpdaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_DeleteInfo_AgentId",
                table: "Problems",
                newName: "IX_Problems_DeleteInfo_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_Problems_CreateInfo_AgentId",
                table: "Problems",
                newName: "IX_Problems_CreateInfo_CreatorId");

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
    }
}
