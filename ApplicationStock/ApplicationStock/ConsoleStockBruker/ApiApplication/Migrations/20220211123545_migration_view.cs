using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class migration_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<Guid>(
             name: "_stockId",
             table: "_orders"
             );


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

            migrationBuilder.AddColumn<Guid>(
                name: "_stockId",
                table: "_orders"
                );

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
