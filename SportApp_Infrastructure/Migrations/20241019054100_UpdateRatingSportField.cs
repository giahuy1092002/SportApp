using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRatingSportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("07fcc0fd-c599-4a8c-8f75-fde77d075667"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("325580f5-0789-44ba-a151-2e37577d2373"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("38b4c0ea-e38c-4759-975d-a8a3ebabccd5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4805d451-9bb6-4270-9068-e6bd3143c7d9"));

            migrationBuilder.RenameColumn(
                name: "Starts",
                table: "SportField",
                newName: "Stars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("019e8f1d-d0cf-4b55-9eb8-93980afe2416"), null, false, "Admin", "ADMIN" },
                    { new Guid("01d257b4-09a4-40a6-b507-79678d38d05f"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("0ae54ca4-8c41-4026-b1cd-1bf200cd0ac8"), null, false, "Owner", "OWNER" },
                    { new Guid("be39637f-52ba-49d8-9dbf-da79badbc894"), null, false, "Spec", "SPEC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("019e8f1d-d0cf-4b55-9eb8-93980afe2416"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01d257b4-09a4-40a6-b507-79678d38d05f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ae54ca4-8c41-4026-b1cd-1bf200cd0ac8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be39637f-52ba-49d8-9dbf-da79badbc894"));

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "SportField",
                newName: "Starts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("07fcc0fd-c599-4a8c-8f75-fde77d075667"), null, false, "Spec", "SPEC" },
                    { new Guid("325580f5-0789-44ba-a151-2e37577d2373"), null, false, "Admin", "ADMIN" },
                    { new Guid("38b4c0ea-e38c-4759-975d-a8a3ebabccd5"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("4805d451-9bb6-4270-9068-e6bd3143c7d9"), null, false, "Owner", "OWNER" }
                });
        }
    }
}
