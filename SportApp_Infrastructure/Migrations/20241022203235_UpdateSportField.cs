using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("087673f0-1769-4688-9baf-2afbf4c1e04f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16319d83-5002-43c7-a65a-bb6eba69c9c2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a117ed3c-67ea-4a58-ab4c-28accfd5392d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4544582-eeed-48a8-99de-5a2ac95c9216"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "SportField",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "SportField",
                type: "float",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01b12757-6c9e-4e20-8cd9-f4f4149cbcbc"), null, false, "Spec", "SPEC" },
                    { new Guid("3f83207f-c8da-4ce0-937b-35a8cbfced6b"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("a0a42199-7683-4223-917e-583eae933826"), null, false, "Owner", "OWNER" },
                    { new Guid("d60865c8-3e23-40dc-b210-2991552211c0"), null, false, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01b12757-6c9e-4e20-8cd9-f4f4149cbcbc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f83207f-c8da-4ce0-937b-35a8cbfced6b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0a42199-7683-4223-917e-583eae933826"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d60865c8-3e23-40dc-b210-2991552211c0"));

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "SportField");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "SportField");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("087673f0-1769-4688-9baf-2afbf4c1e04f"), null, false, "Admin", "ADMIN" },
                    { new Guid("16319d83-5002-43c7-a65a-bb6eba69c9c2"), null, false, "Owner", "OWNER" },
                    { new Guid("a117ed3c-67ea-4a58-ab4c-28accfd5392d"), null, false, "Spec", "SPEC" },
                    { new Guid("d4544582-eeed-48a8-99de-5a2ac95c9216"), null, false, "Customer", "CUSTOMER" }
                });
        }
    }
}
