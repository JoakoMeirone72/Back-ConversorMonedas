using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class implementacionnuevastablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "moneda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Favoritas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "monedasDefault",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monedasDefault", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "monedasUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monedasUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "monedasDefault",
                columns: new[] { "Id", "IC", "Leyenda", "Simbolo" },
                values: new object[,]
                {
                    { 1, 0.002, "Peso Argentino", "Ars$" },
                    { 2, 1.0, "Dolar Americano", "Usd$" },
                    { 3, 0.042999999999999997, "Corona Checa", "Kc$" },
                    { 4, 1.0900000000000001, "Euro", "Eur$" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritas");

            migrationBuilder.DropTable(
                name: "monedasDefault");

            migrationBuilder.DropTable(
                name: "monedasUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "moneda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Favorita = table.Column<bool>(type: "INTEGER", nullable: false),
                    IC = table.Column<int>(type: "INTEGER", nullable: false),
                    Leyenda = table.Column<string>(type: "TEXT", nullable: false),
                    Simbolo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneda", x => x.Id);
                });
        }
    }
}
