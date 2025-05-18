using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitFlow.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCuota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoCredito_Cuota_IdCuota",
                schema: "GES",
                table: "MovimientoCredito");

            migrationBuilder.DropTable(
                name: "Cuota",
                schema: "GES");

            migrationBuilder.DropIndex(
                name: "IX_MovimientoCredito_IdCuota",
                schema: "GES",
                table: "MovimientoCredito");

            migrationBuilder.DropColumn(
                name: "IdCuota",
                schema: "GES",
                table: "MovimientoCredito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IdCuota",
                schema: "GES",
                table: "MovimientoCredito",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cuota",
                schema: "GES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCredito = table.Column<long>(type: "bigint", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoCuota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCuota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuota_Credito_IdCredito",
                        column: x => x.IdCredito,
                        principalSchema: "GES",
                        principalTable: "Credito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuota_ParametroEspecifico_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "PAR",
                        principalTable: "ParametroEspecifico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCredito_IdCuota",
                schema: "GES",
                table: "MovimientoCredito",
                column: "IdCuota");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_IdCredito",
                schema: "GES",
                table: "Cuota",
                column: "IdCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_IdEstado",
                schema: "GES",
                table: "Cuota",
                column: "IdEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoCredito_Cuota_IdCuota",
                schema: "GES",
                table: "MovimientoCredito",
                column: "IdCuota",
                principalSchema: "GES",
                principalTable: "Cuota",
                principalColumn: "Id");
        }
    }
}
