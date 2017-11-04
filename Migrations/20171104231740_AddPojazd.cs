using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class AddPojazd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pojazdy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CzyZarejestrowany = table.Column<bool>(type: "bit", nullable: false),
                    KontaktEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KontaktNazwa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    OstatniaZmiana = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazdy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pojazdy_Modele_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Modele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PojazdAtrybuty",
                columns: table => new
                {
                    PojazdId = table.Column<int>(type: "int", nullable: false),
                    AtrybutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PojazdAtrybuty", x => new { x.PojazdId, x.AtrybutId });
                    table.ForeignKey(
                        name: "FK_PojazdAtrybuty_Atrybuty_AtrybutId",
                        column: x => x.AtrybutId,
                        principalTable: "Atrybuty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PojazdAtrybuty_Pojazdy_PojazdId",
                        column: x => x.PojazdId,
                        principalTable: "Pojazdy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PojazdAtrybuty_AtrybutId",
                table: "PojazdAtrybuty",
                column: "AtrybutId");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_ModelId",
                table: "Pojazdy",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PojazdAtrybuty");

            migrationBuilder.DropTable(
                name: "Pojazdy");
        }
    }
}
