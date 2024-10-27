using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexEndpointForSportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("906354d6-3ebb-4116-8cc7-8fb4af881075"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2dbd52d-902a-4094-bd1f-990dbbc7b50e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be89b58a-d023-4125-9320-2f8c73fd0d19"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddd82768-66f2-44b3-9b0f-9cee21d8d54c"));

            migrationBuilder.AlterColumn<string>(
                name: "EndPoint",
                table: "SportField",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("21253a72-a819-4e69-b925-f95496691977"), null, false, "Owner", "OWNER" },
                    { new Guid("2401b5d7-87ec-4288-8bff-917e81c288b3"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("728adb98-719f-4152-8069-4d6e79210b46"), null, false, "Admin", "ADMIN" },
                    { new Guid("aaebfc0a-9e77-434c-b96f-c7e4f4ad4f93"), null, false, "Spec", "SPEC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportField_Endpoint",
                table: "SportField",
                column: "EndPoint",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SportField_Endpoint",
                table: "SportField");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21253a72-a819-4e69-b925-f95496691977"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2401b5d7-87ec-4288-8bff-917e81c288b3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("728adb98-719f-4152-8069-4d6e79210b46"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aaebfc0a-9e77-434c-b96f-c7e4f4ad4f93"));

            migrationBuilder.AlterColumn<string>(
                name: "EndPoint",
                table: "SportField",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("906354d6-3ebb-4116-8cc7-8fb4af881075"), null, false, "Spec", "SPEC" },
                    { new Guid("a2dbd52d-902a-4094-bd1f-990dbbc7b50e"), null, false, "Owner", "OWNER" },
                    { new Guid("be89b58a-d023-4125-9320-2f8c73fd0d19"), null, false, "Admin", "ADMIN" },
                    { new Guid("ddd82768-66f2-44b3-9b0f-9cee21d8d54c"), null, false, "Customer", "CUSTOMER" }
                });
        }
    }
}
