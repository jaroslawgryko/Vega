using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vega.Migrations
{
    public partial class SeedAtrybuty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Atrybuty (Nazwa) VALUES ('Atrybut 1')");
            migrationBuilder.Sql("INSERT INTO Atrybuty (Nazwa) VALUES ('Atrybut 2')");
            migrationBuilder.Sql("INSERT INTO Atrybuty (Nazwa) VALUES ('Atrybut 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Atrybuty WHERE Nazwa IN ('Atrybut 1', 'Atrybut 2', 'Atrybut 3')");
        }
    }
}
