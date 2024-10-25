using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeslot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12a530b0-20e9-4045-9f78-5f271fc268e8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4fa86ed0-b4a4-4a7e-bd66-e7b67ba2d473"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c0b8f6e-2e4c-46bf-8792-219ce957c687"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a9d1c5e9-4ea1-4865-823d-f50fa8a16760"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TimeSlot");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Booking");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TimeSlot",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("12a530b0-20e9-4045-9f78-5f271fc268e8"), null, false, "Owner", "OWNER" },
                    { new Guid("4fa86ed0-b4a4-4a7e-bd66-e7b67ba2d473"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("9c0b8f6e-2e4c-46bf-8792-219ce957c687"), null, false, "Spec", "SPEC" },
                    { new Guid("a9d1c5e9-4ea1-4865-823d-f50fa8a16760"), null, false, "Admin", "ADMIN" }
                });
        }
    }
}
