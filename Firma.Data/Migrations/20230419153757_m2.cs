using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pozycja",
                table: "KotRodzaj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pozycja",
                table: "Kot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pozycja",
                table: "DrapakRodzaj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pozycja",
                table: "Drapak",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pozycja",
                table: "KotRodzaj");

            migrationBuilder.DropColumn(
                name: "Pozycja",
                table: "Kot");

            migrationBuilder.DropColumn(
                name: "Pozycja",
                table: "DrapakRodzaj");

            migrationBuilder.DropColumn(
                name: "Pozycja",
                table: "Drapak");
        }
    }
}
