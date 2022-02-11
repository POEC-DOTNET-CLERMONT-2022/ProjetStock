using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks__StockId",
                table: "_orders");

            migrationBuilder.RenameColumn(
                name: "_StockId",
                table: "_orders",
                newName: "_stockId");

            migrationBuilder.RenameIndex(
                name: "IX__orders__StockId",
                table: "_orders",
                newName: "IX__orders__stockId");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders",
                column: "_stockId",
                principalTable: "_stocks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders");

            migrationBuilder.RenameColumn(
                name: "_stockId",
                table: "_orders",
                newName: "_StockId");

            migrationBuilder.RenameIndex(
                name: "IX__orders__stockId",
                table: "_orders",
                newName: "IX__orders__StockId");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks__StockId",
                table: "_orders",
                column: "_StockId",
                principalTable: "_stocks",
                principalColumn: "Id");
        }
    }
}
