using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCommunityEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngineerId",
                table: "Reply",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_EngineerId",
                table: "Reply",
                column: "EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Engineers_EngineerId",
                table: "Reply",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Engineers_EngineerId",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Reply_EngineerId",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "EngineerId",
                table: "Reply");
        }
    }
}
