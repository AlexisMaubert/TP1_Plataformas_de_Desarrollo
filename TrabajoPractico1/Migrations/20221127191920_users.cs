using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabajoPractico1.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimiento_CajaAhorro_id_Caja",
                table: "Movimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Usuario_id_usuario",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_PlazoFijo_Usuario_id_titular",
                table: "PlazoFijo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Usuario_id_titular",
                table: "Tarjeta");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "id", "apellido", "bloqueado", "dni", "intentosFallidos", "isAdmin", "mail", "nombre", "password" },
                values: new object[,]
                {
                    { 1, "Muzzio", false, 40009479, 0, true, "franco.muzzio@davinci.edu.ar", "Franco", "1234" },
                    { 2, "Piñeiro", false, 63309307, 0, true, "fiorella.piñeiro@davinci.edu.ar", "Fiorella", "1234" },
                    { 3, "Markauskas", false, 32677773, 0, true, "magalí.markauskas@davinci.edu.ar", "Magalí", "1234" },
                    { 4, "Sassano", false, 21035623, 0, true, "martín.sassano@davinci.edu.ar", "Martín", "1234" },
                    { 5, "Giudice", false, 23391008, 0, true, "agustín.giudice@davinci.edu.ar", "Agustín", "1234" },
                    { 6, "Maubert", false, 45686773, 0, true, "alexis.maubert@davinci.edu.ar", "Alexis", "1234" },
                    { 7, "Di Marco", false, 84355987, 0, false, "marcos.dimarco@davinci.edu.ar", "Marcos", "1234" },
                    { 8, "Gutierrez", false, 40563444, 2, false, "juliana.gutierrez@davinci.edu.ar", "Juliana", "1234" },
                    { 9, "Houseman", false, 30447163, 0, false, "ariana.houseman@davinci.edu.ar", "Ariana", "1234" },
                    { 10, "Poggi", false, 73026363, 1, false, "pedro.poggi@davinci.edu.ar", "Pedro", "1234" },
                    { 11, "Ramirez", true, 39440793, 0, false, "lazaro.ramirez@davinci.edu.ar", "Lazaro", "1234" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movimiento_CajaAhorro_id_Caja",
                table: "Movimiento",
                column: "id_Caja",
                principalTable: "CajaAhorro",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Usuario_id_usuario",
                table: "Pago",
                column: "id_usuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlazoFijo_Usuario_id_titular",
                table: "PlazoFijo",
                column: "id_titular",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Usuario_id_titular",
                table: "Tarjeta",
                column: "id_titular",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimiento_CajaAhorro_id_Caja",
                table: "Movimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Usuario_id_usuario",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_PlazoFijo_Usuario_id_titular",
                table: "PlazoFijo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Usuario_id_titular",
                table: "Tarjeta");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimiento_CajaAhorro_id_Caja",
                table: "Movimiento",
                column: "id_Caja",
                principalTable: "CajaAhorro",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Usuario_id_usuario",
                table: "Pago",
                column: "id_usuario",
                principalTable: "Usuario",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlazoFijo_Usuario_id_titular",
                table: "PlazoFijo",
                column: "id_titular",
                principalTable: "Usuario",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Usuario_id_titular",
                table: "Tarjeta",
                column: "id_titular",
                principalTable: "Usuario",
                principalColumn: "id");
        }
    }
}
