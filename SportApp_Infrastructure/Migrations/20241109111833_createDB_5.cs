using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createDB_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpecId",
                table: "Booking",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SpecId",
                table: "Booking",
                column: "SpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Spec_SpecId",
                table: "Booking",
                column: "SpecId",
                principalTable: "Spec",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Spec_SpecId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SpecId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "Booking");
        }
    }
}
