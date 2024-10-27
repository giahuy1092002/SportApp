using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("573afd78-9fd6-4162-a1f0-232f8971ae13"), null, false, "Admin", "ADMIN" },
                    { new Guid("5c88e571-c304-43b7-98a8-fd512762c19a"), null, false, "Spec", "SPEC" },
                    { new Guid("92554280-62d4-4b87-b3af-d643d71436e0"), null, false, "Owner", "OWNER" },
                    { new Guid("9a767e46-3777-401e-8164-4ad457d2c35c"), null, false, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("573afd78-9fd6-4162-a1f0-232f8971ae13"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c88e571-c304-43b7-98a8-fd512762c19a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92554280-62d4-4b87-b3af-d643d71436e0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a767e46-3777-401e-8164-4ad457d2c35c"));

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
        }
    }
}
