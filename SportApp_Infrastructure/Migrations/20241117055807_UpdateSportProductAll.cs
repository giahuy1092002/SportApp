using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportProductAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportProductVariant_Size_SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_SportProductVariant_SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "SportProductVariant");

            migrationBuilder.AddColumn<int>(
                name: "QuantityInStock",
                table: "Size",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SportProductVariantId",
                table: "Size",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ImageProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportProductVariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageProduct_SportProductVariant_SportProductVariantId",
                        column: x => x.SportProductVariantId,
                        principalTable: "SportProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_SportProductVariantId",
                table: "Size",
                column: "SportProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProduct_SportProductVariantId",
                table: "ImageProduct",
                column: "SportProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Size_SportProductVariant_SportProductVariantId",
                table: "Size",
                column: "SportProductVariantId",
                principalTable: "SportProductVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Size_SportProductVariant_SportProductVariantId",
                table: "Size");

            migrationBuilder.DropTable(
                name: "ImageProduct");

            migrationBuilder.DropIndex(
                name: "IX_Size_SportProductVariantId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "SportProductVariantId",
                table: "Size");

            migrationBuilder.AddColumn<int>(
                name: "QuantityInStock",
                table: "SportProductVariant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SizeId",
                table: "SportProductVariant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SportProductVariant_SizeId",
                table: "SportProductVariant",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportProductVariant_Size_SizeId",
                table: "SportProductVariant",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
