using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlot_Booking_BookingId",
                table: "BookingTimeSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlot_TimeSlot_TimeSlotId",
                table: "BookingTimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTimeSlot",
                table: "BookingTimeSlot");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41c5d0f9-87cb-43c2-9cdd-98d54d8d6d1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cf841b8-baae-4a83-8327-aaa8803c8c51"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a063072-cb47-45f8-8772-6c2f39ab5e52"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a48976b-c459-4e63-8480-1501569ebd6f"));

            migrationBuilder.RenameTable(
                name: "BookingTimeSlot",
                newName: "BookingTimeSlots");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTimeSlot_TimeSlotId",
                table: "BookingTimeSlots",
                newName: "IX_BookingTimeSlots_TimeSlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTimeSlots",
                table: "BookingTimeSlots",
                columns: new[] { "BookingId", "TimeSlotId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("243f76b7-b78c-4f18-9019-ea2d6988b109"), null, false, "Spec", "SPEC" },
                    { new Guid("56a48913-3791-4a6f-87b4-7604df6b4be3"), null, false, "Admin", "ADMIN" },
                    { new Guid("98a04ab1-ded7-4d7f-88a2-da7bddfd2b30"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("b0375aa8-4fa0-4e95-bb9e-18c16f35d9d2"), null, false, "Owner", "OWNER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlots_Booking_BookingId",
                table: "BookingTimeSlots",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlots_TimeSlot_TimeSlotId",
                table: "BookingTimeSlots",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlots_Booking_BookingId",
                table: "BookingTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTimeSlots_TimeSlot_TimeSlotId",
                table: "BookingTimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTimeSlots",
                table: "BookingTimeSlots");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("243f76b7-b78c-4f18-9019-ea2d6988b109"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56a48913-3791-4a6f-87b4-7604df6b4be3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98a04ab1-ded7-4d7f-88a2-da7bddfd2b30"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0375aa8-4fa0-4e95-bb9e-18c16f35d9d2"));

            migrationBuilder.RenameTable(
                name: "BookingTimeSlots",
                newName: "BookingTimeSlot");

            migrationBuilder.RenameIndex(
                name: "IX_BookingTimeSlots_TimeSlotId",
                table: "BookingTimeSlot",
                newName: "IX_BookingTimeSlot_TimeSlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTimeSlot",
                table: "BookingTimeSlot",
                columns: new[] { "BookingId", "TimeSlotId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("41c5d0f9-87cb-43c2-9cdd-98d54d8d6d1e"), null, false, "Spec", "SPEC" },
                    { new Guid("5cf841b8-baae-4a83-8327-aaa8803c8c51"), null, false, "Admin", "ADMIN" },
                    { new Guid("6a063072-cb47-45f8-8772-6c2f39ab5e52"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("6a48976b-c459-4e63-8480-1501569ebd6f"), null, false, "Owner", "OWNER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlot_Booking_BookingId",
                table: "BookingTimeSlot",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTimeSlot_TimeSlot_TimeSlotId",
                table: "BookingTimeSlot",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
