using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2847356c-0cc6-40f6-97b8-b0560f60de2a"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("6d37e6ba-1ee1-40f1-b9d2-bb1dc376b7e4"), null, false, "Spec", "SPEC" },
                    { new Guid("7fa9a1eb-10d7-4c95-ba80-c8c88b648d53"), null, false, "Owner", "OWNER" },
                    { new Guid("99a13e66-3ed5-42ee-855a-71c92a4a370f"), null, false, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2847356c-0cc6-40f6-97b8-b0560f60de2a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d37e6ba-1ee1-40f1-b9d2-bb1dc376b7e4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7fa9a1eb-10d7-4c95-ba80-c8c88b648d53"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("99a13e66-3ed5-42ee-855a-71c92a4a370f"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "SportField",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "SportField",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
    }
}
