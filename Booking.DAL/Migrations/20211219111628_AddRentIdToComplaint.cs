using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddRentIdToComplaint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "HosterId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExplorerId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RentId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_RentId",
                table: "Complaints",
                column: "RentId",
                unique: true,
                filter: "[RentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Rents_RentId",
                table: "Complaints",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Rents_RentId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_RentId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "Complaints");

            migrationBuilder.AlterColumn<Guid>(
                name: "HosterId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExplorerId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
