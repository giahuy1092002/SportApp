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
                keyValue: new Guid("65087d6d-5d77-4530-80e7-360dcab39562"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7aaf5675-e36e-4629-8075-13c26a54542e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("822e1fe7-9a83-4a53-b76c-d39fe7cb059c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a34e4f14-b59b-4d70-9c68-017ff9be5264"));

            migrationBuilder.AddColumn<string>(
                name: "EndPoint",
                table: "SportField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1966a576-4920-47dd-83a8-feea504dbda3"), null, false, "Owner", "OWNER" },
                    { new Guid("7b6a7e0f-353a-4a71-bb82-bb680b225d25"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("d1a28158-966a-4716-9b82-9c593bc1e934"), null, false, "Spec", "SPEC" },
                    { new Guid("d25e1dab-a430-4b20-b8e5-78486016935c"), null, false, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1966a576-4920-47dd-83a8-feea504dbda3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b6a7e0f-353a-4a71-bb82-bb680b225d25"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1a28158-966a-4716-9b82-9c593bc1e934"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d25e1dab-a430-4b20-b8e5-78486016935c"));

            migrationBuilder.DropColumn(
                name: "EndPoint",
                table: "SportField");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("65087d6d-5d77-4530-80e7-360dcab39562"), null, false, "Spec", "SPEC" },
                    { new Guid("7aaf5675-e36e-4629-8075-13c26a54542e"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("822e1fe7-9a83-4a53-b76c-d39fe7cb059c"), null, false, "Admin", "ADMIN" },
                    { new Guid("a34e4f14-b59b-4d70-9c68-017ff9be5264"), null, false, "Owner", "OWNER" }
                });
        }
    }
}
