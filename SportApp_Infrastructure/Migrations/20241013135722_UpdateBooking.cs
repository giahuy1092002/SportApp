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
                keyValue: new Guid("188f2717-cfc0-4245-8587-b97b3bc314db"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0d9e5f-60cf-4f9e-a1b3-27d9a40b3534"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("69891d08-3565-4aa9-a7d9-2525bca8e569"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a16d380c-bd4b-4d3c-b122-7c615de38c56"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("65087d6d-5d77-4530-80e7-360dcab39562"), null, false, "Spec", "SPEC" },
                    { new Guid("7aaf5675-e36e-4629-8075-13c26a54542e"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("822e1fe7-9a83-4a53-b76c-d39fe7cb059c"), null, false, "Admin", "ADMIN" },
                    { new Guid("a34e4f14-b59b-4d70-9c68-017ff9be5264"), null, false, "Owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65087d6d-5d77-4530-80e7-360dcab39562"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7aaf5675-e36e-4629-8075-13c26a54542e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("822e1fe7-9a83-4a53-b76c-d39fe7cb059c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a34e4f14-b59b-4d70-9c68-017ff9be5264"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("188f2717-cfc0-4245-8587-b97b3bc314db"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("2f0d9e5f-60cf-4f9e-a1b3-27d9a40b3534"), null, false, "Admin", "ADMIN" },
                    { new Guid("69891d08-3565-4aa9-a7d9-2525bca8e569"), null, false, "Spec", "SPEC" },
                    { new Guid("a16d380c-bd4b-4d3c-b122-7c615de38c56"), null, false, "Owner", "OWNER" }
                });
        }
    }
}
