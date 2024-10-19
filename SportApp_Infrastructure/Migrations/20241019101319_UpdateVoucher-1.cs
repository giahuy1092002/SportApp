using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoucher1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a7db6f2-d777-44b4-a03a-d6e6abea9f4a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd3a2511-895d-4e13-b26f-44516aca0435"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc0a26bd-8f50-48b3-a517-fa762dd17515"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c78873-b7eb-46e5-845a-31d65aa86ce5"));

            migrationBuilder.AddColumn<long>(
                name: "MaxSale",
                table: "Voucher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MinPrice",
                table: "Voucher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "PercentSale",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0d916366-58ad-471d-9767-79d3ec27e885"), null, false, "Owner", "OWNER" },
                    { new Guid("22180d37-939b-422e-b893-dc6648ff9a65"), null, false, "Spec", "SPEC" },
                    { new Guid("29918533-13ed-444f-b3bd-c1d47ea068c4"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("a7b64d86-c7e3-478a-8df7-c1070048107d"), null, false, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0d916366-58ad-471d-9767-79d3ec27e885"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22180d37-939b-422e-b893-dc6648ff9a65"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("29918533-13ed-444f-b3bd-c1d47ea068c4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a7b64d86-c7e3-478a-8df7-c1070048107d"));

            migrationBuilder.DropColumn(
                name: "MaxSale",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "PercentSale",
                table: "Voucher");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6a7db6f2-d777-44b4-a03a-d6e6abea9f4a"), null, false, "Spec", "SPEC" },
                    { new Guid("bd3a2511-895d-4e13-b26f-44516aca0435"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("cc0a26bd-8f50-48b3-a517-fa762dd17515"), null, false, "Admin", "ADMIN" },
                    { new Guid("e2c78873-b7eb-46e5-845a-31d65aa86ce5"), null, false, "Owner", "OWNER" }
                });
        }
    }
}
