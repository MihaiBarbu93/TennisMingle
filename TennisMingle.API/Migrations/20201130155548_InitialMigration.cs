using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisMingle.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surface",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TennisClubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Schedule = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TennisClubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TennisClubs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityType = table.Column<int>(nullable: false),
                    TennisClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_TennisClubs_TennisClubId",
                        column: x => x.TennisClubId,
                        principalTable: "TennisClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TennisCourts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SurfaceId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    TennisClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TennisCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TennisCourts_Surface_SurfaceId",
                        column: x => x.SurfaceId,
                        principalTable: "Surface",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TennisCourts_TennisClubs_TennisClubId",
                        column: x => x.TennisClubId,
                        principalTable: "TennisClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    TennisClubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_TennisClubs_TennisClubId",
                        column: x => x.TennisClubId,
                        principalTable: "TennisClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    TennisCourtId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_TennisCourts_TennisCourtId",
                        column: x => x.TennisCourtId,
                        principalTable: "TennisCourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    TennisClubId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_TennisClubs_TennisClubId",
                        column: x => x.TennisClubId,
                        principalTable: "TennisClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PersonId",
                table: "Bookings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TennisCourtId",
                table: "Bookings",
                column: "TennisCourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_TennisClubId",
                table: "Facility",
                column: "TennisClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PersonId",
                table: "Photos",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TennisClubId",
                table: "Photos",
                column: "TennisClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TennisClubs_CityId",
                table: "TennisClubs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourts_SurfaceId",
                table: "TennisCourts",
                column: "SurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourts_TennisClubId",
                table: "TennisCourts",
                column: "TennisClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TennisClubId",
                table: "Users",
                column: "TennisClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TennisCourts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Surface");

            migrationBuilder.DropTable(
                name: "TennisClubs");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
