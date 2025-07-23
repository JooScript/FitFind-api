using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Da.Migrations
{
    /// <inheritdoc />
    public partial class FixSeoMetaName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TbSeoMata",
                schema: "products",
                table: "TbSeoMata");

            migrationBuilder.RenameTable(
                name: "TbSeoMata",
                schema: "products",
                newName: "TbSeoMeta",
                newSchema: "products");

            migrationBuilder.RenameIndex(
                name: "IX_TbSeoMata_product_id",
                schema: "products",
                table: "TbSeoMeta",
                newName: "IX_TbSeoMeta_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbSeoMeta",
                schema: "products",
                table: "TbSeoMeta",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TbSeoMeta",
                schema: "products",
                table: "TbSeoMeta");

            migrationBuilder.RenameTable(
                name: "TbSeoMeta",
                schema: "products",
                newName: "TbSeoMata",
                newSchema: "products");

            migrationBuilder.RenameIndex(
                name: "IX_TbSeoMeta_product_id",
                schema: "products",
                table: "TbSeoMata",
                newName: "IX_TbSeoMata_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbSeoMata",
                schema: "products",
                table: "TbSeoMata",
                column: "Id");
        }
    }
}
