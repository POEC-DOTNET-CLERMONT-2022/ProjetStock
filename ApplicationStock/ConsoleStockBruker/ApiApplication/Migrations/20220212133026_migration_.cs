using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class migration_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__stocks__users_Stocks",
                table: "_stocks");

            migrationBuilder.RenameColumn(
                name: "Stocks",
                table: "_stocks",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX__stocks_Stocks",
                table: "_stocks",
                newName: "IX__stocks_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK__stocks__users_ClientId",
                table: "_stocks",
                column: "ClientId",
                principalTable: "_users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__stocks__users_ClientId",
                table: "_stocks");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "_stocks",
                newName: "Stocks");

            migrationBuilder.RenameIndex(
                name: "IX__stocks_ClientId",
                table: "_stocks",
                newName: "IX__stocks_Stocks");

            migrationBuilder.AddForeignKey(
                name: "FK__stocks__users_Stocks",
                table: "_stocks",
                column: "Stocks",
                principalTable: "_users",
                principalColumn: "Id");
        }
    }
}
