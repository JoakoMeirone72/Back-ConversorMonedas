using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class subnulleable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalConversiones",
                table: "usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalConversiones",
                table: "usuario");
        }
    }
}
