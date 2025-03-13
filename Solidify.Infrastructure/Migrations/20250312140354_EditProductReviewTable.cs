using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditProductReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteCompanies_AspNetUsers_CompanyId",
                table: "ConcreteCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_AspNetUsers_UserId",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProductReviews",
                newName: "ConcreteCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                newName: "IX_ProductReviews_ConcreteCompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ConcreteCompanies",
                newName: "ConcreteCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteCompanies_AspNetUsers_ConcreteCompanyId",
                table: "ConcreteCompanies",
                column: "ConcreteCompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_ConcreteCompanies_ConcreteCompanyId",
                table: "ProductReviews",
                column: "ConcreteCompanyId",
                principalTable: "ConcreteCompanies",
                principalColumn: "ConcreteCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteCompanies_AspNetUsers_ConcreteCompanyId",
                table: "ConcreteCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_ConcreteCompanies_ConcreteCompanyId",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "ConcreteCompanyId",
                table: "ProductReviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductReviews_ConcreteCompanyId",
                table: "ProductReviews",
                newName: "IX_ProductReviews_UserId");

            migrationBuilder.RenameColumn(
                name: "ConcreteCompanyId",
                table: "ConcreteCompanies",
                newName: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteCompanies_AspNetUsers_CompanyId",
                table: "ConcreteCompanies",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_AspNetUsers_UserId",
                table: "ProductReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
