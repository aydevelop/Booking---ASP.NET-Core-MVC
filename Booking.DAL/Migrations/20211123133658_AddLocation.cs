using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HosterId",
                table: "Apartments",
                column: "HosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LocationId",
                table: "Apartments",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Hosters_HosterId",
                table: "Apartments",
                column: "HosterId",
                principalTable: "Hosters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Hosters_HosterId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Locations_LocationId",
                table: "Apartments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HosterId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_LocationId",
                table: "Apartments");
        }
    }
}
