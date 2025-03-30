using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitFlow.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddParametrizacionAndPartOfGestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParGeneral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParGeneral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParEspecifico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", maxLength: 150, nullable: false),
                    IdParGeneral = table.Column<long>(type: "bigint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParEspecifico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParEspecifico_ParGeneral_IdParGeneral",
                        column: x => x.IdParGeneral,
                        principalTable: "ParGeneral",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoCuenta = table.Column<long>(type: "bigint", nullable: false),
                    IdBanco = table.Column<long>(type: "bigint", nullable: false),
                    NombreCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMoneda = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_ParEspecifico_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "ParEspecifico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuenta_ParEspecifico_IdMoneda",
                        column: x => x.IdMoneda,
                        principalTable: "ParEspecifico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuenta_ParEspecifico_IdTipoCuenta",
                        column: x => x.IdTipoCuenta,
                        principalTable: "ParEspecifico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuenta_Users_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdBanco",
                table: "Cuenta",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdMoneda",
                table: "Cuenta",
                column: "IdMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdTipoCuenta",
                table: "Cuenta",
                column: "IdTipoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdUsuario",
                table: "Cuenta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ParEspecifico_IdParGeneral",
                table: "ParEspecifico",
                column: "IdParGeneral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "ParEspecifico");

            migrationBuilder.DropTable(
                name: "ParGeneral");
        }
    }
}
