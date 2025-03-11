using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommunityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "EngineerId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                newName: "IX_Posts_EngineerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "EngineerId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                newName: "IX_Likes_EngineerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "EngineerId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Engineers_EngineerId",
                table: "Comments",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Engineers_EngineerId",
                table: "Likes",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Engineers_EngineerId",
                table: "Posts",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Engineers_EngineerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteCompanies_AspNetUsers_CompanyId",
                table: "ConcreteCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Engineers_EngineerId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Engineers_EngineerId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_EngineerId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_EngineerId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_EngineerId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Company_AspNetUsers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
