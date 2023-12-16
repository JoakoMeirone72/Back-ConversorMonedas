using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversionDeMonedas.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaTotalconversiones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "TotalConversiones",
            table: "usuario",
            nullable: true,
            defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
