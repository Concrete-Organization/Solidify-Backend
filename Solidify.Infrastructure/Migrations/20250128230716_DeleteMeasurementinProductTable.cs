using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMeasurementinProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
