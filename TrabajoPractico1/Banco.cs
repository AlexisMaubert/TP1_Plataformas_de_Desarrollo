using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TrabajoPractico1
{

    public class Banco
    {
        private MiContexto contexto;
        private Usuario usuarioLogeado;

        public Banco()
        {
            inicializarAtributos();
        }
        public void inicializarAtributos()
        {
            try
            {
                contexto = new MiContexto();
                contexto.usuarios
                    .Include(u => u.tarjetas)
                    .Include(u => u.cajas)
                    .Include(u => u.pf)
                    .Include(u => u.pagos)
                    .Load();
                contexto.cajas
                    .Include(c => c.movimientos)
                    .Include(c => c.titulares)
                    .Load();
                contexto.tarjetas.Load();
                contexto.pagos.Load();
                contexto.movimientos.Load();
                contexto.plazosFijos.Load();

            }
            catch
            {

            }
        }
        public void cerrar()
        {
            contexto.Dispose();
        }
        //
        //MOVIMIENTOS
        //
        public bool altaMovimiento(CajaDeAhorro Caja, string Detalle, float Monto)
        {
            try
            {
                Movimiento movimientoNuevo = new Movimiento(Caja, Detalle, Monto);
                contexto.movimientos.Add(movimientoNuevo);
                Caja.movimientos.Add(movimientoNuevo);
                contexto.Update(Caja);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        //USUARIOS
        //

        public bool altaUsuario(string Nombre, string Apellido, int Dni, string Mail, string Password) //Funciona ahjaja
        {
            bool esValido = true;
            if (esValido)
            {
                try
                {
                    Usuario nuevo = new Usuario(Dni, Nombre, Apellido, Mail, Password, 0, false, false);
                    contexto.usuarios.Add(nuevo);
                    contexto.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool bajaUsuario(int Id) //Funciona ahjaja 
        {
            try
            {
                Usuario usuarioARemover = contexto.usuarios.Where(u => u.id == Id).FirstOrDefault();
                if (usuarioARemover != null)
                {
                    contexto.usuarios.Remove(usuarioARemover);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool modificarUsuario(int Id, int dni, string mail, string pass)
        {
            try
            {
                Usuario usuarioAModificar = contexto.usuarios.Where(u => u.id == Id).FirstOrDefault();
                if (usuarioAModificar != null)
                {
                    usuarioAModificar.mail = mail;
                    usuarioAModificar.password = pass;
                    contexto.Update(usuarioAModificar);
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //
        //CAJAS---------------------------------------------
        //
        public void cerrarSesion()
        {
            this.usuarioLogeado = null;
        }
        public int crearCajaDeAhorro()
        {
            Random random = new Random();
            int nuevoCbu = random.Next(100000000, 999999999);
            while (contexto.cajas.Any(caja => caja.cbu == nuevoCbu))
            {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                nuevoCbu = random.Next(100000000, 999999999);
                Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
            }
            //Ahora sí lo agrego en la lista
            CajaDeAhorro nuevo = new CajaDeAhorro(nuevoCbu, usuarioLogeado);
            contexto.cajas.Add(nuevo);
            contexto.Update(usuarioLogeado);
            contexto.SaveChanges();
            return 0;
        }
        public int bajaCaja(int IdCaja)
        {
            try
            {
                CajaDeAhorro? cajaARemover = BuscarCajaDeAhorro(IdCaja);
                if (cajaARemover == null)
                {
                    return 1;
                }
                if (cajaARemover.saldo != 0)
                {
                    return 2;
                }
                foreach (Usuario titular in cajaARemover.titulares) //Itero entre los titulares de la caja de ahorro
                {
                    titular.cajas.Remove(cajaARemover);  //Saco la caja de ahorro de los titulares.
                }
                contexto.cajas.Remove(cajaARemover); //Saco la caja de ahorro del banco
                contexto.SaveChanges();

                return 0;
            }
            catch
            {
                return 3;
            }
        }

        public int agregarUsuarioACaja(int Id, int Dni)
        {
            try
            {
                CajaDeAhorro? caja = BuscarCajaDeAhorro(Id);
                Usuario? userAdd = contexto.usuarios.Where(usuario => usuario.dni == Dni).FirstOrDefault();
                if (userAdd == null)
                {
                    return 1;                //No se encontró usuario con este DNI en la lista de Usuarios del Banco
                }
                if (caja == null)
                {
                    return 2;                    //No se encontró la caja de ahorro con ese ID
                }

                if (caja.titulares.Contains(userAdd))
                {
                    return 3;                        //El usuario ya posee esta caja de ahorro en el sistema.
                }
                caja.titulares.Add(userAdd);
                userAdd.cajas.Add(caja);
                contexto.Update(caja);
                contexto.Update(userAdd);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 4;
            }
        }
        public int eliminarUsuarioDeCaja(int IdCaja, int Dni) // agregar persistencia
        {
            try
            {
                Usuario? titular = contexto.usuarios.Where(usuario => usuario.dni == Dni).FirstOrDefault();
                CajaDeAhorro? caja = BuscarCajaDeAhorro(IdCaja);
                if (titular == null)
                {
                    return 1;                //No se encontró usuario con este DNI en la lista de Usuarios del Banco
                }
                if (caja == null)
                {
                    return 2;                //No se encontró la caja de ahorro en la lista de cajas de ahorro
                }
                if (!caja.titulares.Contains(titular) || caja.titulares.Count < 2)
                {
                    return 3;                // El usuario no se pudo eliminar de la lista en el sistema
                }
                contexto.usuarios.Remove(titular);
                contexto.cajas.Remove(caja);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 4;
            }
        }
        //
        //TARJETAS
        //
        public bool altaTarjeta()
        {
            try
            {
                Random random = new Random();
                int nuevoNumero = random.Next(100000000, 999999999);
                while (contexto.tarjetas.Any(tarjeta => tarjeta.numero == nuevoNumero))
                {  // Mientras haya alguna tarjeta con ese numero se crea otro numero
                    nuevoNumero = random.Next(100000000, 999999999);
                    Debug.WriteLine("El número de tarjeta generado ya existe, creado uno nuevo...");
                }
                int nuevoCodigo = random.Next(100, 999); //Creo un codigo de tarjeta aleatorio
                Tarjeta nuevo = new Tarjeta(usuarioLogeado.id, nuevoNumero, nuevoCodigo, 20000, 0);
                nuevo.titular = usuarioLogeado;
                contexto.tarjetas.Add(nuevo);
                usuarioLogeado.tarjetas.Add(nuevo);
                contexto.Update(usuarioLogeado);
                contexto.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int bajaTarjeta(int IdTarjeta)
        {
            try
            {
                Tarjeta? tarjetaARemover = buscarTarjeta(IdTarjeta);
                if (tarjetaARemover == null)
                {
                    return 1;
                }
                if (tarjetaARemover.consumo != 0) // La condición para eliminar es que no tenga consumos sin pagar.
                {
                    return 2;
                }
                contexto.tarjetas.Remove(tarjetaARemover); //Borro la tarjeta de la lista de tarjetas del Banco
                tarjetaARemover.titular.tarjetas.Remove(tarjetaARemover);//Borro la tarjeta de la lista de tarjetas del usuario.
                contexto.Update(tarjetaARemover.titular);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 3;
            }
        }
        public int modificarTarjetaDeCredito(int Id, float limite) //Todavía sin aplicación en el programa
        {
            try
            {
                Tarjeta? TarjetaAModificar = buscarTarjeta(Id);
                if (TarjetaAModificar == null)
                {
                    return 1;
                }
                TarjetaAModificar.limite = limite;
                contexto.Update(TarjetaAModificar);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 2;
            }
        }
        //
        //PAGOS
        //
        public int nuevoPago(string Nombre, float Monto)
        {
            try
            {
                Pago nuevoPago = new Pago(usuarioLogeado, Nombre, Monto);
                contexto.pagos.Add(nuevoPago);
                usuarioLogeado.pagos.Add(nuevoPago);
                contexto.Update(usuarioLogeado);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int quitarPago(int IdpagoABorrar)
        {
            try
            {
                Pago pagoABorrar = buscarPago(IdpagoABorrar);
                if (pagoABorrar == null)
                {
                    return 1;
                }
                if (!pagoABorrar.pagado)
                {
                    return 2;
                }
                contexto.pagos.Remove(pagoABorrar);
                pagoABorrar.usuario.pagos.Remove(pagoABorrar);
                contexto.Update(pagoABorrar.usuario);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 3;
            }
        }

        public int modificarPago(int IdPagoAModificar)
        {
            try
            {
                Pago pagoAModificar = buscarPago(IdPagoAModificar);
                if (pagoAModificar == null)
                {
                    return 1;
                }
                pagoAModificar.pagado = true;
                contexto.Update(pagoAModificar);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 2;
            }
        }
        //
        //PLAZO FIJO
        //
        public int eliminarPlazoFijo(int idPlazoAEliminar)
        {
            try
            {
                PlazoFijo pFijo = buscarPlazoFijo(idPlazoAEliminar);
                if (pFijo == null)
                {
                    return 1;
                }
                if (!pFijo.pagado || DateTime.Now < pFijo.fechaFin.AddMonths(1))
                {
                    return 2;
                }
                pFijo.titular.pf.Remove(pFijo);
                contexto.Update(pFijo.titular);
                contexto.plazosFijos.Remove(pFijo);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 3;
            }
        }
        public int crearPlazoFijo(int IdCaja, float Monto)
        {
            try
            {
                if (Monto < 1000)
                {
                    return 1;
                }
                CajaDeAhorro? caja = BuscarCajaDeAhorro(IdCaja);
                if (caja == null)
                {
                    return 2;
                }
                if (caja.saldo < Monto)
                {
                    return 3;
                }
                caja.saldo -= Monto;
                this.altaMovimiento(caja, "Alta plazo fijo", Monto);
                PlazoFijo nuevoPlazoFijo = new PlazoFijo(usuarioLogeado, Monto, DateTime.Now.AddMonths(1), 90, caja.cbu);
                contexto.plazosFijos.Add(nuevoPlazoFijo);
                usuarioLogeado.pf.Add(nuevoPlazoFijo);
                contexto.Update(usuarioLogeado);
                contexto.SaveChanges();
                return 0;
            }
            catch
            {
                return 5;
            }
        }

        public void pagarPlazosFijos(PlazoFijo pFijo)// Hay que buscar la manera de pasarle una caja xq ya no tiene PF asociada
        {
            DateTime fechaIni = pFijo.fechaIni;
            DateTime fechaFin = pFijo.fechaFin;
            if (DateTime.Now.CompareTo(fechaFin) <= 0 && pFijo.pagado == false) //Esto no se si va a alreves
            {
                double cantDias = (fechaFin - fechaIni).TotalDays;
                float montoFinal = (pFijo.monto + pFijo.monto * (float)(90.0 / 365.0) * (float)cantDias);
                decimal bar = Convert.ToDecimal(montoFinal);
                montoFinal = (float)Math.Round(bar, 2);//redondeo a 2 decimales
                CajaDeAhorro caja = contexto.cajas.Where(c => c.cbu == pFijo.cbu).FirstOrDefault();
                caja.saldo += montoFinal;
                pFijo.pagado = true;
                contexto.Update(caja);
                contexto.Update(pFijo);
                contexto.SaveChanges();
                altaMovimiento(caja, "Pago plazo fijo", montoFinal);
            }
        }

        public int desbloquearUsuario(int IdUsuario)
        {
            Usuario? user = contexto.usuarios.Where(u => u.id == IdUsuario).FirstOrDefault(); ;
            if (user == null)
            {
                return 1; //el usuario no se encuentra
            }
            if (user.bloqueado == false)
            {
                return 2; //el usuario no esta bloqueado
            }
            user.bloqueado = false;    //se desbloque el usuario
            contexto.Update(user);
            contexto.SaveChanges();
            return 0;
        }
        //
        //
        //METODOS PARA MOSTRAR DATOS
        //
        //
        public List<Usuario> obtenerUsuarios()
        {
            return contexto.usuarios.ToList();
        }

        public int mostrarIntentosRestantes(int Dni)
        {
            int intentosFallidos = contexto.usuarios.Where(u => u.dni == Dni).FirstOrDefault().intentosFallidos;
            return intentosFallidos;
        }
        public bool esAdmin()
        {
            return usuarioLogeado.isAdmin;
        }
        public List<CajaDeAhorro> obtenerTodasLasCajasDeAhorro()
        {
            return contexto.cajas.ToList();
        }
        public List<CajaDeAhorro> obtenerCajaDeAhorro()
        {
            return usuarioLogeado.cajas.ToList();
        }
        public CajaDeAhorro BuscarCajaDeAhorro(int Id)
        {
            return contexto.cajas.Where(caja => caja.id == Id).FirstOrDefault();
        }
        public CajaDeAhorro BuscarCajaDeAhorroPorCbu(int Cbu)
        {
            return contexto.cajas.Where(caja => caja.cbu == Cbu).FirstOrDefault();
        }
        public List<Movimiento> obtenerMovimientos(int idCaja) //Fijarse si está bien
        {
            return contexto.movimientos.Where(m => m.id_Caja == idCaja).ToList();
        }
        public List<Pago> obtenerTodosLosPagos()
        {
            return contexto.pagos.ToList();
        }
        public List<Pago> obtenerPagos()
        {
            return usuarioLogeado.pagos.ToList();
        }
        public Pago buscarPago(int idPago)
        {
            return contexto.pagos.Where(pago => pago.id == idPago).FirstOrDefault();
        }
        public List<PlazoFijo> obtenerTodosLosPlazosFijos()
        {
            return contexto.plazosFijos.ToList();
        }
        public List<PlazoFijo> obtenerPlzFijo()
        {
            return usuarioLogeado.pf.ToList();
        }
        public PlazoFijo buscarPlazoFijo(int IdPF)
        {
            return contexto.plazosFijos.Where(pf => pf.id == IdPF).FirstOrDefault();
        }
        public List<Tarjeta> obtenerTodasLasTarjetas()
        {
            return contexto.tarjetas.ToList();
        }
        public List<Tarjeta> obtenerTarjetas()
        {
            return usuarioLogeado.tarjetas.ToList();
        }
        public Tarjeta buscarTarjeta(int Id)
        {
            return contexto.tarjetas.Where(tarjeta => tarjeta.id == Id).FirstOrDefault();
        }
        public string mostrarUsuario()
        {
            return usuarioLogeado.nombre + " " + usuarioLogeado.apellido;
        }
        //
        //
        //METODOS ACCIONES DEL USUARIO
        //
        //
        public int iniciarSesion(int Dni, string Pass)
        {
            Usuario user = contexto.usuarios.Where(u => u.dni == Dni).FirstOrDefault();
            if (user == null)
            {
                return 1;                // No se encontró el usuario
            }
            if (user.bloqueado)
            {
                return 2;                // Usuario bloqueado
            }
            if (user.password != Pass)
            {
                user.intentosFallidos++;
                contexto.Update(user);
                contexto.SaveChanges();
                if (user.intentosFallidos >= 3) //Si alcanza los 3 intentos se bloquea la cuenta
                {
                    user.bloqueado = true;
                    contexto.Update(user);
                    contexto.SaveChanges();
                    return 3;                    //Numero de intentos excedidos
                }
                else
                {
                    return 4;
                    // intentos restantes
                }
            }
            this.usuarioLogeado = user;
            return 0;
        }

        public int depositar(int IdCaja, float Monto) //Probar si se guarda 2 veces
        {
            CajaDeAhorro cajaDestino = BuscarCajaDeAhorro(IdCaja);
            if (cajaDestino == null)
            {
                return 1;  //Si no se encuentra la Caja    
            }
            cajaDestino.saldo += Monto;
            contexto.Update(cajaDestino);
            this.altaMovimiento(cajaDestino, "Deposito", Monto);
            contexto.SaveChanges();
            return 0;
        }

        public int retirar(int IdCaja, float Monto)
        {
            CajaDeAhorro cajaSeleccionada = BuscarCajaDeAhorro(IdCaja);
            if (cajaSeleccionada == null)
            {
                return 1; //No se encontró la caja
            }
            if (cajaSeleccionada.saldo < Monto)
            {
                return 2; //El saldo es menor al monto que se desea retirar
            }
            cajaSeleccionada.saldo -= Monto;
            contexto.Update(cajaSeleccionada);
            this.altaMovimiento(cajaSeleccionada, "Retiro", Monto);
            contexto.SaveChanges();
            return 0;
        }
        public int transferir(int IdOrigen, int CbuDestino, float Monto)
        {
            try
            {
                CajaDeAhorro cajaOrigen = BuscarCajaDeAhorro(IdOrigen);
                CajaDeAhorro cajaDestino = contexto.cajas.Where(caja => caja.cbu == CbuDestino).FirstOrDefault();
                if (cajaDestino == null)
                {
                    return 1;
                }
                if (cajaOrigen.saldo < Monto)
                {
                    return 2;
                }
                cajaOrigen.saldo -= Monto;
                this.altaMovimiento(cajaOrigen, "Transferencia realizada", Monto);
                cajaDestino.saldo += Monto;
                this.altaMovimiento(cajaDestino, "Transferencia recibida", Monto);
                return 0;
            }
            catch (Exception ex)
            {
                return 3;
            }

        }
        public Movimiento buscarMovimiento(int Id)
        {
            return contexto.movimientos.Where(movimiento => movimiento.id == Id).FirstOrDefault();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, DateTime Fecha, float Monto, string Detalle)
        {
            return contexto.movimientos.Where(movimiento => movimiento.monto == Monto && movimiento.fecha.Date == Fecha.Date && movimiento.detalle == Detalle && movimiento.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, DateTime Fecha) //Fecha por Detalle - Eliminar CajaOrigen
        {
            return contexto.movimientos.Where(movimiento => movimiento.fecha.Date == Fecha.Date && movimiento.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, float Monto) //Monto por Detalle - Eliminar CajaOrigen
        {
            return contexto.movimientos.Where(movimiento => movimiento.monto == Monto && movimiento.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, string Detalle)
        {
            return contexto.movimientos.Where(m => m.detalle == Detalle && m.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, string Detalle, DateTime Fecha)
        {
            return contexto.movimientos.Where(m => m.detalle == Detalle && m.fecha.Date == Fecha.Date && m.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, string Detalle, float Monto)
        {
            return contexto.movimientos.Where(m => m.detalle == Detalle && m.monto == Monto && m.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, DateTime Fecha, float Monto)
        {
            return contexto.movimientos.Where(m => m.monto == Monto && m.fecha.Date == Fecha.Date && m.id_Caja == IdCaja).ToList();
        }
        public int pagarTarjeta(int Id, int Cbu)
        {
            CajaDeAhorro? caja = BuscarCajaDeAhorroPorCbu(Cbu);
            Tarjeta? tarjeta = buscarTarjeta(Id);

            if (tarjeta == null)
            {
                return 1; //no se ecnontro tarjeta
            }
            if (caja == null)
            {
                return 2; //no se encontro caja
            }

            if (caja.saldo < tarjeta.consumo)
            {
                return 3; //no tiene saldo suficiente
            }
            caja.saldo -= tarjeta.consumo;
            this.altaMovimiento(caja, "Pago de Tarjeta " + tarjeta.numero, tarjeta.consumo);
            tarjeta.consumo = 0;
            contexto.Update(tarjeta);
            contexto.Update(caja);
            contexto.SaveChanges();
            return 0;
        }
        public int pagarPago(int idPago, int numero)
        {
            Pago pago = buscarPago(idPago);
            CajaDeAhorro caja = BuscarCajaDeAhorroPorCbu(numero);
            if (pago == null)
            {
                return 1; //No se encuentra el pago
            }
            if (pago.pagado)
            {
                return 2; //ya esta pagado
            }
            if (caja != null)
            {
                if (caja.saldo < pago.monto)
                {
                    return 3; //No se encuantra caja
                }
                caja.saldo -= pago.monto;
                this.modificarPago(idPago);
                this.altaMovimiento(caja, "Pago de " + pago.nombre, pago.monto);
                pago.metodo = "Caja de ahorro";
                contexto.Update(caja);
                contexto.Update(pago);
                contexto.SaveChanges();

                return 0;
            }
            Tarjeta? tarjeta = contexto.tarjetas.Where(tarjeta => tarjeta.numero == numero).FirstOrDefault();
            if (tarjeta == null)
            {
                return 4; //No se encuentra tarjeta
            }
            if ((tarjeta.limite - tarjeta.consumo) < pago.monto)
            {
                return 3; //No tiene saldo
            }
            tarjeta.consumo += pago.monto;
            this.modificarPago(idPago);
            pago.metodo = "Tarjeta";
            contexto.Update(tarjeta);
            contexto.Update(pago);
            contexto.SaveChanges();
            return 0;
        }
    }
}

