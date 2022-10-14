﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TgBot_ver1._11.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientStatus",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RialDataBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Names = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Car = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Oil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OilFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AirFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalonFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CashBack = table.Column<int>(type: "int", nullable: true),
                    Ngk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Padsfront = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Padsrear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fuelfilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TotalPurchaseAmount = table.Column<int>(type: "int", nullable: true),
                    Dates = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Statuss = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RialDataBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    StatusID = table.Column<byte>(type: "tinyint", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Client__StatusID__7EC1CEDB",
                        column: x => x.StatusID,
                        principalTable: "ClientStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Car__ClientId__0E04126B",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientBankAccout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashBack = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TotalPurchaseAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBankAccout", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ClientBan__Clien__02925FBF",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarCharacteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OilFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AirFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalonFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Сandles = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PadsFront = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PadsRear = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelFilter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CarCharac__CarId__10E07F16",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ClientId",
                table: "Car",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "UQ__CarChara__68A0342F0DF02FB1",
                table: "CarCharacteristics",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client_StatusID",
                table: "Client",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "UQ__Client__5C7E359E1541BBAE",
                table: "Client",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ClientBa__E67E1A25C67D7BCE",
                table: "ClientBankAccout",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCharacteristics");

            migrationBuilder.DropTable(
                name: "ClientBankAccout");

            migrationBuilder.DropTable(
                name: "RialDataBase");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientStatus");
        }
    }
}
