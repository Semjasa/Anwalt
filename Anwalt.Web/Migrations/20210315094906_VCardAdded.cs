using Microsoft.EntityFrameworkCore.Migrations;

namespace Anwalt.Web.Migrations
{
    public partial class VCardAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_VCardId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_VCardId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "VCardId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VCardId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VCardId",
                table: "Employees",
                column: "VCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_VCardId",
                table: "Employees",
                column: "VCardId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
