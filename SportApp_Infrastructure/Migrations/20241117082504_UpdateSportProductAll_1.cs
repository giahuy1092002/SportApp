using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportProductAll_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndPoint",
                table: "SportProductVariant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPoint",
                table: "SportProductVariant");
        }
    }
}
