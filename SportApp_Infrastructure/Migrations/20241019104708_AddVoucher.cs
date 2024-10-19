using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Owner_OwnerId",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher");

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

            migrationBuilder.RenameTable(
                name: "Voucher",
                newName: "Vouchers");

            migrationBuilder.RenameIndex(
                name: "IX_Voucher_OwnerId",
                table: "Vouchers",
                newName: "IX_Vouchers_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Owner_OwnerId",
                table: "Vouchers",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Owner_OwnerId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

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

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "Voucher");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_OwnerId",
                table: "Voucher",
                newName: "IX_Voucher_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Owner_OwnerId",
                table: "Voucher",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }
    }
}
