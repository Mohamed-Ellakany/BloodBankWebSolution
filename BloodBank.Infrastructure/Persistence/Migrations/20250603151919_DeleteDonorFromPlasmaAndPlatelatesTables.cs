using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDonorFromPlasmaAndPlatelatesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plasmas_Donors_DonorId",
                table: "Plasmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Platelets_Donors_DonorId",
                table: "Platelets");

            migrationBuilder.DropIndex(
                name: "IX_Platelets_DonorId",
                table: "Platelets");

            migrationBuilder.DropIndex(
                name: "IX_Plasmas_DonorId",
                table: "Plasmas");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Platelets");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Plasmas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Platelets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Plasmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Platelets_DonorId",
                table: "Platelets",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plasmas_DonorId",
                table: "Plasmas",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plasmas_Donors_DonorId",
                table: "Plasmas",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platelets_Donors_DonorId",
                table: "Platelets",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
