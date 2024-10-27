using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSportEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "SportEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEquipments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0da37efb-3c33-4abd-a764-c41d958d51e8"), null, false, "Owner", "OWNER" },
                    { new Guid("44f01e97-a7b2-489c-ab65-b19e732e0b31"), null, false, "Admin", "ADMIN" },
                    { new Guid("5008657d-83b9-4c2d-884e-5a16be1f45bd"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("d5592c05-55ab-480e-9b05-89137975023f"), null, false, "Spec", "SPEC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportEquipments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0da37efb-3c33-4abd-a764-c41d958d51e8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("44f01e97-a7b2-489c-ab65-b19e732e0b31"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5008657d-83b9-4c2d-884e-5a16be1f45bd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d5592c05-55ab-480e-9b05-89137975023f"));

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
        }
    }
}
