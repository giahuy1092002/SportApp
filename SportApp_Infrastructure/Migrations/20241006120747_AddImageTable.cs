using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23a37ea5-161c-4de9-841d-d8b238587dcd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b84dcdf-ad25-4f44-9e96-f13492e0ad41"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("851b2e8f-a3f2-45c0-8b8f-cb208b121948"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("85b93c5a-646b-4913-ae96-77654564497e"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_SportField_SportFieldId",
                        column: x => x.SportFieldId,
                        principalTable: "SportField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5c038ee6-9818-4580-a53b-61c50942deef"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("6c8d6fb7-4213-4a32-81d7-9c61782a4980"), null, false, "Owner", "OWNER" },
                    { new Guid("7f541e10-6aca-4c77-ad55-264aeea4f5d4"), null, false, "Admin", "ADMIN" },
                    { new Guid("a801f811-9afe-495b-9872-1b0b425837f7"), null, false, "Spec", "SPEC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_SportFieldId",
                table: "Images",
                column: "SportFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c038ee6-9818-4580-a53b-61c50942deef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c8d6fb7-4213-4a32-81d7-9c61782a4980"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f541e10-6aca-4c77-ad55-264aeea4f5d4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a801f811-9afe-495b-9872-1b0b425837f7"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("23a37ea5-161c-4de9-841d-d8b238587dcd"), null, false, "Spec", "SPEC" },
                    { new Guid("2b84dcdf-ad25-4f44-9e96-f13492e0ad41"), null, false, "Admin", "ADMIN" },
                    { new Guid("851b2e8f-a3f2-45c0-8b8f-cb208b121948"), null, false, "Owner", "OWNER" },
                    { new Guid("85b93c5a-646b-4913-ae96-77654564497e"), null, false, "Customer", "CUSTOMER" }
                });
        }
    }
}
