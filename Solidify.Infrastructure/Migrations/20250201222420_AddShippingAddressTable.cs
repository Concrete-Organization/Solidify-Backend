using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ShippingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_AddressId",
                table: "ShippingDetails",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetails_ShippingAddress_AddressId",
                table: "ShippingDetails",
                column: "AddressId",
                principalTable: "ShippingAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetails_ShippingAddress_AddressId",
                table: "ShippingDetails");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropIndex(
                name: "IX_ShippingDetails_AddressId",
                table: "ShippingDetails");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ShippingDetails");
        }
    }
}
