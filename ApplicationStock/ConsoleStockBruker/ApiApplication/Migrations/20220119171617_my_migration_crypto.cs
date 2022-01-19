using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class my_migration_crypto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Crypto_id",
                table: "_users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Crypto_id",
                table: "_markets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "_cryptos",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cryptos", x => x._id);
                });

            migrationBuilder.CreateIndex(
                name: "IX__users_Crypto_id",
                table: "_users",
                column: "Crypto_id");

            migrationBuilder.CreateIndex(
                name: "IX__markets_Crypto_id",
                table: "_markets",
                column: "Crypto_id");

            migrationBuilder.AddForeignKey(
                name: "FK__markets__cryptos_Crypto_id",
                table: "_markets",
                column: "Crypto_id",
                principalTable: "_cryptos",
                principalColumn: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK__users__cryptos_Crypto_id",
                table: "_users",
                column: "Crypto_id",
                principalTable: "_cryptos",
                principalColumn: "_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__markets__cryptos_Crypto_id",
                table: "_markets");

            migrationBuilder.DropForeignKey(
                name: "FK__users__cryptos_Crypto_id",
                table: "_users");

            migrationBuilder.DropTable(
                name: "_cryptos");

            migrationBuilder.DropIndex(
                name: "IX__users_Crypto_id",
                table: "_users");

            migrationBuilder.DropIndex(
                name: "IX__markets_Crypto_id",
                table: "_markets");

            migrationBuilder.DropColumn(
                name: "Crypto_id",
                table: "_users");

            migrationBuilder.DropColumn(
                name: "Crypto_id",
                table: "_markets");
        }
    }
}
