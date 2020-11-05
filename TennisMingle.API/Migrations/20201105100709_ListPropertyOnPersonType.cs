using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisMingle.API.Migrations
{
    public partial class ListPropertyOnPersonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TennisCourts_SurfaceId",
                table: "TennisCourts");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourts_SurfaceId",
                table: "TennisCourts",
                column: "SurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TennisCourts_SurfaceId",
                table: "TennisCourts");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourts_SurfaceId",
                table: "TennisCourts",
                column: "SurfaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId",
                unique: true);
        }
    }
}
