using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class M6CatAndCatTree_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrapakRodzajId",
                table: "CatTree");

            migrationBuilder.DropColumn(
                name: "KotRodzajId",
                table: "Cat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrapakRodzajId",
                table: "CatTree",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KotRodzajId",
                table: "Cat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
