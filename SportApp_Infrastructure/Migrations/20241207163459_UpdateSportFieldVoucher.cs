using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSportFieldVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Vouchers");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SportFieldVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SportFieldVouchers");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Vouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
