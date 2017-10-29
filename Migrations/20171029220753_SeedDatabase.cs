using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Marki (Nazwa) VALUES ('Marka1')");
            migrationBuilder.Sql("INSERT INTO Marki (Nazwa) VALUES ('Marka2')");
            migrationBuilder.Sql("INSERT INTO Marki (Nazwa) VALUES ('Marka3')");

            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka1-ModelA', (SELECT Id FROM Marki WHERE Nazwa = 'Marka1'))");
            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka1-ModelB', (SELECT Id FROM Marki WHERE Nazwa = 'Marka1'))");
            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka1-ModelC', (SELECT Id FROM Marki WHERE Nazwa = 'Marka1'))");

            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka2-ModelA', (SELECT Id FROM Marki WHERE Nazwa = 'Marka2'))");
            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka2-ModelB', (SELECT Id FROM Marki WHERE Nazwa = 'Marka2'))");
            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka2-ModelC', (SELECT Id FROM Marki WHERE Nazwa = 'Marka2'))");            

            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka3-ModelA', (SELECT Id FROM Marki WHERE Nazwa = 'Marka3'))");
            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka3-ModelB', (SELECT Id FROM Marki WHERE Nazwa = 'Marka3'))");
            migrationBuilder.Sql("INSERT INTO Modele (Nazwa, MarkaId) VALUES ('Marka3-ModelC', (SELECT Id FROM Marki WHERE Nazwa = 'Marka3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Marki");
            migrationBuilder.Sql("DELETE FROM Modele");
        }
    }
}
