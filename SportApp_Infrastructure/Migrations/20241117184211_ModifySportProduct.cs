using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySportProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_SportProductVariant_SportProductVariantId",
                table: "ImageProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_SportProductVariant_SportProductVariantId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Size_SportProductVariantId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "QuantityInStock",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "SportProductVariantId",
                table: "Size");

            migrationBuilder.RenameColumn(
                name: "SportProductVariantId",
                table: "ImageProduct",
                newName: "SportProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProduct_SportProductVariantId",
                table: "ImageProduct",
                newName: "IX_ImageProduct_SportProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "SizeId",
                table: "SportProductVariant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "ImageProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SportProductVariant_SizeId",
                table: "SportProductVariant",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProduct_ColorId",
                table: "ImageProduct",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Color_ColorId",
                table: "ImageProduct",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_SportProduct_SportProductId",
                table: "ImageProduct",
                column: "SportProductId",
                principalTable: "SportProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportProductVariant_Size_SizeId",
                table: "SportProductVariant",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_Color_ColorId",
                table: "ImageProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_SportProduct_SportProductId",
                table: "ImageProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SportProductVariant_Size_SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_SportProductVariant_SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_ImageProduct_ColorId",
                table: "ImageProduct");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "SportProductVariant");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ImageProduct");

            migrationBuilder.RenameColumn(
                name: "SportProductId",
                table: "ImageProduct",
                newName: "SportProductVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProduct_SportProductId",
                table: "ImageProduct",
                newName: "IX_ImageProduct_SportProductVariantId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Size_SportProductVariantId",
                table: "Size",
                column: "SportProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_SportProductVariant_SportProductVariantId",
                table: "ImageProduct",
                column: "SportProductVariantId",
                principalTable: "SportProductVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_SportProductVariant_SportProductVariantId",
                table: "Size",
                column: "SportProductVariantId",
                principalTable: "SportProductVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
