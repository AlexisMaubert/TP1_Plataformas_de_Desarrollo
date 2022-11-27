using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoPractico1.Migrations
{
    /// <inheritdoc />
    public partial class AddCbuColumnToPlazoFijo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cbu",
                table: "PlazoFijo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cbu",
                table: "PlazoFijo");
        }
    }
}
