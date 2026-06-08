using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addIndexForNationalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorBank_BloodBanks_BloodBankId",
                table: "DonorBank");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorBank_Donors_DonorId",
                table: "DonorBank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonorBank",
                table: "DonorBank");

            migrationBuilder.RenameTable(
                name: "DonorBank",
                newName: "DonorBanks");

            migrationBuilder.RenameIndex(
                name: "IX_DonorBank_BloodBankId",
                table: "DonorBanks",
                newName: "IX_DonorBanks_BloodBankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonorBanks",
                table: "DonorBanks",
                columns: new[] { "DonorId", "BloodBankId" });

            migrationBuilder.CreateIndex(
                name: "IX_Donors_NationalId",
                table: "Donors",
                column: "NationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorBanks_BloodBanks_BloodBankId",
                table: "DonorBanks",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorBanks_Donors_DonorId",
                table: "DonorBanks",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorBanks_BloodBanks_BloodBankId",
                table: "DonorBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorBanks_Donors_DonorId",
                table: "DonorBanks");

            migrationBuilder.DropIndex(
                name: "IX_Donors_NationalId",
                table: "Donors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonorBanks",
                table: "DonorBanks");

            migrationBuilder.RenameTable(
                name: "DonorBanks",
                newName: "DonorBank");

            migrationBuilder.RenameIndex(
                name: "IX_DonorBanks_BloodBankId",
                table: "DonorBank",
                newName: "IX_DonorBank_BloodBankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonorBank",
                table: "DonorBank",
                columns: new[] { "DonorId", "BloodBankId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DonorBank_BloodBanks_BloodBankId",
                table: "DonorBank",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorBank_Donors_DonorId",
                table: "DonorBank",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
