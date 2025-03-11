using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyWebSite",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FaceBookAccout",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "InstagramAccount",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PaymentTerm",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TwitterAccount",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "CommericalNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommericalNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebSite",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceBookAccout",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramAccount",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerm",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TwitterAccount",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
