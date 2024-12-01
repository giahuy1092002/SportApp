using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAddress_City",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Commune",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_District",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_City",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Commune",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_District",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
