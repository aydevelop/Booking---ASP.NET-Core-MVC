using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DAL.Migrations
{
    public partial class AddApartmentFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFeature_Apartments_ApartmentsId",
                table: "ApartmentFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFeature_Features_FeaturesId",
                table: "ApartmentFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentFeature",
                table: "ApartmentFeature");

            migrationBuilder.RenameColumn(
                name: "FeaturesId",
                table: "ApartmentFeature",
                newName: "FeatureId");

            migrationBuilder.RenameColumn(
                name: "ApartmentsId",
                table: "ApartmentFeature",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentFeature_FeaturesId",
                table: "ApartmentFeature",
                newName: "IX_ApartmentFeature_FeatureId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApartmentFeature",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentFeature",
                table: "ApartmentFeature",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentFeature_ApartmentId",
                table: "ApartmentFeature",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFeature_Apartments_ApartmentId",
                table: "ApartmentFeature",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFeature_Features_FeatureId",
                table: "ApartmentFeature",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFeature_Apartments_ApartmentId",
                table: "ApartmentFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFeature_Features_FeatureId",
                table: "ApartmentFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentFeature",
                table: "ApartmentFeature");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentFeature_ApartmentId",
                table: "ApartmentFeature");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApartmentFeature");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "ApartmentFeature",
                newName: "FeaturesId");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "ApartmentFeature",
                newName: "ApartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentFeature_FeatureId",
                table: "ApartmentFeature",
                newName: "IX_ApartmentFeature_FeaturesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentFeature",
                table: "ApartmentFeature",
                columns: new[] { "ApartmentsId", "FeaturesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFeature_Apartments_ApartmentsId",
                table: "ApartmentFeature",
                column: "ApartmentsId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFeature_Features_FeaturesId",
                table: "ApartmentFeature",
                column: "FeaturesId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
