using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingIsRight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRight",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRight",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Booking");
        }
    }
}
