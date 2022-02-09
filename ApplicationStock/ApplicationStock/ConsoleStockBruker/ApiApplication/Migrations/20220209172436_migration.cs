using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RenameColumn(
                name: "Stocke",
                table: "_orders",
                newName: "Stock");

            migrationBuilder.RenameIndex(
                name: "IX__orders_Stocke",
                table: "_orders",
                newName: "IX__orders_Stock");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks_Stock",
                table: "_orders",
                column: "Stock",
                principalTable: "_stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks_Stock",
                table: "_orders");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "_orders",
                newName: "Stocke");

            migrationBuilder.RenameIndex(
                name: "IX__orders_Stock",
                table: "_orders",
                newName: "IX__orders_Stocke");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks_Stocke",
                table: "_orders",
                column: "Stocke",
                principalTable: "_stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
