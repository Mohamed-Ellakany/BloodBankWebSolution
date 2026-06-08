using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addBloodBankToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodBankId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BloodBankId",
                table: "Reservations",
                column: "BloodBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_BloodBanks_BloodBankId",
                table: "Reservations",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_BloodBanks_BloodBankId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BloodBankId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BloodBankId",
                table: "Reservations");
        }
    }
}
