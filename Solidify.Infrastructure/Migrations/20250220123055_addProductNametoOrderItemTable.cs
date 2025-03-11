using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addProductNametoOrderItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingDetails_OrderId",
                table: "ShippingDetails");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_OrderId",
                table: "ShippingDetails",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShippingDetails_OrderId",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "RefreshToken",
                newName: "AccessToken");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_OrderId",
                table: "ShippingDetails",
                column: "OrderId");
        }
    }
}
