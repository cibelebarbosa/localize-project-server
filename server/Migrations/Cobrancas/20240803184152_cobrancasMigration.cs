using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations.Cobrancas
{
    /// <inheritdoc />
    public partial class cobrancasMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "cobrancas",
                newName: "client_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "cobrancas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "cobrancas",
                newName: "cliente_id");

            migrationBuilder.AlterColumn<string>(
                name: "data",
                table: "cobrancas",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
