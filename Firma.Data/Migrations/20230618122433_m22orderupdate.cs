using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    public partial class m22orderupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_CartElement_ItemCartElementCartElementId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ItemCartElementCartElementId",
                table: "Order",
                newName: "CartElementId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ItemCartElementCartElementId",
                table: "Order",
                newName: "IX_Order_CartElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CartElement_CartElementId",
                table: "Order",
                column: "CartElementId",
                principalTable: "CartElement",
                principalColumn: "CartElementId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_CartElement_CartElementId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "CartElementId",
                table: "Order",
                newName: "ItemCartElementCartElementId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CartElementId",
                table: "Order",
                newName: "IX_Order_ItemCartElementCartElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CartElement_ItemCartElementCartElementId",
                table: "Order",
                column: "ItemCartElementCartElementId",
                principalTable: "CartElement",
                principalColumn: "CartElementId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
