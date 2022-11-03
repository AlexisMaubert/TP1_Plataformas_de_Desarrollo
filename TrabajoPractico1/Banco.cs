using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        public void revisarPlazosFijos()
        {
            foreach (PlazoFijo pf in obtenerPlzFijo())
            {
                if (DateTime.Now == pf.fechaFin)
                {
                    int cantDias = DateTime.Now.CompareTo(pf.fechaIni);
                    float montoFinal = pf.monto * (90 / 365) * cantDias;
                    pf.LAcaja.saldo = pf.LAcaja.saldo + montoFinal;
                }
            }
        }
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
                    tarjetas.Add(card);
                    card.titular = user;
                }
            }
            foreach (Movimiento mov in movimientos.ToList())
            {
                CajaDeAhorro? caja = BuscarCajaDeAhorro(mov.id_Caja);
                Movimiento? movimiento = buscarMovimiento(mov.id);
                if (caja != null && movimiento != null)
                {
                    movimientos.Add(movimiento);
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
                    pagos.Add(p);
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
                        cajas.Add(cajaAux);
                    }
                }
            }
            foreach (PlazoFijo pf in pfs.ToList())
            {
                PlazoFijo? plazoFijo = pfs.Find(pfaux => pfaux.id == pf.id);
                Usuario? user = usuarios.Find(u => u.id == pf.id_usuario);
                CajaDeAhorro? caja = cajas.Find(c => c.id == pf.id_banco);
                if (plazoFijo != null && user != null && caja != null)
                {
                    user.pf.Add(plazoFijo);
                    plazoFijo.titular = user;
                    plazoFijo.LAcaja = caja;
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
        public int bajaCaja(int IdCaja) // agregar persistencia
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
                if (DB.eliminarCaja(IdCaja) == 0)
                {
                    return 3;
                }
                this.cajas.Remove(cajaARemover); //Saco la caja de ahorro del banco
                foreach (Usuario titular in cajaARemover.titulares) //Itero entre los titulares de la caja de ahorro
                {
                    titular.cajas.Remove(cajaARemover);  //Saco la caja de ahorro de los titulares.
                }
                return 0;
            }
            catch
            {
                return 4;
            }
        }

        public int agregarUsuarioACaja(int Id, int Dni)
        {
            try
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
                int idNuevoUsuarioCaja;
                idNuevoUsuarioCaja = DB.agregarUsuarioACaja(caja.id, userAdd.id);
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
                return 6;
            }
        }
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
                this.tarjetas.Remove(tarjetaARemover); //Borro la tarjeta de la lista de tarjetas del Banco
                tarjetaARemover.titular.tarjetas.Remove(tarjetaARemover);//Borro la tarjeta de la lista de tarjetas del usuario.
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
                if (pagoABorrar.pagado)
                {
                    this.pagos.Remove(pagoABorrar);
                    pagoABorrar.user.pagos.Remove(pagoABorrar);
                    return 0;
                }
                return 2;
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

        public bool agregarPlazoFijo(PlazoFijo NuevoPlazoFijo)
        {
            try
            {
                this.pfs.Add(NuevoPlazoFijo);
                usuarioLogeado.pf.Add(NuevoPlazoFijo);
                return true;
            }
            catch
            {
                return false;
            }
        }
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
                this.pfs.Remove(pFijo);
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
                int idNuevoPlazoFijo;
                idNuevoPlazoFijo = DB.agregarPlazoFijo(usuarioLogeado.id, Monto, DateTime.Now.AddMonths(1), 90, caja.id);
                if (idNuevoPlazoFijo == -1)
                {
                    return 4;
                }
                PlazoFijo nuevoPlazoFijo = new PlazoFijo(usuarioLogeado, Monto, DateTime.Now.AddMonths(1), 90);
                nuevoPlazoFijo.LAcaja = caja;
                this.agregarPlazoFijo(nuevoPlazoFijo);
                return 0;
            }
            catch
            {
                return 5;
            }
        }
        //
        //METODOS PARA MOSTRAR DATOS
        //
        public Usuario buscarUsuario(int Id)
        {
            return usuarios.Find(usuario => usuario.id == Id);
        }
        public int mostrarIntentosRestantes(int Dni)
        {
            int intentosFallidos = usuarios.Find(u => u.dni == Dni).intentosFallidos;
            return intentosFallidos;
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
            foreach (CajaDeAhorro caja in usuarioLogeado.cajas)
            {
                if (caja.id == idCaja)
                {
                    return caja.movimientos.ToList();
                }
            }
            return null;
        }
        public List<Pago> obtenerPagos()
        {
            return usuarioLogeado.pagos.ToList();
        }
        public Pago buscarPago(int idPago)
        {
            return this.pagos.Find(pago => pago.id == idPago);
        }

        public List<PlazoFijo> obtenerPlzFijo()
        {
            return usuarioLogeado.pf.ToList();
        }
        public PlazoFijo buscarPlazoFijo(int IdPF)
        {
            return this.pfs.Find(pf => pf.id == IdPF);
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

        public bool depositar(int IdCaja, float Monto)
        {
            CajaDeAhorro cajaDestino = BuscarCajaDeAhorro(IdCaja);
            if (DB.depositarEnCaja(IdCaja, Monto) <= 0)
            {
                MessageBox.Show(String.Format("No se pudo depositar el monto: {0} en la caja de id: {1} (Nivel DB)", Monto, IdCaja), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            };
            cajaDestino.saldo += Monto;
            this.altaMovimiento(cajaDestino, "Deposito", Monto);
            return true;
        }
        public bool retirar(int IdCaja, float Monto)
        {
            CajaDeAhorro cajaSeleccionada = BuscarCajaDeAhorro(IdCaja);
            if (cajaSeleccionada.saldo < Monto)
            {
                return false;
            }
            if (DB.retirarDeCaja(IdCaja, Monto) <= 0)
            {
                MessageBox.Show(String.Format("No se pudo retirar el monto: {0} de la caja de id: {1} (Nivel DB)", Monto, IdCaja), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            };
            cajaSeleccionada.saldo -= Monto;
            this.altaMovimiento(cajaSeleccionada, "Retiro", Monto);
            return true;
        }
        public bool transferir(int IdOrigen, int CbuDestino, float Monto)
        {
            CajaDeAhorro cajaOrigen = BuscarCajaDeAhorro(IdOrigen);
            CajaDeAhorro cajaDestino = this.cajas.Find(caja => caja.cbu == CbuDestino);
            if (cajaDestino == null)
            {
                MessageBox.Show("No se encontro la cuenta destino con el Nro de CBU " + CbuDestino, "Cuenta inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cajaOrigen.saldo < Monto)
            {
                MessageBox.Show("El monto que desea transferir supera el saldo de la cuenta", "Saldo insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DB.retirarDeCaja(IdOrigen, Monto) <= 0)
            {
                MessageBox.Show(String.Format("No se pudo retirar el monto: {0} de la caja de id: {1} (Nivel DB)", Monto, IdOrigen), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            };
            if (DB.depositarEnCaja(CbuDestino, Monto) <= 0)
            {
                MessageBox.Show(String.Format("No se pudo depositar el monto: {0} en la caja de id: {1} (Nivel DB)", Monto, CbuDestino), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            };
            cajaOrigen.saldo -= Monto;
            this.altaMovimiento(cajaOrigen, "Transferencia realizada", Monto);
            cajaDestino.saldo += Monto;
            this.altaMovimiento(cajaDestino, "Transferencia recibida", Monto);
            return true;
        }
        public Movimiento buscarMovimiento(int Id)
        {
            return movimientos.Find(movimiento => movimiento.id == Id);
        }
        public List<Movimiento> buscarMovimiento(CajaDeAhorro CajaOrigen, DateTime Fecha, float Monto)
        {
            return CajaOrigen.movimientos.FindAll(movimiento => movimiento.monto == Monto && movimiento.fecha == Fecha).ToList();
        }
        public List<Movimiento> buscarMovimiento(CajaDeAhorro CajaOrigen, DateTime Fecha)
        {
            return CajaOrigen.movimientos.FindAll(movimiento => movimiento.fecha.Day == Fecha.Day && movimiento.fecha.Month == Fecha.Month && movimiento.fecha.Year == Fecha.Year).ToList();
        }
        public List<Movimiento> buscarMovimiento(CajaDeAhorro CajaOrigen, float Monto)
        {
            return CajaOrigen.movimientos.FindAll(movimiento => movimiento.monto == Monto).ToList();
        }
        public List<Movimiento> buscarMovimiento(CajaDeAhorro CajaOrigen, string Detalle)
        {
            return CajaOrigen.movimientos.FindAll(movimiento => movimiento.detalle == Detalle).ToList();
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
            tarjeta.consumo += pago.monto;
            this.modificarPago(idPago);
            pago.metodo = "Tarjeta";
            return 0;
        }
    }
}

