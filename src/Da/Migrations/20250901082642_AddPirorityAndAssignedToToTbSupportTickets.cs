using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Da.Migrations
{
    /// <inheritdoc />
    public partial class AddPirorityAndAssignedToToTbSupportTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedTo",
                schema: "core",
                table: "TbSupportTickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "core",
                table: "TbSupportTickets",
                type: "int",
                nullable: false,
                defaultValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTo",
                schema: "core",
                table: "TbSupportTickets");

            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "core",
                table: "TbSupportTickets");
        }
    }
}
