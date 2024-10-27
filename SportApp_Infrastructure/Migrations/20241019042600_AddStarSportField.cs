using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStarSportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Starts",
                table: "SportField",
                type: "decimal(2,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantityInStock",
                table: "SportEquipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_OwnerId",
                table: "Voucher",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voucher");

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

            migrationBuilder.DropColumn(
                name: "Starts",
                table: "SportField");

            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "SportEquipments");

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
    }
}
