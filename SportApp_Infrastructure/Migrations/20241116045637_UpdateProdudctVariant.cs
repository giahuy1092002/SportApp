using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProdudctVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportProductVariant_Color_ColorId",
                table: "SportProductVariant");

            migrationBuilder.DropForeignKey(
                name: "FK_SportProductVariant_Size_SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_SportProductVariant_ColorId",
                table: "SportProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_SportProductVariant_SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "SportProductVariant");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "SportProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "SportProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "SportProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "SportProductVariant");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "SportProductVariant",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SizeId",
                table: "SportProductVariant",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportProductVariant_ColorId",
                table: "SportProductVariant",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SportProductVariant_SizeId",
                table: "SportProductVariant",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportProductVariant_Color_ColorId",
                table: "SportProductVariant",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SportProductVariant_Size_SizeId",
                table: "SportProductVariant",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id");
        }
    }
}
