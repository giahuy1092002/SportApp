using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<long>(
                name: "BuyPrice",
                table: "SportEquipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "SportEquipments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "RentPrice",
                table: "SportEquipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1344a125-84db-439b-abdd-02d7a3895d78"), null, false, "Spec", "SPEC" },
                    { new Guid("19ab472b-4636-4f32-94f3-e5740406eb4c"), null, false, "Owner", "OWNER" },
                    { new Guid("4863238b-4289-4d33-94e6-87859c381986"), null, false, "Admin", "ADMIN" },
                    { new Guid("dd063a47-3942-415c-b8ca-2dd760e4d02d"), null, false, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1344a125-84db-439b-abdd-02d7a3895d78"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("19ab472b-4636-4f32-94f3-e5740406eb4c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4863238b-4289-4d33-94e6-87859c381986"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd063a47-3942-415c-b8ca-2dd760e4d02d"));

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "SportEquipments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "SportEquipments");

            migrationBuilder.DropColumn(
                name: "RentPrice",
                table: "SportEquipments");

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
    }
}
