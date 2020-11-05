using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisMingle.API.Migrations
{
    public partial class PersonTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonTypeId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonTypeId",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
