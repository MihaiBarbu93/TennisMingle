using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisMingle.API.Migrations
{
    public partial class BookingConfirmProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Bookings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Bookings");
        }
    }
}
