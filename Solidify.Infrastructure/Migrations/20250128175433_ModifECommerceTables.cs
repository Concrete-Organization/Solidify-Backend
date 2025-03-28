﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solidify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifECommerceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_AspNetUsers_AdminId",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_companies_AspNetUsers_CompanyId",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySales_companies_CompanyId",
                table: "CompanySales");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_companies_CompanyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Companies");



            migrationBuilder.RenameIndex(
                name: "IX_companies_AdminId",
                table: "Companies",
                newName: "IX_Companies_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_AdminId",
                table: "Companies",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_CompanyId",
                table: "Companies",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySales_Companies_CompanyId",
                table: "CompanySales",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_AdminId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CompanyId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySales_Companies_CompanyId",
                table: "CompanySales");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "companies");

            migrationBuilder.RenameColumn(
                name: "ImageUri",
                table: "Products",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_AdminId",
                table: "companies",
                newName: "IX_companies_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_AspNetUsers_AdminId",
                table: "companies",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_AspNetUsers_CompanyId",
                table: "companies",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySales_companies_CompanyId",
                table: "CompanySales",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
