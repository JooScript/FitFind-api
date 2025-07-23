using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Da.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditColsToTbCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "products",
                table: "TbCategories",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                schema: "products",
                table: "TbCategories",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbCategories_ModifiedBy",
                schema: "products",
                table: "TbCategories",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_User",
                schema: "products",
                table: "TbCategories",
                column: "ModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_User",
                schema: "products",
                table: "TbCategories");

            migrationBuilder.DropIndex(
                name: "IX_TbCategories_ModifiedBy",
                schema: "products",
                table: "TbCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "products",
                table: "TbCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "products",
                table: "TbCategories");
        }
    }
}
