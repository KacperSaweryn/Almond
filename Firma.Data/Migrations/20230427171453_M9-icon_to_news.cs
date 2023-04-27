using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class M9icon_to_news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "News",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "News");
        }
    }
}
