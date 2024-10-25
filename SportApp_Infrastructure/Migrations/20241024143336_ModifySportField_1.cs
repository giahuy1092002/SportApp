using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySportField_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SportFieldId",
                table: "Booking",
                column: "SportFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_SportField_SportFieldId",
                table: "Booking",
                column: "SportFieldId",
                principalTable: "SportField",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_SportField_SportFieldId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SportFieldId",
                table: "Booking");

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
    }
}
