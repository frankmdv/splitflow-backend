using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitFlow.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class EditTableCredito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cuotas",
                schema: "GES",
                table: "Credito");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                schema: "GES",
                table: "Credito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cuotas",
                schema: "GES",
                table: "Credito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                schema: "GES",
                table: "Credito",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
