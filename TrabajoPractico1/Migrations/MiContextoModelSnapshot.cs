﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabajoPractico1;

#nullable disable

namespace TrabajoPractico1.Migrations
{
    [DbContext(typeof(MiContexto))]
    partial class MiContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrabajoPractico1.CajaDeAhorro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cbu")
                        .HasColumnType("int");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("CajaAhorro", (string)null);
                });

            modelBuilder.Entity("TrabajoPractico1.Movimiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("detalle")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("DateTime");

                    b.Property<int>("id_Caja")
                        .HasColumnType("int");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("id_Caja");

                    b.ToTable("Movimiento", (string)null);
                });

            modelBuilder.Entity("TrabajoPractico1.Pago", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<string>("metodo")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("id_usuario");

                    b.ToTable("Pago", (string)null);
                });

            modelBuilder.Entity("TrabajoPractico1.PlazoFijo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cbu")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("dateTime");

                    b.Property<DateTime>("fechaIni")
                        .HasColumnType("dateTime");

                    b.Property<int>("id_titular")
                        .HasColumnType("int");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.Property<double>("tasa")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("id_titular");

                    b.ToTable("PlazoFijo", (string)null);
                });

            modelBuilder.Entity("TrabajoPractico1.Tarjeta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("codigoV")
                        .HasColumnType("int");

                    b.Property<double>("consumo")
                        .HasColumnType("float");

                    b.Property<int>("id_titular")
                        .HasColumnType("int");

                    b.Property<double>("limite")
                        .HasColumnType("float");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_titular");

                    b.ToTable("Tarjeta", (string)null);
                });

            modelBuilder.Entity("TrabajoPractico1.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("bloqueado")
                        .HasColumnType("bit");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<int>("intentosFallidos")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("TrabajoPractico1.UsuarioCaja", b =>
                {
                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<int>("idCaja")
                        .HasColumnType("int");

                    b.HasKey("idUsuario", "idCaja");

                    b.HasIndex("idCaja");

                    b.ToTable("UsuarioCaja");
                });

            modelBuilder.Entity("TrabajoPractico1.Movimiento", b =>
                {
                    b.HasOne("TrabajoPractico1.CajaDeAhorro", "caja")
                        .WithMany("movimientos")
                        .HasForeignKey("id_Caja");

                    b.Navigation("caja");
                });

            modelBuilder.Entity("TrabajoPractico1.Pago", b =>
                {
                    b.HasOne("TrabajoPractico1.Usuario", "usuario")
                        .WithMany("pagos")
                        .HasForeignKey("id_usuario");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("TrabajoPractico1.PlazoFijo", b =>
                {
                    b.HasOne("TrabajoPractico1.Usuario", "titular")
                        .WithMany("pf")
                        .HasForeignKey("id_titular");

                    b.Navigation("titular");
                });

            modelBuilder.Entity("TrabajoPractico1.Tarjeta", b =>
                {
                    b.HasOne("TrabajoPractico1.Usuario", "titular")
                        .WithMany("tarjetas")
                        .HasForeignKey("id_titular");

                    b.Navigation("titular");
                });

            modelBuilder.Entity("TrabajoPractico1.UsuarioCaja", b =>
                {
                    b.HasOne("TrabajoPractico1.CajaDeAhorro", "caja")
                        .WithMany("usuarioCajas")
                        .HasForeignKey("idCaja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoPractico1.Usuario", "usuario")
                        .WithMany("usuarioCajas")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("caja");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("TrabajoPractico1.CajaDeAhorro", b =>
                {
                    b.Navigation("movimientos");

                    b.Navigation("usuarioCajas");
                });

            modelBuilder.Entity("TrabajoPractico1.Usuario", b =>
                {
                    b.Navigation("pagos");

                    b.Navigation("pf");

                    b.Navigation("tarjetas");

                    b.Navigation("usuarioCajas");
                });
#pragma warning restore 612, 618
        }
    }
}
