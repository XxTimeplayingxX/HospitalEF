using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospítalPractice.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    IdDiagnostico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Severidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.IdDiagnostico);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    IdReceta = table.Column<int>(name: "Id_Receta", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.IdReceta);
                });

            migrationBuilder.CreateTable(
                name: "Meidco",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(name: "Persona_Id", type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId0 = table.Column<int>(name: "PersonaId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meidco", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meidco_Personas_PersonaId",
                        column: x => x.PersonaId0,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistorialMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personaid = table.Column<int>(name: "Persona_id", type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleRecetas",
                columns: table => new
                {
                    IdDetalleReceta = table.Column<int>(name: "Id_DetalleReceta", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recetaid = table.Column<int>(name: "Receta_id", type: "int", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frecuencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecetaIdReceta = table.Column<int>(name: "RecetaId_Receta", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleRecetas", x => x.IdDetalleReceta);
                    table.ForeignKey(
                        name: "FK_DetalleRecetas_Recetas_RecetaId_Receta",
                        column: x => x.RecetaIdReceta,
                        principalTable: "Recetas",
                        principalColumn: "Id_Receta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitaMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicoId = table.Column<int>(name: "Medico_Id", type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Recetaid = table.Column<int>(name: "Receta_id", type: "int", nullable: false),
                    Diagnosticoid = table.Column<int>(name: "Diagnostico_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitaMedicos_Diagnosticos_Diagnostico_id",
                        column: x => x.Diagnosticoid,
                        principalTable: "Diagnosticos",
                        principalColumn: "IdDiagnostico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedicos_Meidco_Medico_Id",
                        column: x => x.MedicoId,
                        principalTable: "Meidco",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaMedicos_Recetas_Receta_id",
                        column: x => x.Recetaid,
                        principalTable: "Recetas",
                        principalColumn: "Id_Receta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignosVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pulso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaCardiaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pacienteid = table.Column<int>(name: "Paciente_id", type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignosVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignosVitales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitaMedicaDiagnosticos",
                columns: table => new
                {
                    IdCitaMedicaDiagnostico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCitaMedica = table.Column<int>(type: "int", nullable: false),
                    IdDiagnostico = table.Column<int>(type: "int", nullable: false),
                    CitaMedicoId = table.Column<int>(type: "int", nullable: false),
                    DiagnosticoIdDiagnostico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaMedicaDiagnosticos", x => x.IdCitaMedicaDiagnostico);
                    table.ForeignKey(
                        name: "FK_CitaMedicaDiagnosticos_CitaMedicos_CitaMedicoId",
                        column: x => x.CitaMedicoId,
                        principalTable: "CitaMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitaMedicaDiagnosticos_Diagnosticos_DiagnosticoIdDiagnostico",
                        column: x => x.DiagnosticoIdDiagnostico,
                        principalTable: "Diagnosticos",
                        principalColumn: "IdDiagnostico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedicaDiagnosticos_CitaMedicoId",
                table: "CitaMedicaDiagnosticos",
                column: "CitaMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedicaDiagnosticos_DiagnosticoIdDiagnostico",
                table: "CitaMedicaDiagnosticos",
                column: "DiagnosticoIdDiagnostico");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedicos_Diagnostico_id",
                table: "CitaMedicos",
                column: "Diagnostico_id");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedicos_Medico_Id",
                table: "CitaMedicos",
                column: "Medico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedicos_Receta_id",
                table: "CitaMedicos",
                column: "Receta_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecetas_RecetaId_Receta",
                table: "DetalleRecetas",
                column: "RecetaId_Receta");

            migrationBuilder.CreateIndex(
                name: "IX_Meidco_PersonaId",
                table: "Meidco",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PersonaId",
                table: "Pacientes",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_SignosVitales_PacienteId",
                table: "SignosVitales",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitaMedicaDiagnosticos");

            migrationBuilder.DropTable(
                name: "DetalleRecetas");

            migrationBuilder.DropTable(
                name: "SignosVitales");

            migrationBuilder.DropTable(
                name: "CitaMedicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Meidco");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
