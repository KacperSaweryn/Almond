using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m13_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drapak");

            migrationBuilder.DropTable(
                name: "Kot");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "DrapakRodzaj");

            migrationBuilder.DropTable(
                name: "KotRodzaj");

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.ItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoGlowne = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemTypeId",
                table: "Item",
                column: "ItemTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.CreateTable(
                name: "DrapakRodzaj",
                columns: table => new
                {
                    DrapakRodzajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrapakRodzaj", x => x.DrapakRodzajId);
                });

            migrationBuilder.CreateTable(
                name: "KotRodzaj",
                columns: table => new
                {
                    KotRodzajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KotRodzaj", x => x.KotRodzajId);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    IdTest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.IdTest);
                });

            migrationBuilder.CreateTable(
                name: "Drapak",
                columns: table => new
                {
                    DrapakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrapakRodzajId = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drapak", x => x.DrapakId);
                    table.ForeignKey(
                        name: "FK_Drapak_DrapakRodzaj_DrapakRodzajId",
                        column: x => x.DrapakRodzajId,
                        principalTable: "DrapakRodzaj",
                        principalColumn: "DrapakRodzajId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kot",
                columns: table => new
                {
                    KotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KotRodzajId = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false),
                    Rasa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kot", x => x.KotId);
                    table.ForeignKey(
                        name: "FK_Kot_KotRodzaj_KotRodzajId",
                        column: x => x.KotRodzajId,
                        principalTable: "KotRodzaj",
                        principalColumn: "KotRodzajId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drapak_DrapakRodzajId",
                table: "Drapak",
                column: "DrapakRodzajId");

            migrationBuilder.CreateIndex(
                name: "IX_Kot_KotRodzajId",
                table: "Kot",
                column: "KotRodzajId");
        }
    }
}
