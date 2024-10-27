using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1966a576-4920-47dd-83a8-feea504dbda3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b6a7e0f-353a-4a71-bb82-bb680b225d25"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1a28158-966a-4716-9b82-9c593bc1e934"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d25e1dab-a430-4b20-b8e5-78486016935c"));

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfStar = table.Column<int>(type: "int", nullable: false),
                    SportFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_SportField_SportFieldId",
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
                    { new Guid("906354d6-3ebb-4116-8cc7-8fb4af881075"), null, false, "Spec", "SPEC" },
                    { new Guid("a2dbd52d-902a-4094-bd1f-990dbbc7b50e"), null, false, "Owner", "OWNER" },
                    { new Guid("be89b58a-d023-4125-9320-2f8c73fd0d19"), null, false, "Admin", "ADMIN" },
                    { new Guid("ddd82768-66f2-44b3-9b0f-9cee21d8d54c"), null, false, "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerId",
                table: "Ratings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SportFieldId",
                table: "Ratings",
                column: "SportFieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("906354d6-3ebb-4116-8cc7-8fb4af881075"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2dbd52d-902a-4094-bd1f-990dbbc7b50e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be89b58a-d023-4125-9320-2f8c73fd0d19"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddd82768-66f2-44b3-9b0f-9cee21d8d54c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1966a576-4920-47dd-83a8-feea504dbda3"), null, false, "Owner", "OWNER" },
                    { new Guid("7b6a7e0f-353a-4a71-bb82-bb680b225d25"), null, false, "Customer", "CUSTOMER" },
                    { new Guid("d1a28158-966a-4716-9b82-9c593bc1e934"), null, false, "Spec", "SPEC" },
                    { new Guid("d25e1dab-a430-4b20-b8e5-78486016935c"), null, false, "Admin", "ADMIN" }
                });
        }
    }
}
