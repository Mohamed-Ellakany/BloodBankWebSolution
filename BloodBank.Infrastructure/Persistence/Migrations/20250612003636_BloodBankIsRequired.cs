using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BloodBankIsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodBanks_BloodBankId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "BloodBankId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodBanks_BloodBankId",
                table: "AspNetUsers",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodBanks_BloodBankId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "BloodBankId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodBanks_BloodBankId",
                table: "AspNetUsers",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id");
        }
    }
}
