using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("40ad8448-e6b1-4944-a9f2-882c8acf1a88"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("befd05ce-0a56-4193-ac2d-8808455372bf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9226b7d-6cf0-4675-bae9-ce1022dd2a83"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd4b1969-58b2-440d-bb8d-ee288e938b17"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Booking");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("40ad8448-e6b1-4944-a9f2-882c8acf1a88"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("befd05ce-0a56-4193-ac2d-8808455372bf"), null, false, "Owner", "OWNER" },
                    { new Guid("c9226b7d-6cf0-4675-bae9-ce1022dd2a83"), null, false, "Admin", "ADMIN" },
                    { new Guid("dd4b1969-58b2-440d-bb8d-ee288e938b17"), null, false, "Spec", "SPEC" }
                });
        }
    }
}
