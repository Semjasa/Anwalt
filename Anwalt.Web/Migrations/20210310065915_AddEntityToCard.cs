using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anwalt.Web.Migrations
{
    public partial class AddEntityToCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Card",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Card",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Card",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Card",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Card");
        }
    }
}
