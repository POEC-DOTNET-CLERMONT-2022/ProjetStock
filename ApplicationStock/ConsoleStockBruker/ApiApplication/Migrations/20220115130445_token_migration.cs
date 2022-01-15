using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class token_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Address",
                table: "_addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX__addresses_Address",
                table: "_addresses",
                column: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK__addresses__users_Address",
                table: "_addresses",
                column: "Address",
                principalTable: "_users",
                principalColumn: "_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__addresses__users_Address",
                table: "_addresses");

            migrationBuilder.DropIndex(
                name: "IX__addresses_Address",
                table: "_addresses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "_addresses");
        }
    }
}
