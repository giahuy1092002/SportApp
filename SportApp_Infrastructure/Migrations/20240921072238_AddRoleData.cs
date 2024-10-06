using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("15ffe415-9303-402c-a576-fb0ed090ab0e"), null, "Spec", "SPEC" },
                    { new Guid("7e531baa-0e85-46a1-839f-6b354fe1c4ff"), null, "Admin", "ADMIN" },
                    { new Guid("91beea98-8f7c-424a-b68a-7318c8f1d204"), null, "Owner", "OWNER" },
                    { new Guid("adf3d6ba-dd2a-43b0-8964-94d94822b398"), null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("15ffe415-9303-402c-a576-fb0ed090ab0e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e531baa-0e85-46a1-839f-6b354fe1c4ff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91beea98-8f7c-424a-b68a-7318c8f1d204"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("adf3d6ba-dd2a-43b0-8964-94d94822b398"));
        }
    }
}
