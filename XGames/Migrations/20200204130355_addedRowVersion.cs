using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XGames.Migrations
{
    public partial class addedRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "LineItem",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "GamePicture",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Game",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Cart",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "GamePicture");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Cart");
        }
    }
}
