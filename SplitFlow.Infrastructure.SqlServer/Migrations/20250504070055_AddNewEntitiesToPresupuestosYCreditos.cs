using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitFlow.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntitiesToPresupuestosYCreditos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosDebito_ParEspecifico_IdTipoMovimiento",
                table: "MovimientosDebito");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosDebito_Productos_IdProducto",
                table: "MovimientosDebito");

            migrationBuilder.DropForeignKey(
                name: "FK_ParEspecifico_ParGeneral_IdParGeneral",
                table: "ParEspecifico");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_ParEspecifico_IdCategoria",
                table: "Presupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Users_IdUsuario",
                table: "Presupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Cuentas_IdCuenta",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_ParEspecifico_IdTipoProducto",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_RolModulo_Modulos_ModuloId",
                table: "RolModulo");

            migrationBuilder.DropForeignKey(
                name: "FK_RolModulo_Roles_RoleId",
                table: "RolModulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presupuestos",
                table: "Presupuestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParGeneral",
                table: "ParGeneral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParEspecifico",
                table: "ParEspecifico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovimientosDebito",
                table: "MovimientosDebito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Presupuestos");

            migrationBuilder.EnsureSchema(
                name: "GES");

            migrationBuilder.EnsureSchema(
                name: "PER");

            migrationBuilder.EnsureSchema(
                name: "PAR");

            migrationBuilder.RenameTable(
                name: "RolModulo",
                newName: "RolModulo",
                newSchema: "PER");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "PER");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role",
                newSchema: "PER");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto",
                newSchema: "GES");

            migrationBuilder.RenameTable(
                name: "Presupuestos",
                newName: "Presupuesto",
                newSchema: "GES");

            migrationBuilder.RenameTable(
                name: "ParGeneral",
                newName: "ParametroGeneral",
                newSchema: "PAR");

            migrationBuilder.RenameTable(
                name: "ParEspecifico",
                newName: "ParametroEspecifico",
                newSchema: "PAR");

            migrationBuilder.RenameTable(
                name: "MovimientosDebito",
                newName: "MovimientoDebito",
                newSchema: "GES");

            migrationBuilder.RenameTable(
                name: "Modulos",
                newName: "Modulo",
                newSchema: "PER");

            migrationBuilder.RenameTable(
                name: "Cuentas",
                newName: "Cuenta",
                newSchema: "GES");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                schema: "PER",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdTipoProducto",
                schema: "GES",
                table: "Producto",
                newName: "IX_Producto_IdTipoProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_IdCuenta",
                schema: "GES",
                table: "Producto",
                newName: "IX_Producto_IdCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_IdUsuario",
                schema: "GES",
                table: "Presupuesto",
                newName: "IX_Presupuesto_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_IdCategoria",
                schema: "GES",
                table: "Presupuesto",
                newName: "IX_Presupuesto_IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_ParEspecifico_IdParGeneral",
                schema: "PAR",
                table: "ParametroEspecifico",
                newName: "IX_ParametroEspecifico_IdParGeneral");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosDebito_IdTipoMovimiento",
                schema: "GES",
                table: "MovimientoDebito",
                newName: "IX_MovimientoDebito_IdTipoMovimiento");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosDebito_IdProducto",
                schema: "GES",
                table: "MovimientoDebito",
                newName: "IX_MovimientoDebito_IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdUsuario",
                schema: "GES",
                table: "Cuenta",
                newName: "IX_Cuenta_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdTipoCuenta",
                schema: "GES",
                table: "Cuenta",
                newName: "IX_Cuenta_IdTipoCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdMoneda",
                schema: "GES",
                table: "Cuenta",
                newName: "IX_Cuenta_IdMoneda");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_IdBanco",
                schema: "GES",
                table: "Cuenta",
                newName: "IX_Cuenta_IdBanco");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                schema: "GES",
                table: "Presupuesto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "PER",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "PER",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                schema: "GES",
                table: "Producto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presupuesto",
                schema: "GES",
                table: "Presupuesto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParametroGeneral",
                schema: "PAR",
                table: "ParametroGeneral",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParametroEspecifico",
                schema: "PAR",
                table: "ParametroEspecifico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovimientoDebito",
                schema: "GES",
                table: "MovimientoDebito",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modulo",
                schema: "PER",
                table: "Modulo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuenta",
                schema: "GES",
                table: "Cuenta",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Credito",
                schema: "GES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    MontoTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoPendiente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasaInteres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credito_ParametroEspecifico_IdEstado",
                        column: x => x.IdEstado,
                        principalSchema: "PAR",
                        principalTable: "ParametroEspecifico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Credito_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalSchema: "GES",
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                schema: "GES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCredito = table.Column<long>(type: "bigint", nullable: false),
                    NumeroCuota = table.Column<int>(type: "int", nullable: false),
                    MontoCuota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstado = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MovimientoCredito",
                schema: "GES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCredito = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoMovimiento = table.Column<long>(type: "bigint", nullable: false),
                    Monto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoRestante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCuota = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoCredito_Credito_IdCredito",
                        column: x => x.IdCredito,
                        principalSchema: "GES",
                        principalTable: "Credito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimientoCredito_Cuota_IdCuota",
                        column: x => x.IdCuota,
                        principalSchema: "GES",
                        principalTable: "Cuota",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimientoCredito_ParametroEspecifico_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalSchema: "PAR",
                        principalTable: "ParametroEspecifico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gasto",
                schema: "GES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPresupuesto = table.Column<long>(type: "bigint", nullable: false),
                    IdMovimientoDebito = table.Column<long>(type: "bigint", nullable: true),
                    IdMovimientoCredito = table.Column<long>(type: "bigint", nullable: true),
                    Monto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaGAsto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasto_MovimientoCredito_IdMovimientoCredito",
                        column: x => x.IdMovimientoCredito,
                        principalSchema: "GES",
                        principalTable: "MovimientoCredito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasto_MovimientoDebito_IdMovimientoDebito",
                        column: x => x.IdMovimientoDebito,
                        principalSchema: "GES",
                        principalTable: "MovimientoDebito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasto_Presupuesto_IdPresupuesto",
                        column: x => x.IdPresupuesto,
                        principalSchema: "GES",
                        principalTable: "Presupuesto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credito_IdEstado",
                schema: "GES",
                table: "Credito",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_IdProducto",
                schema: "GES",
                table: "Credito",
                column: "IdProducto");

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

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_IdMovimientoCredito",
                schema: "GES",
                table: "Gasto",
                column: "IdMovimientoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_IdMovimientoDebito",
                schema: "GES",
                table: "Gasto",
                column: "IdMovimientoDebito");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_IdPresupuesto",
                schema: "GES",
                table: "Gasto",
                column: "IdPresupuesto");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCredito_IdCredito",
                schema: "GES",
                table: "MovimientoCredito",
                column: "IdCredito");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCredito_IdCuota",
                schema: "GES",
                table: "MovimientoCredito",
                column: "IdCuota");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCredito_IdTipoMovimiento",
                schema: "GES",
                table: "MovimientoCredito",
                column: "IdTipoMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ParametroEspecifico_IdBanco",
                schema: "GES",
                table: "Cuenta",
                column: "IdBanco",
                principalSchema: "PAR",
                principalTable: "ParametroEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ParametroEspecifico_IdMoneda",
                schema: "GES",
                table: "Cuenta",
                column: "IdMoneda",
                principalSchema: "PAR",
                principalTable: "ParametroEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_ParametroEspecifico_IdTipoCuenta",
                schema: "GES",
                table: "Cuenta",
                column: "IdTipoCuenta",
                principalSchema: "PAR",
                principalTable: "ParametroEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_User_IdUsuario",
                schema: "GES",
                table: "Cuenta",
                column: "IdUsuario",
                principalSchema: "PER",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoDebito_ParametroEspecifico_IdTipoMovimiento",
                schema: "GES",
                table: "MovimientoDebito",
                column: "IdTipoMovimiento",
                principalSchema: "PAR",
                principalTable: "ParametroEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientoDebito_Producto_IdProducto",
                schema: "GES",
                table: "MovimientoDebito",
                column: "IdProducto",
                principalSchema: "GES",
                principalTable: "Producto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParametroEspecifico_ParametroGeneral_IdParGeneral",
                schema: "PAR",
                table: "ParametroEspecifico",
                column: "IdParGeneral",
                principalSchema: "PAR",
                principalTable: "ParametroGeneral",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuesto_ParametroEspecifico_IdCategoria",
                schema: "GES",
                table: "Presupuesto",
                column: "IdCategoria",
                principalSchema: "PAR",
                principalTable: "ParametroEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuesto_User_IdUsuario",
                schema: "GES",
                table: "Presupuesto",
                column: "IdUsuario",
                principalSchema: "PER",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Cuenta_IdCuenta",
                schema: "GES",
                table: "Producto",
                column: "IdCuenta",
                principalSchema: "GES",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ParametroEspecifico_IdTipoProducto",
                schema: "GES",
                table: "Producto",
                column: "IdTipoProducto",
                principalSchema: "PAR",
                principalTable: "ParametroEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolModulo_Modulo_ModuloId",
                schema: "PER",
                table: "RolModulo",
                column: "ModuloId",
                principalSchema: "PER",
                principalTable: "Modulo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolModulo_Role_RoleId",
                schema: "PER",
                table: "RolModulo",
                column: "RoleId",
                principalSchema: "PER",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "PER",
                table: "User",
                column: "RoleId",
                principalSchema: "PER",
                principalTable: "Role",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ParametroEspecifico_IdBanco",
                schema: "GES",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ParametroEspecifico_IdMoneda",
                schema: "GES",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_ParametroEspecifico_IdTipoCuenta",
                schema: "GES",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_User_IdUsuario",
                schema: "GES",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoDebito_ParametroEspecifico_IdTipoMovimiento",
                schema: "GES",
                table: "MovimientoDebito");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientoDebito_Producto_IdProducto",
                schema: "GES",
                table: "MovimientoDebito");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametroEspecifico_ParametroGeneral_IdParGeneral",
                schema: "PAR",
                table: "ParametroEspecifico");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuesto_ParametroEspecifico_IdCategoria",
                schema: "GES",
                table: "Presupuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuesto_User_IdUsuario",
                schema: "GES",
                table: "Presupuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Cuenta_IdCuenta",
                schema: "GES",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ParametroEspecifico_IdTipoProducto",
                schema: "GES",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_RolModulo_Modulo_ModuloId",
                schema: "PER",
                table: "RolModulo");

            migrationBuilder.DropForeignKey(
                name: "FK_RolModulo_Role_RoleId",
                schema: "PER",
                table: "RolModulo");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "PER",
                table: "User");

            migrationBuilder.DropTable(
                name: "Gasto",
                schema: "GES");

            migrationBuilder.DropTable(
                name: "MovimientoCredito",
                schema: "GES");

            migrationBuilder.DropTable(
                name: "Cuota",
                schema: "GES");

            migrationBuilder.DropTable(
                name: "Credito",
                schema: "GES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "PER",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "PER",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                schema: "GES",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presupuesto",
                schema: "GES",
                table: "Presupuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParametroGeneral",
                schema: "PAR",
                table: "ParametroGeneral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParametroEspecifico",
                schema: "PAR",
                table: "ParametroEspecifico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovimientoDebito",
                schema: "GES",
                table: "MovimientoDebito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modulo",
                schema: "PER",
                table: "Modulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuenta",
                schema: "GES",
                table: "Cuenta");

            migrationBuilder.DropColumn(
                name: "Activo",
                schema: "GES",
                table: "Presupuesto");

            migrationBuilder.RenameTable(
                name: "RolModulo",
                schema: "PER",
                newName: "RolModulo");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "PER",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "PER",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Producto",
                schema: "GES",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "Presupuesto",
                schema: "GES",
                newName: "Presupuestos");

            migrationBuilder.RenameTable(
                name: "ParametroGeneral",
                schema: "PAR",
                newName: "ParGeneral");

            migrationBuilder.RenameTable(
                name: "ParametroEspecifico",
                schema: "PAR",
                newName: "ParEspecifico");

            migrationBuilder.RenameTable(
                name: "MovimientoDebito",
                schema: "GES",
                newName: "MovimientosDebito");

            migrationBuilder.RenameTable(
                name: "Modulo",
                schema: "PER",
                newName: "Modulos");

            migrationBuilder.RenameTable(
                name: "Cuenta",
                schema: "GES",
                newName: "Cuentas");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_IdTipoProducto",
                table: "Productos",
                newName: "IX_Productos_IdTipoProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_IdCuenta",
                table: "Productos",
                newName: "IX_Productos_IdCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuesto_IdUsuario",
                table: "Presupuestos",
                newName: "IX_Presupuestos_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuesto_IdCategoria",
                table: "Presupuestos",
                newName: "IX_Presupuestos_IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_ParametroEspecifico_IdParGeneral",
                table: "ParEspecifico",
                newName: "IX_ParEspecifico_IdParGeneral");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientoDebito_IdTipoMovimiento",
                table: "MovimientosDebito",
                newName: "IX_MovimientosDebito_IdTipoMovimiento");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientoDebito_IdProducto",
                table: "MovimientosDebito",
                newName: "IX_MovimientosDebito_IdProducto");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Presupuestos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Presupuestos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presupuestos",
                table: "Presupuestos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParGeneral",
                table: "ParGeneral",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParEspecifico",
                table: "ParEspecifico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovimientosDebito",
                table: "MovimientosDebito",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosDebito_ParEspecifico_IdTipoMovimiento",
                table: "MovimientosDebito",
                column: "IdTipoMovimiento",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosDebito_Productos_IdProducto",
                table: "MovimientosDebito",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParEspecifico_ParGeneral_IdParGeneral",
                table: "ParEspecifico",
                column: "IdParGeneral",
                principalTable: "ParGeneral",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_ParEspecifico_IdCategoria",
                table: "Presupuestos",
                column: "IdCategoria",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Users_IdUsuario",
                table: "Presupuestos",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Cuentas_IdCuenta",
                table: "Productos",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_ParEspecifico_IdTipoProducto",
                table: "Productos",
                column: "IdTipoProducto",
                principalTable: "ParEspecifico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolModulo_Modulos_ModuloId",
                table: "RolModulo",
                column: "ModuloId",
                principalTable: "Modulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolModulo_Roles_RoleId",
                table: "RolModulo",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
