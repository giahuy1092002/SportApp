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
                keyValue: new Guid("02f3e445-6897-42be-8b15-78c65d42ef10"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a94b10f-45bc-407b-b597-4b147aab6df9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("375c2405-26b9-41ab-9e79-aaa97cd930a9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ce61073-508d-401a-98ed-452c9852d4a3"));

            migrationBuilder.AddColumn<Guid>(
                name: "SpecId",
                table: "Booking",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SpecId",
                table: "Booking",
                column: "SpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Spec_SpecId",
                table: "Booking",
                column: "SpecId",
                principalTable: "Spec",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Spec_SpecId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_SpecId",
                table: "Booking");

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

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "Booking");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("02f3e445-6897-42be-8b15-78c65d42ef10"), null, false, "Spec", "SPEC" },
                    { new Guid("2a94b10f-45bc-407b-b597-4b147aab6df9"), null, false, "Admin", "ADMIN" },
                    { new Guid("375c2405-26b9-41ab-9e79-aaa97cd930a9"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("9ce61073-508d-401a-98ed-452c9852d4a3"), null, false, "Owner", "OWNER" }
                });
        }
    }
}
