using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoucher2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("043b068a-ebf2-444a-8ef4-a8082c8295b2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e5f1e8d-adbd-47f1-bc63-aeba78d8b8cf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("504a7418-853e-4002-a624-fbb35624e294"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0f1ebdb-9b53-4476-8164-e0d0b0669b92"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("49efa9df-510b-4f27-98a3-9cd31214923f"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("956db8dc-4b7e-479d-b8c2-7a34da1f185d"), null, false, "Spec", "SPEC" },
                    { new Guid("cb3d9cf0-cbdb-4fdf-acde-63fede1fe00b"), null, false, "Admin", "ADMIN" },
                    { new Guid("efc586e7-a969-4f88-9d2b-11865ef0d0e3"), null, false, "Owner", "OWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("49efa9df-510b-4f27-98a3-9cd31214923f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("956db8dc-4b7e-479d-b8c2-7a34da1f185d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb3d9cf0-cbdb-4fdf-acde-63fede1fe00b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("efc586e7-a969-4f88-9d2b-11865ef0d0e3"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("043b068a-ebf2-444a-8ef4-a8082c8295b2"), null, false, "Owner", "OWNER" },
                    { new Guid("0e5f1e8d-adbd-47f1-bc63-aeba78d8b8cf"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("504a7418-853e-4002-a624-fbb35624e294"), null, false, "Admin", "ADMIN" },
                    { new Guid("a0f1ebdb-9b53-4476-8164-e0d0b0669b92"), null, false, "Spec", "SPEC" }
                });
        }
    }
}
