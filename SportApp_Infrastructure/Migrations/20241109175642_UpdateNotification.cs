using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_SportField_SportFieldId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SportFieldId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "SportFieldId",
                table: "Notifications",
                newName: "RelatedId");

            migrationBuilder.AddColumn<string>(
                name: "RelatedType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemind",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsRemind",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "RelatedId",
                table: "Notifications",
                newName: "SportFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SportFieldId",
                table: "Notifications",
                column: "SportFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_SportField_SportFieldId",
                table: "Notifications",
                column: "SportFieldId",
                principalTable: "SportField",
                principalColumn: "Id");
        }
    }
}
