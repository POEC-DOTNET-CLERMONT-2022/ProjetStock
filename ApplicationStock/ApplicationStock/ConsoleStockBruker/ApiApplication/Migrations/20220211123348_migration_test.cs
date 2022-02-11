using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class migration_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      



            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks_stock",
                table: "_orders",
                column: "stock",
                principalTable: "_stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          


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
