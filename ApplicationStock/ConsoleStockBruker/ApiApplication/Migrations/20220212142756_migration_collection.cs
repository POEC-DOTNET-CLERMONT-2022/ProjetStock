using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class migration_collection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "_orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "_notifs",
                type: "uniqueidentifier",
                nullable: true);

         
            migrationBuilder.CreateIndex(
                name: "IX__orders_ClientId",
                table: "_orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX__notifs_ClientId",
                table: "_notifs",
                column: "ClientId");


            migrationBuilder.AddForeignKey(
                name: "FK__notifs__users_ClientId",
                table: "_notifs",
                column: "ClientId",
                principalTable: "_users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__users_ClientId",
                table: "_orders",
                column: "ClientId",
                principalTable: "_users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__addresses__users_ClientId",
                table: "_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK__notifs__users_ClientId",
                table: "_notifs");

            migrationBuilder.DropForeignKey(
                name: "FK__orders__users_ClientId",
                table: "_orders");

            migrationBuilder.DropIndex(
                name: "IX__orders_ClientId",
                table: "_orders");

            migrationBuilder.DropIndex(
                name: "IX__notifs_ClientId",
                table: "_notifs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "_orders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "_notifs");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "_addresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK__addresses__users_ClientId",
                table: "_addresses",
                column: "ClientId",
                principalTable: "_users",
                principalColumn: "Id");
        }
    }
}
