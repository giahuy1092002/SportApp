using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingSportProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportProductRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportProductVariantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartRating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportProductVariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportProductRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportProductRatings_SportProductVariant_SportProductVariantId",
                        column: x => x.SportProductVariantId,
                        principalTable: "SportProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportProductRatings_SportProductVariantId",
                table: "SportProductRatings",
                column: "SportProductVariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportProductRatings");
        }
    }
}
