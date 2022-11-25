using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabajoPractico1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CajaAhorro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cbu = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaAhorro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    mail = table.Column<string>(type: "varchar(50)", nullable: false),
                    intentosFallidos = table.Column<int>(type: "int", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detalle = table.Column<string>(type: "varchar(255)", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    idCaja = table.Column<int>(name: "id_Caja", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movimiento_CajaAhorro_id_Caja",
                        column: x => x.idCaja,
                        principalTable: "CajaAhorro",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idusuario = table.Column<int>(name: "id_usuario", type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    metodo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pago_Usuario_id_usuario",
                        column: x => x.idusuario,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PlazoFijo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fechaIni = table.Column<DateTime>(type: "dateTime", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "dateTime", nullable: false),
                    tasa = table.Column<double>(type: "float", nullable: false),
                    pagado = table.Column<bool>(type: "bit", nullable: false),
                    idtitular = table.Column<int>(name: "id_titular", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlazoFijo", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlazoFijo_Usuario_id_titular",
                        column: x => x.idtitular,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idtitular = table.Column<int>(name: "id_titular", type: "int", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    codigoV = table.Column<int>(type: "int", nullable: false),
                    limite = table.Column<double>(type: "float", nullable: false),
                    consumo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Usuario_id_titular",
                        column: x => x.idtitular,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCaja",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idCaja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCaja", x => new { x.idUsuario, x.idCaja });
                    table.ForeignKey(
                        name: "FK_UsuarioCaja_CajaAhorro_idCaja",
                        column: x => x.idCaja,
                        principalTable: "CajaAhorro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCaja_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_id_Caja",
                table: "Movimiento",
                column: "id_Caja");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_id_usuario",
                table: "Pago",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_PlazoFijo_id_titular",
                table: "PlazoFijo",
                column: "id_titular");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_id_titular",
                table: "Tarjeta",
                column: "id_titular");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCaja_idCaja",
                table: "UsuarioCaja",
                column: "idCaja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PlazoFijo");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "UsuarioCaja");

            migrationBuilder.DropTable(
                name: "CajaAhorro");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
