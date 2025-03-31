using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitFlow.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntitiesToGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ParEspecifico_IdBanco",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ParEspecifico_IdMoneda",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ParEspecifico_IdTipoCuenta",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Users_IdUsuario",
                table: "Cuenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta");

            migrationBuilder.RenameTable(
                name: "Cuenta",
                newName: "Cuentas");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_IdUsuario",
                table: "Cuentas",
                newName: "IX_Cuentas_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_IdTipoCuenta",
                table: "Cuentas",
                newName: "IX_Cuentas_IdTipoCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_IdMoneda",
                table: "Cuentas",
                newName: "IX_Cuentas_IdMoneda");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_IdBanco",
                table: "Cuentas",
                newName: "IX_Cuentas_IdBanco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdCategoria = table.Column<long>(type: "bigint", nullable: false),
                    MontoAsignado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuestos_ParEspecifico_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "ParEspecifico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Presupuestos_Users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCuenta = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoProducto = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Saldo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimiteCredito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaldoDisponible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasaInteresanual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCorte = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaLimitePago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_ParEspecifico_IdTipoProducto",
                        column: x => x.IdTipoProducto,
                        principalTable: "ParEspecifico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovimientosDebito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoMovimiento = table.Column<long>(type: "bigint", nullable: false),
                    Monto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoPrevio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoPosterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosDebito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientosDebito_ParEspecifico_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalTable: "ParEspecifico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimientosDebito_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosDebito_IdProducto",
                table: "MovimientosDebito",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosDebito_IdTipoMovimiento",
                table: "MovimientosDebito",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_IdCategoria",
                table: "Presupuestos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_IdUsuario",
                table: "Presupuestos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCuenta",
                table: "Productos",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdTipoProducto",
                table: "Productos",
                column: "IdTipoProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_ParEspecifico_IdBanco",
                table: "Cuentas",
                column: "IdBanco",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_ParEspecifico_IdMoneda",
                table: "Cuentas",
                column: "IdMoneda",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_ParEspecifico_IdTipoCuenta",
                table: "Cuentas",
                column: "IdTipoCuenta",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Users_IdUsuario",
                table: "Cuentas",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_ParEspecifico_IdBanco",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_ParEspecifico_IdMoneda",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_ParEspecifico_IdTipoCuenta",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Users_IdUsuario",
                table: "Cuentas");

            migrationBuilder.DropTable(
                name: "MovimientosDebito");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas");

            migrationBuilder.RenameTable(
                name: "Cuentas",
                newName: "Cuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdUsuario",
                table: "Cuenta",
                newName: "IX_Cuenta_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdTipoCuenta",
                table: "Cuenta",
                newName: "IX_Cuenta_IdTipoCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdMoneda",
                table: "Cuenta",
                newName: "IX_Cuenta_IdMoneda");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdBanco",
                table: "Cuenta",
                newName: "IX_Cuenta_IdBanco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ParEspecifico_IdBanco",
                table: "Cuenta",
                column: "IdBanco",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ParEspecifico_IdMoneda",
                table: "Cuenta",
                column: "IdMoneda",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ParEspecifico_IdTipoCuenta",
                table: "Cuenta",
                column: "IdTipoCuenta",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Users_IdUsuario",
                table: "Cuenta",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
