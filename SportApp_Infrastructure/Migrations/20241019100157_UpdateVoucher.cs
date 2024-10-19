using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Owner_OwnerId",
                table: "Voucher");

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

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Voucher");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Voucher",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Owner_OwnerId",
                table: "Voucher",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Owner_OwnerId",
                table: "Voucher");

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

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Voucher");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Voucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Owner_OwnerId",
                table: "Voucher",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
