using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddIdentityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Hosters_HosterId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Explorers_ExplorerId",
                table: "Rents");

            migrationBuilder.DropTable(
                name: "Explorers");

            migrationBuilder.DropTable(
                name: "Hosters");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ExplorerId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HosterId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ExplorerId1",
                table: "Rents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFromState",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Explorer_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Explorer_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Explorer_State",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
                name: "FK_Rents_AspNetUsers_ExplorerId1",
                table: "Rents",
                column: "ExplorerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_HosterId1",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_ExplorerId1",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ExplorerId1",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HosterId1",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ExplorerId1",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateFromState",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Explorer_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Explorer_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Explorer_State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HosterId1",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Explorers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFromState = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explorers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ExplorerId",
                table: "Rents",
                column: "ExplorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HosterId",
                table: "Apartments",
                column: "HosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Hosters_HosterId",
                table: "Apartments",
                column: "HosterId",
                principalTable: "Hosters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Explorers_ExplorerId",
                table: "Rents",
                column: "ExplorerId",
                principalTable: "Explorers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
