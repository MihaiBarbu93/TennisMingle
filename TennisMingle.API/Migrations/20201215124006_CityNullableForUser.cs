using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisMingle.API.Migrations
{
    public partial class CityNullableForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
