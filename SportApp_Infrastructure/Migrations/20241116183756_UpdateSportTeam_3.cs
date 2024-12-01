using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportTeam_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "UserSportTeam",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "UserSportTeam");
        }
    }
}
