using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixVoucherNotInvalid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoucherId",
                table: "Booking",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherId",
                table: "Booking");
        }
    }
}
