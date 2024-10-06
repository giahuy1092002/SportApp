using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportField_Owner_OwnerId",
                table: "SportField");

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
                name: "OwnerId",
                table: "SportField",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<long>(type: "bigint", nullable: true),
                    Weight = table.Column<long>(type: "bigint", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05f8d86f-f13c-40e6-95fa-5f89fa513194"), null, false, "Admin", "ADMIN" },
                    { new Guid("22a9ee5a-0cc3-47cc-a189-e61004fe4bf6"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("63843a8d-9cf2-47a5-bc92-fbc6d3768b4b"), null, false, "Owner", "OWNER" },
                    { new Guid("b0280d50-19ed-4223-a4ba-6bb7edf187ac"), null, false, "Spec", "SPEC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportField_Owner_OwnerId",
                table: "SportField",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportField_Owner_OwnerId",
                table: "SportField");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("05f8d86f-f13c-40e6-95fa-5f89fa513194"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22a9ee5a-0cc3-47cc-a189-e61004fe4bf6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63843a8d-9cf2-47a5-bc92-fbc6d3768b4b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0280d50-19ed-4223-a4ba-6bb7edf187ac"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "SportField",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_SportField_Owner_OwnerId",
                table: "SportField",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }
    }
}
