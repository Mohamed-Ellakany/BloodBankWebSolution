using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditColsValidationAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodBags_BloodBanks_BloodBankId",
                table: "BloodBags");

            migrationBuilder.DropForeignKey(
                name: "FK_Plasmas_BloodBanks_BloodBankId",
                table: "Plasmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Platelets_BloodBanks_BloodBankId",
                table: "Platelets");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "BloodBags");

            migrationBuilder.RenameColumn(
                name: "BloodType",
                table: "Donors",
                newName: "PhoneNum");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "Platelets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Platelets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Platelets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "Plasmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Plasmas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Plasmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Donors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Donors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BloodBanks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "BloodBanks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeId",
                table: "BloodBags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "BloodBags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "BloodBags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DonorBank",
                columns: table => new
                {
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    BloodBankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorBank", x => new { x.DonorId, x.BloodBankId });
                    table.ForeignKey(
                        name: "FK_DonorBank_BloodBanks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "BloodBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonorBank_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Platelets_BloodTypeId",
                table: "Platelets",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Platelets_DonorId",
                table: "Platelets",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plasmas_BloodTypeId",
                table: "Plasmas",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plasmas_DonorId",
                table: "Plasmas",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_Name_NationalId",
                table: "Donors",
                columns: new[] { "Name", "NationalId" });

            migrationBuilder.CreateIndex(
                name: "IX_BloodBags_BloodTypeId",
                table: "BloodBags",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodBags_DonorId",
                table: "BloodBags",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorBank_BloodBankId",
                table: "DonorBank",
                column: "BloodBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBags_BloodBanks_BloodBankId",
                table: "BloodBags",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBags_BloodTypes_BloodTypeId",
                table: "BloodBags",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBags_Donors_DonorId",
                table: "BloodBags",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plasmas_BloodBanks_BloodBankId",
                table: "Plasmas",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plasmas_BloodTypes_BloodTypeId",
                table: "Plasmas",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plasmas_Donors_DonorId",
                table: "Plasmas",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platelets_BloodBanks_BloodBankId",
                table: "Platelets",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platelets_BloodTypes_BloodTypeId",
                table: "Platelets",
                column: "BloodTypeId",
                principalTable: "BloodTypes",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodBags_BloodBanks_BloodBankId",
                table: "BloodBags");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodBags_BloodTypes_BloodTypeId",
                table: "BloodBags");

            migrationBuilder.DropForeignKey(
                name: "FK_BloodBags_Donors_DonorId",
                table: "BloodBags");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodTypes_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Plasmas_BloodBanks_BloodBankId",
                table: "Plasmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plasmas_BloodTypes_BloodTypeId",
                table: "Plasmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plasmas_Donors_DonorId",
                table: "Plasmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Platelets_BloodBanks_BloodBankId",
                table: "Platelets");

            migrationBuilder.DropForeignKey(
                name: "FK_Platelets_BloodTypes_BloodTypeId",
                table: "Platelets");

            migrationBuilder.DropForeignKey(
                name: "FK_Platelets_Donors_DonorId",
                table: "Platelets");

            migrationBuilder.DropTable(
                name: "DonorBank");

            migrationBuilder.DropIndex(
                name: "IX_Platelets_BloodTypeId",
                table: "Platelets");

            migrationBuilder.DropIndex(
                name: "IX_Platelets_DonorId",
                table: "Platelets");

            migrationBuilder.DropIndex(
                name: "IX_Plasmas_BloodTypeId",
                table: "Plasmas");

            migrationBuilder.DropIndex(
                name: "IX_Plasmas_DonorId",
                table: "Plasmas");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodTypeId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_Name_NationalId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_BloodBags_BloodTypeId",
                table: "BloodBags");

            migrationBuilder.DropIndex(
                name: "IX_BloodBags_DonorId",
                table: "BloodBags");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "Platelets");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Platelets");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Platelets");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "Plasmas");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Plasmas");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Plasmas");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodTypeId",
                table: "BloodBags");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "BloodBags");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "BloodBags");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                table: "Donors",
                newName: "BloodType");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BloodBanks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "BloodBanks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "BloodBags",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodBags_BloodBanks_BloodBankId",
                table: "BloodBags",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plasmas_BloodBanks_BloodBankId",
                table: "Plasmas",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Platelets_BloodBanks_BloodBankId",
                table: "Platelets",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
