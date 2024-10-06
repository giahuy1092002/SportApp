using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owner_AspNetUsers_UserId",
                table: "Owner");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("277076ca-cb82-4425-82b7-c1a15416f362"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3911e249-81cc-4795-90bf-ce3066723616"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a88f004-6cb4-47bc-9134-ee6e732e9b12"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bc8c737d-0f7b-43c4-bd53-93deec60f2aa"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Owner",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("038ad695-8c50-4d0b-b2dc-458dec6babac"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("67cd3214-ff48-4711-ac0b-59004af05fdd"), null, false, "Admin", "ADMIN" },
                    { new Guid("f50c93a6-2363-4700-822d-26bb7b16378c"), null, false, "Spec", "SPEC" },
                    { new Guid("f5935337-7938-4994-934b-1d8877841117"), null, false, "Owner", "OWNER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_AspNetUsers_UserId",
                table: "Owner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owner_AspNetUsers_UserId",
                table: "Owner");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("038ad695-8c50-4d0b-b2dc-458dec6babac"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("67cd3214-ff48-4711-ac0b-59004af05fdd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f50c93a6-2363-4700-822d-26bb7b16378c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5935337-7938-4994-934b-1d8877841117"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Owner",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("277076ca-cb82-4425-82b7-c1a15416f362"), null, false, "Owner", "OWNER" },
                    { new Guid("3911e249-81cc-4795-90bf-ce3066723616"), null, false, "Spec", "SPEC" },
                    { new Guid("9a88f004-6cb4-47bc-9134-ee6e732e9b12"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("bc8c737d-0f7b-43c4-bd53-93deec60f2aa"), null, false, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_AspNetUsers_UserId",
                table: "Owner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
