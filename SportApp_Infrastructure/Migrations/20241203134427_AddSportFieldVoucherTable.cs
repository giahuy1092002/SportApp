using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSportFieldVoucherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportFieldVoucher_SportField_SportFieldId",
                table: "SportFieldVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_SportFieldVoucher_Vouchers_VoucherId",
                table: "SportFieldVoucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportFieldVoucher",
                table: "SportFieldVoucher");

            migrationBuilder.RenameTable(
                name: "SportFieldVoucher",
                newName: "SportFieldVouchers");

            migrationBuilder.RenameIndex(
                name: "IX_SportFieldVoucher_VoucherId",
                table: "SportFieldVouchers",
                newName: "IX_SportFieldVouchers_VoucherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportFieldVouchers",
                table: "SportFieldVouchers",
                columns: new[] { "SportFieldId", "VoucherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SportFieldVouchers_SportField_SportFieldId",
                table: "SportFieldVouchers",
                column: "SportFieldId",
                principalTable: "SportField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportFieldVouchers_Vouchers_VoucherId",
                table: "SportFieldVouchers",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportFieldVouchers_SportField_SportFieldId",
                table: "SportFieldVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_SportFieldVouchers_Vouchers_VoucherId",
                table: "SportFieldVouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportFieldVouchers",
                table: "SportFieldVouchers");

            migrationBuilder.RenameTable(
                name: "SportFieldVouchers",
                newName: "SportFieldVoucher");

            migrationBuilder.RenameIndex(
                name: "IX_SportFieldVouchers_VoucherId",
                table: "SportFieldVoucher",
                newName: "IX_SportFieldVoucher_VoucherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportFieldVoucher",
                table: "SportFieldVoucher",
                columns: new[] { "SportFieldId", "VoucherId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SportFieldVoucher_SportField_SportFieldId",
                table: "SportFieldVoucher",
                column: "SportFieldId",
                principalTable: "SportField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportFieldVoucher_Vouchers_VoucherId",
                table: "SportFieldVoucher",
                column: "VoucherId",
                principalTable: "Vouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
