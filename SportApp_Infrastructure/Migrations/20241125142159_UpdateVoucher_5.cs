using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoucher_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Owner_OwnerId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_OwnerId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Vouchers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Vouchers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_OwnerId",
                table: "Vouchers",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Owner_OwnerId",
                table: "Vouchers",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id");
        }
    }
}
