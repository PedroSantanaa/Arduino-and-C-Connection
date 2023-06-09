﻿using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Arduino_DB.Migrations
{
    /// <inheritdoc />
    public partial class DbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArduinoData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Temperatura = table.Column<string>(type: "longtext", nullable: false),
                    Tensao = table.Column<string>(type: "longtext", nullable: false),
                    Porta = table.Column<string>(type: "longtext", nullable: false),
                    NivelDaAgua = table.Column<string>(type: "longtext", nullable: false),
                    TemperaturaAnormais = table.Column<string>(type: "longtext", nullable: false),
                    TensaoAnormais = table.Column<string>(type: "longtext", nullable: false),
                    NivelDaAguaBaixo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArduinoData", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArduinoData");
        }
    }
}
