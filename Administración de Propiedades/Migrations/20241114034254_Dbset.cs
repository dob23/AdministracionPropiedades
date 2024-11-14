using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Administración_de_Propiedades.Migrations
{
    /// <inheritdoc />
    public partial class Dbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    IdPropiedad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoPropiedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroHabitaciones = table.Column<int>(type: "int", nullable: false),
                    PrecioAlquiler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.IdPropiedad);
                });

            migrationBuilder.CreateTable(
                name: "Inquilinos",
                columns: table => new
                {
                    IdInquilino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPropiedad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilinos", x => x.IdInquilino);
                    table.ForeignKey(
                        name: "FK_Inquilinos_Propiedades_IdPropiedad",
                        column: x => x.IdPropiedad,
                        principalTable: "Propiedades",
                        principalColumn: "IdPropiedad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    IdContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPropiedad = table.Column<int>(type: "int", nullable: false),
                    IdInquilino = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deposito = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Terminos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.IdContrato);
                    table.ForeignKey(
                        name: "FK_Contratos_Inquilinos_IdInquilino",
                        column: x => x.IdInquilino,
                        principalTable: "Inquilinos",
                        principalColumn: "IdInquilino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Propiedades_IdPropiedad",
                        column: x => x.IdPropiedad,
                        principalTable: "Propiedades",
                        principalColumn: "IdPropiedad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Contratos_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contratos",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdInquilino",
                table: "Contratos",
                column: "IdInquilino");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdPropiedad",
                table: "Contratos",
                column: "IdPropiedad");

            migrationBuilder.CreateIndex(
                name: "IX_Inquilinos_IdPropiedad",
                table: "Inquilinos",
                column: "IdPropiedad");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdContrato",
                table: "Pagos",
                column: "IdContrato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Inquilinos");

            migrationBuilder.DropTable(
                name: "Propiedades");
        }
    }
}
