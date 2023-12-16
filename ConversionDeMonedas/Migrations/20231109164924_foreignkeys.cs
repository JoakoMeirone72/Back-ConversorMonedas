using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "monedasUser",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favoritas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_monedasUser_UserId",
                table: "monedasUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritas_UserId",
                table: "Favoritas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritas_usuario_UserId",
                table: "Favoritas",
                column: "UserId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_monedasUser_usuario_UserId",
                table: "monedasUser",
                column: "UserId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritas_usuario_UserId",
                table: "Favoritas");

            migrationBuilder.DropForeignKey(
                name: "FK_monedasUser_usuario_UserId",
                table: "monedasUser");

            migrationBuilder.DropIndex(
                name: "IX_monedasUser_UserId",
                table: "monedasUser");

            migrationBuilder.DropIndex(
                name: "IX_Favoritas_UserId",
                table: "Favoritas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "monedasUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favoritas");
        }
    }
}
