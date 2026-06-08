using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addBloodBankColumnToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodBankId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BloodBankId",
                table: "AspNetUsers",
                column: "BloodBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodBanks_BloodBankId",
                table: "AspNetUsers",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodBanks_BloodBankId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BloodBankId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BloodBankId",
                table: "AspNetUsers");
        }
    }
}
