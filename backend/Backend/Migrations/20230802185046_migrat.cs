using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class migrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Sexo = table.Column<string>(type: "VARCHAR(1)", nullable: false),
                    DataNascimento = table.Column<string>(type: "VARCHAR(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoExame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoExame = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DescricaoTipoExame = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeExame = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ObservacaoameExame = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IdTipoExame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_TipoExame_IdTipoExame",
                        column: x => x.IdTipoExame,
                        principalTable: "TipoExame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MarcaConsulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Protocolo = table.Column<long>(type: "bigint", nullable: false),
                    DataHora = table.Column<DateTime>(type: "DATE", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdExame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaConsulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarcaConsulta_Exame_IdExame",
                        column: x => x.IdExame,
                        principalTable: "Exame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaConsulta_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exame_IdTipoExame",
                table: "Exame",
                column: "IdTipoExame");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaConsulta_IdExame",
                table: "MarcaConsulta",
                column: "IdExame");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaConsulta_IdPaciente",
                table: "MarcaConsulta",
                column: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaConsulta");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "TipoExame");
        }
    }
}
