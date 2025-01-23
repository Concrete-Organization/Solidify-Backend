using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateEngineerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_AspNetUsers_UserId",
                table: "Engineers");

            migrationBuilder.DropIndex(
                name: "IX_Engineers_UserId",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Engineers");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_AspNetUsers_Id",
                table: "Engineers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_AspNetUsers_Id",
                table: "Engineers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Engineers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engineers_UserId",
                table: "Engineers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_AspNetUsers_UserId",
                table: "Engineers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
