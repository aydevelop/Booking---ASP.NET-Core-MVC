using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddConfigApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_HosterId1",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_ExplorerId1",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_HosterId1",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_ExplorerId1",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ExplorerId1",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ExplorerId1",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_HosterId1",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HosterId1",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ExplorerId1",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "ExplorerId1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "HosterId1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "HosterId1",
                table: "Apartments");

            migrationBuilder.AlterColumn<string>(
                name: "ExplorerId",
                table: "Rents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "HosterId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExplorerId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HosterId",
                table: "Apartments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ExplorerId",
                table: "Rents",
                column: "ExplorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ExplorerId",
                table: "Complaints",
                column: "ExplorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_HosterId",
                table: "Complaints",
                column: "HosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HosterId",
                table: "Apartments",
                column: "HosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_HosterId",
                table: "Apartments",
                column: "HosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_ExplorerId",
                table: "Complaints",
                column: "ExplorerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_HosterId",
                table: "Complaints",
                column: "HosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_ExplorerId",
                table: "Rents",
                column: "ExplorerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_HosterId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_ExplorerId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_HosterId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_ExplorerId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ExplorerId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ExplorerId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_HosterId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HosterId",
                table: "Apartments");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExplorerId",
                table: "Rents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExplorerId1",
                table: "Rents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HosterId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExplorerId",
                table: "Complaints",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExplorerId1",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HosterId1",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HosterId",
                table: "Apartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HosterId1",
                table: "Apartments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ExplorerId1",
                table: "Rents",
                column: "ExplorerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ExplorerId1",
                table: "Complaints",
                column: "ExplorerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_HosterId1",
                table: "Complaints",
                column: "HosterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HosterId1",
                table: "Apartments",
                column: "HosterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_HosterId1",
                table: "Apartments",
                column: "HosterId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_ExplorerId1",
                table: "Complaints",
                column: "ExplorerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_HosterId1",
                table: "Complaints",
                column: "HosterId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_ExplorerId1",
                table: "Rents",
                column: "ExplorerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
