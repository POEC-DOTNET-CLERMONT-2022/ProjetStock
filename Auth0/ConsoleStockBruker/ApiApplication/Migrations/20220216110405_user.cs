﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiApplication.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders");

            migrationBuilder.DropForeignKey(
                name: "FK__stocks__users_ClientId",
                table: "_stocks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "_stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "_stockId",
                table: "_orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders",
                column: "_stockId",
                principalTable: "_stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__stocks__users_ClientId",
                table: "_stocks",
                column: "ClientId",
                principalTable: "_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders");

            migrationBuilder.DropForeignKey(
                name: "FK__stocks__users_ClientId",
                table: "_stocks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "_stocks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "_stockId",
                table: "_orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK__orders__stocks__stockId",
                table: "_orders",
                column: "_stockId",
                principalTable: "_stocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__stocks__users_ClientId",
                table: "_stocks",
                column: "ClientId",
                principalTable: "_users",
                principalColumn: "Id");
        }
    }
}
