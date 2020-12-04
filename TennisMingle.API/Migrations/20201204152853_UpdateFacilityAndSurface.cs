using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisMingle.API.Migrations
{
    public partial class UpdateFacilityAndSurface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_PersonId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_TennisClubs_TennisClubId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_TennisCourts_Surface_SurfaceId",
                table: "TennisCourts");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PersonId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surface",
                table: "Surface");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Surface",
                newName: "Surfaces");

            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facilities");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_TennisClubId",
                table: "Facilities",
                newName: "IX_Facilities_TennisClubId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surfaces",
                table: "Surfaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_TennisClubs_TennisClubId",
                table: "Facilities",
                column: "TennisClubId",
                principalTable: "TennisClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TennisCourts_Surfaces_SurfaceId",
                table: "TennisCourts",
                column: "SurfaceId",
                principalTable: "Surfaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_TennisClubs_TennisClubId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_TennisCourts_Surfaces_SurfaceId",
                table: "TennisCourts");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surfaces",
                table: "Surfaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Surfaces",
                newName: "Surface");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "Facility");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_TennisClubId",
                table: "Facility",
                newName: "IX_Facility_TennisClubId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surface",
                table: "Surface",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility",
                table: "Facility",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PersonId",
                table: "Bookings",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_PersonId",
                table: "Bookings",
                column: "PersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_TennisClubs_TennisClubId",
                table: "Facility",
                column: "TennisClubId",
                principalTable: "TennisClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TennisCourts_Surface_SurfaceId",
                table: "TennisCourts",
                column: "SurfaceId",
                principalTable: "Surface",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
