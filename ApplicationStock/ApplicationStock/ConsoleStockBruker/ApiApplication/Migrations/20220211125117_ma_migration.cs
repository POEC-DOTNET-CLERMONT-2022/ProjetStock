using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class ma_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks_stock",
                table: "_orders");

            migrationBuilder.RenameColumn(
                name: "stock",
                table: "_orders",
                newName: "_stockId");

            migrationBuilder.RenameIndex(
                name: "IX__orders_stock",
                table: "_orders",
                newName: "IX__orders__stockId");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders",
                column: "_stockId",
                principalTable: "_stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders");

            migrationBuilder.RenameColumn(
                name: "_stockId",
                table: "_orders",
                newName: "stock");

            migrationBuilder.RenameIndex(
                name: "IX__orders__stockId",
                table: "_orders",
                newName: "IX__orders_stock");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks_stock",
                table: "_orders",
                column: "stock",
                principalTable: "_stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
