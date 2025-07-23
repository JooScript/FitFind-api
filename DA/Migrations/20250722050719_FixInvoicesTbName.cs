using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Da.Migrations
{
    /// <inheritdoc />
    public partial class FixInvoicesTbName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tb_invoices",
                schema: "orders",
                newName: "TbInvoices",
                newSchema: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_tb_invoices_order_id",
                schema: "orders",
                table: "TbInvoices",
                newName: "IX_TbInvoices_order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TbInvoices",
                schema: "orders",
                newName: "tb_invoices",
                newSchema: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_TbInvoices_order_id",
                schema: "orders",
                table: "tb_invoices",
                newName: "IX_tb_invoices_order_id");
        }
    }
}
