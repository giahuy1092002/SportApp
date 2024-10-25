using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportField_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "SportField",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "SportField",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01ed94a5-a7b1-4bae-94b9-07a0a100d413"), null, false, "Admin", "ADMIN" },
                    { new Guid("6434014d-c6a7-4556-a4c0-4bc3536c351a"), null, false, "Spec", "SPEC" },
                    { new Guid("88ea7801-edf0-4b09-90c7-ecb4389a6e2e"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("ea066d5a-4206-4471-9765-7d4007b5aedd"), null, false, "Owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01ed94a5-a7b1-4bae-94b9-07a0a100d413"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6434014d-c6a7-4556-a4c0-4bc3536c351a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("88ea7801-edf0-4b09-90c7-ecb4389a6e2e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ea066d5a-4206-4471-9765-7d4007b5aedd"));

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "SportField",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "SportField",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}
