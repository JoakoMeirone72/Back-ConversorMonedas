using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class RenovacionDeEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "moneda",
                newName: "IC");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "moneda",
                newName: "Simbolo");

            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Suscripcion",
                table: "usuarios",
                type: "INTEGER",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Favorita",
                table: "moneda",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Leyenda",
                table: "moneda",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Suscripcion",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Favorita",
                table: "moneda");

            migrationBuilder.DropColumn(
                name: "Leyenda",
                table: "moneda");

            migrationBuilder.RenameColumn(
                name: "Simbolo",
                table: "moneda",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "IC",
                table: "moneda",
                newName: "Valor");

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });
        }
    }
}
