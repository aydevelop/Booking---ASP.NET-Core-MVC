using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddComplaintTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HosterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HosterId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExplorerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExplorerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_ExplorerId1",
                        column: x => x.ExplorerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_HosterId1",
                        column: x => x.HosterId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ExplorerId1",
                table: "Complaints",
                column: "ExplorerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_HosterId1",
                table: "Complaints",
                column: "HosterId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}
