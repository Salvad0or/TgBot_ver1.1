using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgBot_ver1._11.Migrations
{
    public partial class HasOneTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Test_ClientId",
                table: "Test");

            migrationBuilder.CreateIndex(
                name: "IX_Test_ClientId",
                table: "Test",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Test_ClientId",
                table: "Test");

            migrationBuilder.CreateIndex(
                name: "IX_Test_ClientId",
                table: "Test",
                column: "ClientId");
        }
    }
}
