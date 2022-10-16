using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgBot_ver1._11.Migrations
{
    public partial class HasOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Test_ClientId",
                table: "Test",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Client_ClientId",
                table: "Test",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Client_ClientId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_ClientId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Test");
        }
    }
}
