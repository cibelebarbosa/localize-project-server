using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations.Clientes
{
    /// <inheritdoc />
    public partial class addForeingKeyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "clientes");
        }
    }
}
