using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class my_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_cryptos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cryptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_notifs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _textRappel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _sendAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _orderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _nbStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _openingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _closingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CryptoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK__markets__cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "_cryptos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _siret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _expireToken = table.Column<DateTime>(type: "datetime2", nullable: true),
                    _password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CryptoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users", x => x.Id);
                    table.ForeignKey(
                        name: "FK__users__cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "_cryptos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _value = table.Column<float>(type: "real", nullable: false),
                    _entrepriseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK__stocks__markets_Stock",
                        column: x => x.Stock,
                        principalTable: "_markets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _address_line_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _address_line_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _codePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addresses = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__addresses__users_Addresses",
                        column: x => x.Addresses,
                        principalTable: "_users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX__addresses_Addresses",
                table: "_addresses",
                column: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX__markets_CryptoId",
                table: "_markets",
                column: "CryptoId");

            migrationBuilder.CreateIndex(
                name: "IX__stocks_Stock",
                table: "_stocks",
                column: "Stock");

            migrationBuilder.CreateIndex(
                name: "IX__users_CryptoId",
                table: "_users",
                column: "CryptoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_addresses");

            migrationBuilder.DropTable(
                name: "_notifs");

            migrationBuilder.DropTable(
                name: "_orders");

            migrationBuilder.DropTable(
                name: "_stocks");

            migrationBuilder.DropTable(
                name: "_users");

            migrationBuilder.DropTable(
                name: "_markets");

            migrationBuilder.DropTable(
                name: "_cryptos");
        }
    }
}
