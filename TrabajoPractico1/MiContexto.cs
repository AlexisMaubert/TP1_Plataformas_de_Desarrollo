﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrabajoPractico1
{
    internal class MiContexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<CajaDeAhorro> cajas { get; set; }
        public DbSet<PlazoFijo> plazosFijos { get; set; }
        public DbSet<Tarjeta> tarjetas { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Movimiento> movimientos { get; set; }


        public MiContexto() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Resources.ConnectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario")
                .HasKey(user => user.id);
            modelBuilder.Entity<PlazoFijo>()
                .ToTable("PlazoFijo")
                .HasKey(pf => pf.id);
            modelBuilder.Entity<CajaDeAhorro>()
                .ToTable("CajaAhorro")
                .HasKey(c => c.id);
            modelBuilder.Entity<Pago>()
                .ToTable("Pago")
                .HasKey(p => p.id);
            modelBuilder.Entity<Tarjeta>()
                .ToTable("Tarjeta")
                .HasKey(t => t.id);
            modelBuilder.Entity<Movimiento>()
                .ToTable("Movimiento")
                .HasKey(mov => mov.id);

            //RELACIONES

            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.cajas)
                .WithMany(C => C.titulares)
            .UsingEntity<UsuarioCaja>(
                euc => euc.HasOne(uc => uc.caja).WithMany(c => c.usuarioCajas).HasForeignKey(uc => uc.idCaja),
                euc => euc.HasOne(uc => uc.usuario).WithMany(u => u.usuarioCajas).HasForeignKey(uc => uc.idUsuario),
                euc => euc.HasKey(k => new { k.idUsuario, k.idCaja })
            );

            modelBuilder.Entity<PlazoFijo>()
                .HasOne(pf => pf.titular)
                .WithMany(u => u.pf)
                .HasForeignKey(pf => pf.id_titular)
                .IsRequired(false);
            modelBuilder.Entity<Movimiento>()
                .HasOne(mov => mov.caja)
                .WithMany(caja => caja.movimientos)
                .HasForeignKey(m => m.id_Caja)
                .IsRequired(false);
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.usuario)
                .WithMany(u => u.pagos)
                .HasForeignKey(p => p.id_usuario)
                .IsRequired(false);
            modelBuilder.Entity<Tarjeta>()
                .HasOne(t => t.titular)
                .WithMany(u => u.tarjetas)
                .HasForeignKey(t => t.id_titular)
                .IsRequired(false);

            //Seteo de datos
            modelBuilder.Entity<Usuario>(
                user =>
                {
                    user.Property(u => u.id).HasColumnType("int");
                    user.Property(u => u.id).IsRequired(true);
                    user.Property(u => u.dni).HasColumnType("int");
                    user.Property(u => u.dni).IsRequired(true);
                    user.Property(u => u.nombre).HasColumnType("varchar(50)");
                    user.Property(u => u.nombre).IsRequired(true);
                    user.Property(u => u.apellido).HasColumnType("varchar(50)");
                    user.Property(u => u.apellido).IsRequired(true);
                    user.Property(u => u.mail).HasColumnType("varchar(50)");
                    user.Property(u => u.mail).IsRequired(true);
                    user.Property(u => u.password).HasColumnType("varchar(50)");
                    user.Property(u => u.password).IsRequired(true);
                    user.Property(u => u.intentosFallidos).HasColumnType("int");
                    user.Property(u => u.bloqueado).HasColumnType("bit");
                    user.Property(u => u.isAdmin).HasColumnType("bit");
                });

            modelBuilder.Entity<PlazoFijo>(
                pf =>
                {
                    pf.Property(p => p.id).HasColumnType("int");
                    pf.Property(p => p.id).IsRequired(true);
                    pf.Property(p => p.monto).HasColumnType("float");
                    pf.Property(p => p.monto).IsRequired(true);
                    pf.Property(p => p.fechaIni).HasColumnType("dateTime");
                    pf.Property(p => p.fechaIni).IsRequired(true);
                    pf.Property(p => p.fechaFin).HasColumnType("dateTime");
                    pf.Property(p => p.fechaFin).IsRequired(true);
                    pf.Property(p => p.tasa).HasColumnType("float");
                    pf.Property(p => p.tasa).IsRequired(true);
                    pf.Property(p => p.pagado).HasColumnType("bit");
                    pf.Property(p => p.pagado).IsRequired(true);
                });

            modelBuilder.Entity<CajaDeAhorro>(
                caja =>
                {
                    caja.Property(c => c.id).HasColumnType("int");
                    caja.Property(c => c.id).IsRequired(true);
                    caja.Property(c => c.cbu).HasColumnType("int");
                    caja.Property(c => c.cbu).IsRequired(true);
                    caja.Property(c => c.saldo).HasColumnType("float");
                    caja.Property(c => c.saldo).IsRequired(true);
                });

            modelBuilder.Entity<Pago>(
                pago =>
                {
                    pago.Property(p => p.id).HasColumnType("int");
                    pago.Property(p => p.id).IsRequired(true);
                    pago.Property(p => p.nombre).HasColumnType("varchar(50)");
                    pago.Property(p => p.nombre).IsRequired(true);
                    pago.Property(p => p.monto).HasColumnType("float");
                    pago.Property(p => p.monto).IsRequired(true);
                    pago.Property(p => p.pagado).HasColumnType("bit");
                    pago.Property(p => p.pagado).IsRequired(true);
                    pago.Property(p => p.metodo).HasColumnType("varchar(50)");
                    pago.Property(p => p.metodo).IsRequired(false);
                });

            modelBuilder.Entity<Movimiento>(
                mov =>
                {
                    mov.Property(m => m.id).HasColumnType("int");
                    mov.Property(m => m.id).IsRequired(true);
                    mov.Property(m => m.detalle).HasColumnType("varchar(255)");
                    mov.Property(m => m.detalle).IsRequired(true);
                    mov.Property(m => m.monto).HasColumnType("float");
                    mov.Property(m => m.monto).IsRequired(true);
                    mov.Property(m => m.fecha).HasColumnType("DateTime");
                    mov.Property(m => m.fecha).IsRequired(true);
                }
                );

            modelBuilder.Entity<Tarjeta>(
                tarj =>
                {
                    tarj.Property(t => t.id).HasColumnType("int");
                    tarj.Property(t => t.id).IsRequired(true);
                    tarj.Property(t => t.numero).HasColumnType("int");
                    tarj.Property(t => t.numero).IsRequired(true);
                    tarj.Property(t => t.codigoV).HasColumnType("int");
                    tarj.Property(t => t.codigoV).IsRequired(true);
                    tarj.Property(t => t.limite).HasColumnType("float");
                    tarj.Property(t => t.limite).IsRequired(true);
                    tarj.Property(t => t.consumo).HasColumnType("float");
                    tarj.Property(t => t.consumo).IsRequired(true);
                });

            modelBuilder.Ignore<Banco>();

        }
    }
}
