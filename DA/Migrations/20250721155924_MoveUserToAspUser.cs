using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Da.Migrations
{
    /// <inheritdoc />
    public partial class MoveUserToAspUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__addresses__user___3F466844",
                schema: "core",
                table: "tb_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK__inventory__user___5224328E",
                schema: "inventory",
                table: "tb_inventory_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK__order_sta__user___04E4BC85",
                schema: "orders",
                table: "tb_order_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK__orders__user_id__71D1E811",
                schema: "orders",
                table: "tb_orders");

            migrationBuilder.DropForeignKey(
                name: "FK__reviews__user_id__339FAB6E",
                schema: "customers",
                table: "tb_reviews");

            migrationBuilder.DropForeignKey(
                name: "FK__shopping___user___43D61337",
                schema: "customers",
                table: "tb_shopping_carts");

            migrationBuilder.DropForeignKey(
                name: "FK__subscript__user___15DA3E5D",
                schema: "orders",
                table: "tb_subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK__support_t__user___7A3223E8",
                schema: "core",
                table: "tb_support_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__ticket_re__user___00DF2177",
                schema: "core",
                table: "tb_ticket_replies");

            migrationBuilder.DropForeignKey(
                name: "FK__user_acti__user___04AFB25B",
                schema: "core",
                table: "tb_user_activity");

            migrationBuilder.DropForeignKey(
                name: "FK__wishlists__user___395884C4",
                schema: "customers",
                table: "tb_wishlists");

            migrationBuilder.DropTable(
                name: "tb_users",
                schema: "core");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "customers",
                table: "tb_wishlists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "core",
                table: "tb_user_activity",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "core",
                table: "tb_ticket_replies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "core",
                table: "tb_support_tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "orders",
                table: "tb_subscriptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "customers",
                table: "tb_shopping_carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "customers",
                table: "tb_reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "orders",
                table: "tb_orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "orders",
                table: "tb_order_status_history",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "inventory",
                table: "tb_inventory_transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                schema: "core",
                table: "tb_addresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__addresses__user___3F466844",
                schema: "core",
                table: "tb_addresses",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__inventory__user___5224328E",
                schema: "inventory",
                table: "tb_inventory_transactions",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__order_sta__user___04E4BC85",
                schema: "orders",
                table: "tb_order_status_history",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__user_id__71D1E811",
                schema: "orders",
                table: "tb_orders",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__reviews__user_id__339FAB6E",
                schema: "customers",
                table: "tb_reviews",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__shopping___user___43D61337",
                schema: "customers",
                table: "tb_shopping_carts",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__subscript__user___15DA3E5D",
                schema: "orders",
                table: "tb_subscriptions",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__support_t__user___7A3223E8",
                schema: "core",
                table: "tb_support_tickets",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ticket_re__user___00DF2177",
                schema: "core",
                table: "tb_ticket_replies",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__user_acti__user___04AFB25B",
                schema: "core",
                table: "tb_user_activity",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__wishlists__user___395884C4",
                schema: "customers",
                table: "tb_wishlists",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__addresses__user___3F466844",
                schema: "core",
                table: "tb_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK__inventory__user___5224328E",
                schema: "inventory",
                table: "tb_inventory_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK__order_sta__user___04E4BC85",
                schema: "orders",
                table: "tb_order_status_history");

            migrationBuilder.DropForeignKey(
                name: "FK__orders__user_id__71D1E811",
                schema: "orders",
                table: "tb_orders");

            migrationBuilder.DropForeignKey(
                name: "FK__reviews__user_id__339FAB6E",
                schema: "customers",
                table: "tb_reviews");

            migrationBuilder.DropForeignKey(
                name: "FK__shopping___user___43D61337",
                schema: "customers",
                table: "tb_shopping_carts");

            migrationBuilder.DropForeignKey(
                name: "FK__subscript__user___15DA3E5D",
                schema: "orders",
                table: "tb_subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK__support_t__user___7A3223E8",
                schema: "core",
                table: "tb_support_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__ticket_re__user___00DF2177",
                schema: "core",
                table: "tb_ticket_replies");

            migrationBuilder.DropForeignKey(
                name: "FK__user_acti__user___04AFB25B",
                schema: "core",
                table: "tb_user_activity");

            migrationBuilder.DropForeignKey(
                name: "FK__wishlists__user___395884C4",
                schema: "customers",
                table: "tb_wishlists");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "customers",
                table: "tb_wishlists",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "core",
                table: "tb_user_activity",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "core",
                table: "tb_ticket_replies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "core",
                table: "tb_support_tickets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "orders",
                table: "tb_subscriptions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "customers",
                table: "tb_shopping_carts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "customers",
                table: "tb_reviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "orders",
                table: "tb_orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "orders",
                table: "tb_order_status_history",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "inventory",
                table: "tb_inventory_transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "core",
                table: "tb_addresses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tb_users",
                schema: "core",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__B9BE370F80EEC35F", x => x.user_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK__addresses__user___3F466844",
                schema: "core",
                table: "tb_addresses",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__inventory__user___5224328E",
                schema: "inventory",
                table: "tb_inventory_transactions",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__order_sta__user___04E4BC85",
                schema: "orders",
                table: "tb_order_status_history",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__user_id__71D1E811",
                schema: "orders",
                table: "tb_orders",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__reviews__user_id__339FAB6E",
                schema: "customers",
                table: "tb_reviews",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__shopping___user___43D61337",
                schema: "customers",
                table: "tb_shopping_carts",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__subscript__user___15DA3E5D",
                schema: "orders",
                table: "tb_subscriptions",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__support_t__user___7A3223E8",
                schema: "core",
                table: "tb_support_tickets",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__ticket_re__user___00DF2177",
                schema: "core",
                table: "tb_ticket_replies",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__user_acti__user___04AFB25B",
                schema: "core",
                table: "tb_user_activity",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK__wishlists__user___395884C4",
                schema: "customers",
                table: "tb_wishlists",
                column: "user_id",
                principalSchema: "core",
                principalTable: "tb_users",
                principalColumn: "user_id");
        }
    }
}
