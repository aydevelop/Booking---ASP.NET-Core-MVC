using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class EditRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rents_ApartementId",
                table: "Rents",
                column: "ApartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ExplorerId",
                table: "Rents",
                column: "ExplorerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Apartments_ApartementId",
                table: "Rents",
                column: "ApartementId",
                principalTable: "Apartments",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Apartments_ApartementId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Explorers_ExplorerId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ApartementId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ExplorerId",
                table: "Rents");
        }
    }
}
