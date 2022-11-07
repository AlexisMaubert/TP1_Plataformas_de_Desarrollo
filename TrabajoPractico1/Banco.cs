﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
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
        private int id { get; set; }
        private List<Usuario> usuarios;
        private List<CajaDeAhorro> cajas;
        private List<PlazoFijo> pfs;
        private List<Tarjeta> tarjetas;
        private List<Pago> pagos;
        private List<Movimiento> movimientos;
        private Usuario usuarioLogeado;
        private List<UsuarioCaja> usuarioCaja; //lista de many to many caja
        private DAL DB;

        public Banco()
        {
            //this.id = 1;
            this.usuarios = new List<Usuario>();
            this.cajas = new List<CajaDeAhorro>();
            this.pfs = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
            this.pagos = new List<Pago>();
            this.movimientos = new List<Movimiento>();
            this.usuarioCaja = new List<UsuarioCaja>(); //lista UsuarioCaja
            DB = new DAL();
            inicializarAtributos();
            //revisarPlazosFijos();
        }
        //
        //PERSISTENCIA.
        //
        public void inicializarAtributos()
        {
            usuarios = DB.inicializarUsuarios();
            tarjetas = DB.inicializarTarjetas();
            movimientos = DB.inicializarMovimientos();
            pagos = DB.inicializarPagos();
            cajas = DB.inicializarCajas();
            usuarioCaja = DB.inicializarUsuarioCaja();
            pfs = DB.inicializarPlazoFijo();

            foreach (Tarjeta tarjeta in tarjetas.ToList())
            {
                Usuario? user = usuarios.Find(usuario => usuario.id == tarjeta.id_usuario);
                Tarjeta? card = tarjetas.Find(c => c.id == tarjeta.id);
                if (user != null && card != null)
                {
                    user.tarjetas.Add(card);
                    card.titular = user;
                }
            }
            foreach (Movimiento mov in movimientos.ToList())
            {
                CajaDeAhorro? caja = BuscarCajaDeAhorro(mov.id_Caja);
                Movimiento? movimiento = buscarMovimiento(mov.id);
                if (caja != null && movimiento != null)
                {
                    caja.movimientos.Add(movimiento);
                    movimiento.caja = caja;
                }
            }
            foreach (Pago pago in pagos.ToList())
            {
                Pago? p = buscarPago(pago.id);
                Usuario? user = usuarios.Find(usuario => usuario.id == pago.id_usuario);
                if (p != null && user != null)
                {
                    user.pagos.Add(p);
                    p.user = user;
                }
            }
            foreach (UsuarioCaja uc in usuarioCaja)
            {
                Usuario? usuarioAux = usuarios.Find(usuario => usuario.id == uc.idUsuario);
                List<CajaDeAhorro> cajasAux = cajas.FindAll(caja => caja.id == uc.idCaja);
                if (usuarioAux != null)
                {
                    foreach (CajaDeAhorro cajaAux in cajasAux)
                    {
                        usuarioAux.cajas.Add(cajaAux);
                        cajaAux.titulares.Add(usuarioAux);
                    }
                }
            }
            foreach (PlazoFijo pf in pfs.ToList())
            {
                PlazoFijo? plazoFijo = pfs.Find(pfaux => pfaux.id == pf.id);
                Usuario? user = usuarios.Find(u => u.id == pf.id_usuario);
                CajaDeAhorro? caja = cajas.Find(c => c.id == pf.id_caja);
                if (plazoFijo != null && user != null && caja != null)
                {
                    pagarPlazosFijos(plazoFijo);
                    user.pf.Add(plazoFijo);
                    plazoFijo.titular = user;
                }
            }
        }
        //
        //MOVIMIENTOS
        //
        public bool altaMovimiento(CajaDeAhorro Caja, string Detalle, float Monto)
        {
            try
            {
                int idNuevoMovimiento = DB.agregarMovimiento(Detalle, Monto, Caja.id);
                if (idNuevoMovimiento == -1)
                {
                    MessageBox.Show(String.Format("No se pudo crear el movimiento: '{0}' de valor: {1} en la caja de id: {2} (Nivel DB)", Detalle, Monto, Caja.id), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                };
                Movimiento movimientoNuevo = new Movimiento(Caja, Detalle, Monto);
                this.movimientos.Add(movimientoNuevo);
                Caja.movimientos.Add(movimientoNuevo);
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
        public bool altaUsuario(string Nombre, string Apellido, int Dni, string Mail, string Password)
        {
            bool esValido = true;
            foreach (Usuario u in usuarios) //comprobación para que no me agreguen usuarios con DNI duplicado
            {
                if (u.dni == Dni)
                {
                    esValido = false;
                }
            }
            if (esValido)
            {
                int idNuevoUsuario;
                idNuevoUsuario = DB.agregarUsuario(Nombre, Apellido, Dni, Mail, Password);
                if (idNuevoUsuario != -1)
                {
                    //Ahora sí lo agrego en la lista
                    Usuario nuevo = new Usuario(idNuevoUsuario, Dni, Nombre, Apellido, Mail, Password);
                    usuarios.Add(nuevo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool bajaUsuario(int Id)
        {
            try
            {
                Usuario? usuarioARemover = buscarUsuario(Id);
                if (usuarioARemover != null)
                {
                    this.usuarios.Remove(usuarioARemover);
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

        public bool modificarUsuario(int id, int dni, string mail, string pass) // agregar persistencia
        {
            try
            {
                Usuario? usuarioAModificar = buscarUsuario(id);
                if (usuarioAModificar != null)
                {
                    usuarioAModificar.mail = mail;
                    usuarioAModificar.password = pass;
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
            while (this.cajas.Any(caja => caja.cbu == nuevoCbu))
            {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                nuevoCbu = random.Next(100000000, 999999999);
                Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
            }
            int idNuevaCaja;
            idNuevaCaja = DB.agregarCaja(nuevoCbu);
            if (idNuevaCaja == -1)
            {
                return 1;
            }
            //Ahora sí lo agrego en la lista
            CajaDeAhorro nuevo = new CajaDeAhorro(idNuevaCaja, nuevoCbu);
            cajas.Add(nuevo);
            usuarioLogeado.cajas.Add(nuevo);
            nuevo.titulares.Add(usuarioLogeado);
            int idNuevoUsuarioCaja;
            idNuevoUsuarioCaja = DB.agregarUsuarioACaja(idNuevaCaja, usuarioLogeado.id);
            if (idNuevoUsuarioCaja == -1)
            {
                return 2;
            }
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
                foreach (PlazoFijo pf in usuarioLogeado.pf.FindAll(pfaux => pfaux.id_caja == IdCaja)) //Itero entre los plazos fijos del usuario logeado
                {
                    usuarioLogeado.pf.Remove(pf);
                }
                foreach (Usuario titular in cajaARemover.titulares) //Itero entre los titulares de la caja de ahorro
                {
                    foreach (PlazoFijo pf in titular.pf.FindAll(pfaux => pfaux.id_caja == IdCaja)) //Itero entre los plazos fijos del titular
                    {
                        titular.pf.Remove(pf);
                    }
                    titular.cajas.Remove(cajaARemover);  //Saco la caja de ahorro de los titulares.
                }
                if (DB.eliminarCaja(IdCaja) == 0)
                {
                    return 3;
                }
                this.cajas.Remove(cajaARemover); //Saco la caja de ahorro del banco
                return 0;
            }
            catch
            {
                return 4;
            }
        }

        public int agregarUsuarioACaja(int Id, int Dni) //funcion void q hace algo
        {
            try //validar-->hacer validaciones correspondientes
            {
                CajaDeAhorro? caja = BuscarCajaDeAhorro(Id);
                Usuario? userAdd = this.usuarios.Find(usuario => usuario.dni == Dni);
                if (userAdd == null)
                {
                    return 1;                //No se encontró usuario con este DNI en la lista de Usuarios del Banco
                }
                if (caja == null)
                {
                    return 2;                    //No se encontró la caja de ahorro con ese ID
                }
                if (DB.usuarioYaEstaEnCaja(caja.id, userAdd.id))
                {
                    return 3;                //El usuario ya posee esta caja de ahorro en la base de datos.
                }

                //Inicialice y declare en el mismo momento.
                int idNuevoUsuarioCaja = DB.agregarUsuarioACaja(caja.id, userAdd.id); //inserc a mano
                if (idNuevoUsuarioCaja == -1)
                {
                    return 4;                    //No se pudo agregar la relacion
                }
                if (caja.titulares.Contains(userAdd))
                {
                    return 5;                        //El usuario ya posee esta caja de ahorro en el sistema.
                }
                caja.titulares.Add(userAdd);
                userAdd.cajas.Add(caja);
                return 0;
            }
            catch
            {
                return 6;  //RETORNAR 6??? HAY QUE ATRAPAR EXCEPCION.
            }
        }

        //MAGALI --> CAMBIAR ESE METODO DE ARRIBA POR ESTO Y CAMBIAR LOS DEMAS SIGUIENDO ESTA MISMA LOGICA: 
        //POR OTRO LADO LOS " # " SON LAS CLASES APARTES QUE CREARIAMOS ESOS METODOS EN ESAS CLASES Y LAS LLAMAMOS ACA.
        /*public void agregarUsuarioACaja(int id, int dni) {
        try {
        CajaDeAhorro? caja = BuscarCajaDeAhorro(Id);
        Usuario? userAdd = this.usuarios.Find(usuario => usuario.dni == Dni);

        validarUsuarioCaja(caja, userAdd);
        agregarUsuario(userAdd);
        agregarCaja(caja);
        } catch (UsuarioNoEncontradoException e) {
        throw new UsuarioNoEncontradoException("Usuario no encontrado");
        } catch (CajaNoEncontradoException e) {
        throw new CajaNoEncontradoException("Caja no encontrado");
        } catch (Exception e) {
        writeline("Ocurrio un error inesperado", e)
        }
        }

        public void validarUsuarioCaja(caja, userAdd) {
        if (DB.usuarioYaEstaEnCaja(caja.id, userAdd.id))
        {
        throw new UsuarioExistenteEnCajaException("Usuario ya existe en caja");
        }
        int idNuevoUsuarioCaja = DB.agregarUsuarioACaja(caja.id, userAdd.id); //inserc a mano
        if (idNuevoUsuarioCaja == -1)
        {
        throw new RuntimeException("No se pudo agregar la relacion usuario caja");                  //No se pudo agregar la relacion
        }
        if (caja.titulares.Contains(userAdd))
        {
        throw new UsuarioExistenteEnTitularesCajaException("Usuario ya existe en caja");                 //El usuario ya posee esta caja de ahorro en el sistema.
        }
        }

        #CajaDeAhorro
        public void agregarUsuario(userAdd) {
        titulares.Add(userAdd);
        }

        #Usuario

        public void agregarCaja(caja) {
        cajas.Add(caja);
        }*/
        public int eliminarUsuarioDeCaja(int IdCaja, int Dni) // agregar persistencia
        {
            try
            {
                Usuario? titular = this.usuarios.Find(usuario => usuario.dni == Dni);
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
                if (DB.eliminarUsuarioDeCaja(caja.id, titular.id) == 0)
                {
                    return 4;                // El usuario no se pudo eliminar de la base de datos
                }
                caja.titulares.Remove(titular);
                titular.cajas.Remove(caja);
                return 0;
            }
            catch
            {
                return 5;
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
                while (this.tarjetas.Any(tarjeta => tarjeta.numero == nuevoNumero))
                {  // Mientras haya alguna tarjeta con ese numero se crea otro numero
                    nuevoNumero = random.Next(100000000, 999999999);
                    Debug.WriteLine("El número de tarjeta generado ya existe, creado uno nuevo...");
                }
                int nuevoCodigo = random.Next(100, 999); //Creo un codigo de tarjeta aleatorio
                int idNuevaTarjeta = DB.agregarTarjeta(usuarioLogeado.id, nuevoNumero, nuevoCodigo, 20000, 0);
                if (idNuevaTarjeta != -1)
                {
                    Tarjeta nuevo = new Tarjeta(idNuevaTarjeta, usuarioLogeado.id, nuevoNumero, nuevoCodigo, 20000, 0);
                    nuevo.titular = usuarioLogeado;
                    tarjetas.Add(nuevo);
                    usuarioLogeado.tarjetas.Add(nuevo);
                    return true;
                }
                return false;
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
                if (DB.eliminarTarjeta(IdTarjeta) == 0)
                {
                    return 3;
                }
                this.tarjetas.Remove(tarjetaARemover); //Borro la tarjeta de la lista de tarjetas del Banco
                tarjetaARemover.titular.tarjetas.Remove(tarjetaARemover);//Borro la tarjeta de la lista de tarjetas del usuario.
                return 0;
            }
            catch
            {
                return 4;
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
                int idNuevoPago = DB.agregarPago(usuarioLogeado.id, Nombre, Monto);
                if (idNuevoPago == -1)
                {
                    return 1;
                }
                Pago nuevoPago = new Pago(idNuevoPago, usuarioLogeado, Nombre, Monto);
                this.pagos.Add(nuevoPago);
                usuarioLogeado.pagos.Add(nuevoPago);
                return 0;
            }
            catch
            {
                return 2;
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
                if (DB.elimnarPago(IdpagoABorrar) == 0)
                {
                    return 2;
                }
                if (pagoABorrar.pagado)
                {
                    this.pagos.Remove(pagoABorrar);
                    pagoABorrar.user.pagos.Remove(pagoABorrar);
                    return 0;
                }
                return 3;
            }
            catch
            {
                return 4;
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
                if (DB.eliminarPlazoFijo(idPlazoAEliminar) == 0)
                {
                    return 3;
                }
                pFijo.titular.pf.Remove(pFijo);
                this.pfs.Remove(pFijo);
                return 0;
            }
            catch
            {
                return 4;
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
                int idNuevoPlazoFijo;
                idNuevoPlazoFijo = DB.agregarPlazoFijo(usuarioLogeado.id, Monto, DateTime.Now.AddMonths(1), 90, caja.id);
                if (idNuevoPlazoFijo == -1)
                {
                    return 4;
                }
                if (DB.retirarDeCaja(IdCaja, Monto) <= 0)
                {
                    return 5;
                };
                caja.saldo -= Monto;
                this.altaMovimiento(caja, "Alta plazo fijo", Monto);
                PlazoFijo nuevoPlazoFijo = new PlazoFijo(usuarioLogeado, Monto, DateTime.Now.AddMonths(1), 90, IdCaja);
                this.pfs.Add(nuevoPlazoFijo);
                usuarioLogeado.pf.Add(nuevoPlazoFijo);
                return 0;
            }
            catch
            {
                return 5;
            }
        }
        public void pagarPlazosFijos(PlazoFijo pFijo)
        {
            DateTime fechaIni = pFijo.fechaIni;
            DateTime fechaFin = pFijo.fechaFin;
            if (DateTime.Now.CompareTo(fechaFin) <= 0 && pFijo.pagado == false) //Esto no se si va a alreves
            {
                double cantDias = (fechaFin - fechaIni).TotalDays;
                float montoFinal = (pFijo.monto + pFijo.monto * (float)(90.0 / 365.0) * (float)cantDias);
                decimal bar = Convert.ToDecimal(montoFinal);
                montoFinal = (float)Math.Round(bar, 2);//redondeo a 2 decimales
                CajaDeAhorro caja = BuscarCajaDeAhorro(pFijo.id_caja);
                caja.saldo += montoFinal;
                pFijo.pagado = true;
                DB.pagarPlazoFijo(pFijo.id, montoFinal);
                DB.depositarEnCaja(pFijo.id_caja, montoFinal);
                altaMovimiento(caja, "Pago plazo fijo", montoFinal);
            }
        }
        public int desbloquearUsuario(int IdUsuario)
        {
            Usuario? user = buscarUsuario(IdUsuario);
            if(user == null)
            {
                return 1;
            }
            if(user.bloqueado == false)
            {
                return 2;
            }
            if(DB.desbloquearUsuario(IdUsuario) == 0)
            {
                return 3;
            }
            user.bloqueado = false;
            return 0;
        }
        //
        //METODOS PARA MOSTRAR DATOS
        //
        public List<Usuario> obtenerUsuarios()
        {
            return usuarios.ToList();
        }
        public Usuario buscarUsuario(int Id)
        {
            return usuarios.Find(usuario => usuario.id == Id);
        }
        public int mostrarIntentosRestantes(int Dni)
        {
            int intentosFallidos = usuarios.Find(u => u.dni == Dni).intentosFallidos;
            return intentosFallidos;
        }
        public bool esAdmin()
        {
            return usuarioLogeado.isAdmin;
        }
        public List<CajaDeAhorro> obtenerTodasLasCajasDeAhorro() { 
        
            return cajas.ToList();
        }
        public List<CajaDeAhorro> obtenerCajaDeAhorro()
        {
            return usuarioLogeado.cajas.ToList();
        }
        public CajaDeAhorro BuscarCajaDeAhorro(int Id)
        {
            return this.cajas.Find(caja => caja.id == Id);
        }
        public CajaDeAhorro BuscarCajaDeAhorroPorCbu(int Cbu)
        {
            return this.cajas.Find(caja => caja.cbu == Cbu);
        }
        public List<Movimiento> obtenerMovimientos(int idCaja)
        {
            return movimientos.FindAll(m => m.id_Caja == idCaja);
        }
        public List<Pago> obtenerTodosLosPagos()
        {
            return pagos.ToList();
        }
        public List<Pago> obtenerPagos()
        {
            return usuarioLogeado.pagos.ToList();
        }
        public Pago buscarPago(int idPago)
        {
            return this.pagos.Find(pago => pago.id == idPago);
        }
        public List<PlazoFijo> obtenerTodosLosPlazosFijos()
        {
            return pfs.ToList();
        }
        public List<PlazoFijo> obtenerPlzFijo()
        {
            return usuarioLogeado.pf.ToList();
        }
        public PlazoFijo buscarPlazoFijo(int IdPF)
        {
            return this.pfs.Find(pf => pf.id == IdPF);
        }
        public List<Tarjeta> obtenerTodasLasTarjetas()
        {
            return tarjetas.ToList();
        }
        public List<Tarjeta> obtenerTarjetas()
        {
            return usuarioLogeado.tarjetas.ToList();
        }
        public Tarjeta buscarTarjeta(int Id)
        {
            return this.tarjetas.Find(tarjeta => tarjeta.id == Id);
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
            Usuario user = this.usuarios.Find(usuario => usuario.dni == Dni);
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
                if (user.intentosFallidos >= 3) //Si alcanza los 3 intentos se bloquea la cuenta
                {
                    user.bloqueado = true;
                    DB.bloquearUsuario(user.id);
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

        public int depositar(int IdCaja, float Monto)
        {
            CajaDeAhorro cajaDestino = BuscarCajaDeAhorro(IdCaja);
            if(cajaDestino == null)
            {
                return 1;
            }
            if (DB.depositarEnCaja(IdCaja, Monto) <= 0)
            {
                return 2;
            }
            cajaDestino.saldo += Monto;
            this.altaMovimiento(cajaDestino, "Deposito", Monto);
            return 0;
        }
        public int retirar(int IdCaja, float Monto)
        {
            CajaDeAhorro cajaSeleccionada = BuscarCajaDeAhorro(IdCaja);
            if(cajaSeleccionada == null)
            {
                return 1;
            }
            if (cajaSeleccionada.saldo < Monto)
            {
                return 2;
            }
            if (DB.retirarDeCaja(IdCaja, Monto) <= 0)
            {
                return 3;
            }
            cajaSeleccionada.saldo -= Monto;
            this.altaMovimiento(cajaSeleccionada, "Retiro", Monto);
            return 0;
        }
        public int transferir(int IdOrigen, int CbuDestino, float Monto)
        {
            CajaDeAhorro cajaOrigen = BuscarCajaDeAhorro(IdOrigen);
            CajaDeAhorro cajaDestino = this.cajas.Find(caja => caja.cbu == CbuDestino);
            if (cajaDestino == null)
            {
                return 1;
            }
            if (cajaOrigen.saldo < Monto)
            {
                return 2;
            }
            if (DB.retirarDeCaja(IdOrigen, Monto) == 0)
            {
                return 3;
            }
            if (DB.depositarEnCaja(cajaDestino.id, Monto) == 0)
            {
                return 4;
            }
            cajaOrigen.saldo -= Monto;
            this.altaMovimiento(cajaOrigen, "Transferencia realizada", Monto);
            cajaDestino.saldo += Monto;
            this.altaMovimiento(cajaDestino, "Transferencia recibida", Monto);
            return 0;
        }
        public Movimiento buscarMovimiento(int Id)
        {
            return movimientos.Find(movimiento => movimiento.id == Id);
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, DateTime Fecha, float Monto, string Detalle) 
        {
            return movimientos.FindAll(movimiento => movimiento.monto == Monto && movimiento.fecha.Date == Fecha.Date && movimiento.detalle == Detalle && movimiento.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, DateTime Fecha) //Fecha por Detalle - Eliminar CajaOrigen
        {
            return movimientos.FindAll(movimiento => movimiento.fecha.Date == Fecha.Date && movimiento.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, float Monto) //Monto por Detalle - Eliminar CajaOrigen
        {
            return movimientos.FindAll(movimiento => movimiento.monto == Monto && movimiento.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, string Detalle) 
        {
            return movimientos.FindAll(m => m.detalle == Detalle && m.id_Caja == IdCaja).ToList();
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, string Detalle, DateTime Fecha)
        {
            return movimientos.FindAll(m => m.detalle == Detalle && m.fecha.Date == Fecha.Date && m.id_Caja == IdCaja);
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, string Detalle, float Monto)
        {
            return movimientos.FindAll(m => m.detalle == Detalle && m.monto == Monto && m.id_Caja == IdCaja);
        }
        public List<Movimiento> buscarMovimiento(int IdCaja, DateTime Fecha, float Monto)
        {
            return movimientos.FindAll(m => m.monto == Monto && m.fecha.Date == Fecha.Date && m.id_Caja == IdCaja);
        }
        public int pagarTarjeta(int Id, int Cbu)
        {
            CajaDeAhorro? caja = BuscarCajaDeAhorroPorCbu(Cbu);
            Tarjeta? tarjeta = buscarTarjeta(Id);

            if (tarjeta == null)
            {
                return 1;
            }
            if (caja == null)
            {
                return 2;
            }

            if (caja.saldo < tarjeta.consumo)
            {
                return 3;
            }
            DB.pagarTarjeta(tarjeta.id);
            DB.retirarDeCaja(caja.id, tarjeta.consumo);
            caja.saldo -= tarjeta.consumo;
            this.altaMovimiento(caja, "Pago de Tarjeta " + tarjeta.numero, tarjeta.consumo);
            tarjeta.consumo = 0;
            return 0;
        }
        public int pagarPago(int idPago, int numero)
        {
            Pago pago = buscarPago(idPago);
            CajaDeAhorro caja = BuscarCajaDeAhorroPorCbu(numero);
            if (pago == null)
            {
                return 1;
            }
            if (pago.pagado)
            {
                return 2;
            }
            if (caja != null)
            {
                if (caja.saldo < pago.monto)
                {
                    return 3;
                }
                DB.pagarPago(idPago);
                DB.retirarDeCaja(caja.id, pago.monto);
                caja.saldo -= pago.monto;
                this.modificarPago(idPago);
                this.altaMovimiento(caja, "Pago de " + pago.nombre, pago.monto);
                pago.metodo = "Caja de ahorro";
                return 0;
            }
            Tarjeta? tarjeta = this.tarjetas.Find(tarjeta => tarjeta.numero == numero);
            if (tarjeta == null)
            {
                return 4;
            }
            if ((tarjeta.limite - tarjeta.consumo) < pago.monto)
            {
                return 3;
            }
            DB.pagarPago(idPago);
            DB.agregarConsumoATarjeta(tarjeta.id, pago.monto);
            tarjeta.consumo += pago.monto;
            this.modificarPago(idPago);
            pago.metodo = "Tarjeta";
            return 0;
        }
    }
}

