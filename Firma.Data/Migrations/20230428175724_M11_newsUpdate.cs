using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class M11_newsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "News",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "News",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rozwiniecie",
                table: "News",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltText",
                table: "News");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Rozwiniecie",
                table: "News");
        }
    }
}
