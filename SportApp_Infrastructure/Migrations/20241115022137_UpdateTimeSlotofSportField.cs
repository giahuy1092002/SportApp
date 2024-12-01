using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeSlotofSportField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportProduct_SubCategory_SubCategoryId",
                table: "SportProduct");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropColumn(
                name: "IsConfigured",
                table: "SportProduct");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "SportProduct",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SportProduct_SubCategoryId",
                table: "SportProduct",
                newName: "IX_SportProduct_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "SportField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "SportField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SportProduct_Category_CategoryId",
                table: "SportProduct",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportProduct_Category_CategoryId",
                table: "SportProduct");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "SportField");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SportField");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SportProduct",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SportProduct_CategoryId",
                table: "SportProduct",
                newName: "IX_SportProduct_SubCategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfigured",
                table: "SportProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportProduct_SubCategory_SubCategoryId",
                table: "SportProduct",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
