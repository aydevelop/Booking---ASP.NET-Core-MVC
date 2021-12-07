using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class ApartmentFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Apartments_ApartementId",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "ApartementId",
                table: "Rents",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rents_ApartementId",
                table: "Rents",
                newName: "IX_Rents_ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Apartments_ApartmentId",
                table: "Rents",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Apartments_ApartmentId",
                table: "Rents");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Rents",
                newName: "ApartementId");

            migrationBuilder.RenameIndex(
                name: "IX_Rents_ApartmentId",
                table: "Rents",
                newName: "IX_Rents_ApartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Apartments_ApartementId",
                table: "Rents",
                column: "ApartementId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
