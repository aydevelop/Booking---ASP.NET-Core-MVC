using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddRateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Apartments_ApartmentId",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Rents_RentId",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate",
                table: "Rate");

            migrationBuilder.RenameTable(
                name: "Rate",
                newName: "Rates");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_RentId",
                table: "Rates",
                newName: "IX_Rates_RentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_ApartmentId",
                table: "Rates",
                newName: "IX_Rates_ApartmentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApartmentId",
                table: "Rates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rates",
                table: "Rates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Apartments_ApartmentId",
                table: "Rates",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Rents_RentId",
                table: "Rates",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Apartments_ApartmentId",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Rents_RentId",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rates",
                table: "Rates");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "Rate");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_RentId",
                table: "Rate",
                newName: "IX_Rate_RentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_ApartmentId",
                table: "Rate",
                newName: "IX_Rate_ApartmentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApartmentId",
                table: "Rate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate",
                table: "Rate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Apartments_ApartmentId",
                table: "Rate",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Rents_RentId",
                table: "Rate",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
