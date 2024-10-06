using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("05c0bd94-d726-468d-91af-51d2b38ec720"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17fef653-1924-47fd-a052-3c774474f17f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ba0d98b0-3e1f-4da2-b0fb-f409f81274ec"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f915a9bf-ce39-4833-ac7c-0076b3e61e10"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("23a37ea5-161c-4de9-841d-d8b238587dcd"), null, false, "Spec", "SPEC" },
                    { new Guid("2b84dcdf-ad25-4f44-9e96-f13492e0ad41"), null, false, "Admin", "ADMIN" },
                    { new Guid("851b2e8f-a3f2-45c0-8b8f-cb208b121948"), null, false, "Owner", "OWNER" },
                    { new Guid("85b93c5a-646b-4913-ae96-77654564497e"), null, false, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23a37ea5-161c-4de9-841d-d8b238587dcd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b84dcdf-ad25-4f44-9e96-f13492e0ad41"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("851b2e8f-a3f2-45c0-8b8f-cb208b121948"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("85b93c5a-646b-4913-ae96-77654564497e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05c0bd94-d726-468d-91af-51d2b38ec720"), null, false, "Admin", "ADMIN" },
                    { new Guid("17fef653-1924-47fd-a052-3c774474f17f"), null, false, "Owner", "OWNER" },
                    { new Guid("ba0d98b0-3e1f-4da2-b0fb-f409f81274ec"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("f915a9bf-ce39-4833-ac7c-0076b3e61e10"), null, false, "Spec", "SPEC" }
                });
        }
    }
}
