using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("05f8d86f-f13c-40e6-95fa-5f89fa513194"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22a9ee5a-0cc3-47cc-a189-e61004fe4bf6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63843a8d-9cf2-47a5-bc92-fbc6d3768b4b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0280d50-19ed-4223-a4ba-6bb7edf187ac"));

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "TimeSlot",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "TimeSlot",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("310e3799-4cf6-44d3-beb4-f67a1e56cbbe"), null, false, "Admin", "ADMIN" },
                    { new Guid("4230cc7f-2e2c-452b-bec5-22197045d205"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("938b20b3-d843-415b-a78f-659b00b29ec7"), null, false, "Owner", "OWNER" },
                    { new Guid("cc85b346-368f-479b-bc2b-a7e75f572323"), null, false, "Spec", "SPEC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("310e3799-4cf6-44d3-beb4-f67a1e56cbbe"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4230cc7f-2e2c-452b-bec5-22197045d205"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("938b20b3-d843-415b-a78f-659b00b29ec7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc85b346-368f-479b-bc2b-a7e75f572323"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeSlot",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeSlot",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05f8d86f-f13c-40e6-95fa-5f89fa513194"), null, false, "Admin", "ADMIN" },
                    { new Guid("22a9ee5a-0cc3-47cc-a189-e61004fe4bf6"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("63843a8d-9cf2-47a5-bc92-fbc6d3768b4b"), null, false, "Owner", "OWNER" },
                    { new Guid("b0280d50-19ed-4223-a4ba-6bb7edf187ac"), null, false, "Spec", "SPEC" }
                });
        }
    }
}
