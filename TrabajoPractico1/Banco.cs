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
        public int id { get; set; }
        public List<Usuario> usuarios { get; set; }
        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<Tarjeta> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }
        public List<Movimiento> movimientos { get; set; }
        public Usuario usuarioLogeado { get; set; } //Se crea una variable para guardar al usuario que inicie sesión
        private List<UsuarioCaja> miUsuarioCaja; //lista de many to many caja
        private DAL DB;

        public Banco()
        {
            this.usuarios = new List<Usuario>();
            this.cajas = new List<CajaDeAhorro>();
            this.pfs = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
            this.pagos = new List<Pago>();
            this.movimientos = new List<Movimiento>();
            miUsuarioCaja = new List<UsuarioCaja>(); //lista UsuarioCaja
            DB = new DAL();
            inicializarAtributos();
            inicializarCajaAhorro();
            //revisarPlazosFijos();
            foreach(CajaDeAhorro caja in cajas)
            {
                Debug.WriteLine(cajas);
            }

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


            foreach (Tarjeta tarjeta in tarjetas.ToList())
            {
                Usuario user = usuarios.Find(usuario => usuario.id == tarjeta.id_usuario);
                Tarjeta card = tarjetas.Find(c => c.id == tarjeta.id);
                user.tarjetas.Add(card);
                tarjetas.Add(card);
                card.titular = user;
            }
            foreach (Movimiento mov in movimientos.ToList())
            {
                CajaDeAhorro caja = BuscarCajaDeAhorro(mov.id_Caja);
                Movimiento movimiento = buscarMovimiento(mov.id);
                movimientos.Add(movimiento);
                caja.movimientos.Add(movimiento);
                movimiento.caja = caja;
            }
            foreach (Pago pago in pagos.ToList())
            {
                Pago p = buscarPago(pago.id);
                Usuario user = usuarios.Find(usuario => usuario.id == pago.id_usuario);
                pagos.Add(p);
                user.pagos.Add(p);
                p.user = user;

            }
        }
        //
        //InicializarCaja:
        //
        private void inicializarCajaAhorro()
        {
            usuarios = DB.inicializarUsuarios();
            cajas = DB.inicializarCajas();
            //pero como es Many to Many quedara asi->>>
            miUsuarioCaja = DB.inicializarUsuarioCaja();
            foreach (UsuarioCaja uc in miUsuarioCaja)
            {
                foreach (CajaDeAhorro caja in cajas)
                {
                    foreach (Usuario us in usuarios)
                    {
                        if (uc.idUsuario == us.id && uc.idCaja == caja.id)
                        {
                            us.cajas.Add(caja);
                            caja.titulares.Add(us);
                        }
                    }
                }
            }
            foreach (CajaDeAhorro cajaDeAhorro in cajas)
            {
                foreach (Usuario us in usuarios)
                {
                    if (us.id == cajaDeAhorro.id)
                    {
                        us.cajas.Add(cajaDeAhorro);
                        cajaDeAhorro.titulares.Add(us);
                    }
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
                Movimiento movimientoNuevo = new Movimiento(Caja, Detalle, Monto);
                this.movimientos.Add(movimientoNuevo);
                Caja.movimientos.Add(movimientoNuevo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //
        //USUARIOS
        //
        public bool altaUsuario(string Nombre, string Apellido, int Dni, string Mail, string Pass) //Funcionando
        {
            try
            {
                if (!this.usuarios.Any(usuario => usuario.dni == Dni)) //Agregue la condición de que no exista el usuario
                {
                    Usuario usuarioNuevo = new Usuario(Nombre, Apellido, Dni, Mail, Pass);
                    this.usuarios.Add(usuarioNuevo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool bajaUsuario(int dni)
        {
            try
            {
                Usuario usuarioARemover = usuarios.SingleOrDefault(usuario => usuario.dni == dni);
                this.usuarios.Remove(usuarioARemover);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modificarUsuario(int dni, string mail, string pass)
        {
            try
            {
                if (this.usuarios.Any(usuario => usuario.dni == dni))//Condicional para saber si existe el usuario 
                {
                    Usuario usuarioAModificar = this.usuarios.Find(usuario => usuario.dni == dni);
                    usuarioAModificar.mail = mail;
                    usuarioAModificar.password = pass;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //
        //CAJAS---------------------------------------------
        //
        public bool altaCaja(Usuario Titular, CajaDeAhorro Caja)
        {
            try
            {
                this.cajas.Add(Caja);
                Titular.cajas.Add(Caja);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool bajaCaja(int IdCaja)
        {
            try
            {
                CajaDeAhorro cajaARemover = this.cajas.SingleOrDefault(caja => caja.id == IdCaja);
                if (cajaARemover.saldo == 0)
                {
                    this.cajas.Remove(cajaARemover); //Saco la caja de ahorro del banco
                    foreach (Usuario titular in cajaARemover.titulares) //Itero entre los titulares de la caja de ahorro
                    {
                        titular.cajas.Remove(cajaARemover);  //Saco la caja de ahorro de los titulares.
                    }
                    return true;
                }
                else
                {
                    return false;
                    Debug.WriteLine("El saldo de la caja de ahorro no estaba en 0");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool agregarUsuarioACaja(CajaDeAhorro caja, int Dni)
        {
            Usuario userAdd = this.usuarios.Find(usuario => usuario.dni == Dni);
            if (userAdd == null)
            {
                MessageBox.Show("No se encontró un usuario con dni nro " + Dni, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!caja.titulares.Contains(userAdd))
            {
                caja.titulares.Add(userAdd);
                return true;
            }
            else
            {
                MessageBox.Show("El usuario ya es el titular de esta caja", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarUsuarioDeCaja(CajaDeAhorro caja, int Dni)
        {
            Usuario titular = this.usuarios.Find(usuario => usuario.dni == Dni);
            if (titular == null)
            {
                MessageBox.Show("No se encontró un usuario con dni nro " + Dni, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (caja.titulares.Contains(titular) && caja.titulares.Count > 1)//El usuario debe estar en la lista de titulares y la caja debe tener mas de un titular
            {
                caja.titulares.Remove(titular);//También elimina al Usuario de la lista de usuarios del banco... No se xq
                return true;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                Tarjeta tarjetaNueva = new Tarjeta(nuevoNumero, nuevoCodigo, this.usuarioLogeado, 20000);
                this.tarjetas.Add(tarjetaNueva); //Agrego la tarjeta a la lista de tarjetas del banco
                this.usuarioLogeado.tarjetas.Add(tarjetaNueva); //Agrego la tarjeta a la lista de tarjetas del usuario

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bajaTarjeta(int numeroTarjeta)//Todavía sin aplicación en el programa
        {
            try
            {
                Tarjeta tarjetaARemover = this.tarjetas.SingleOrDefault(tarjeta => tarjeta.numero == numeroTarjeta);
                if (tarjetaARemover.consumo == 0) // La condición para eliminar es que no tenga consumos sin pagar.
                {
                    this.tarjetas.Remove(tarjetaARemover); //Borro la tarjeta de la lista de tarjetas del Banco
                    tarjetaARemover.titular.tarjetas.Remove(tarjetaARemover);//Borro la tarjeta de la lista de tarjetas del usuario.
                    return true;
                }
                else
                {
                    Debug.WriteLine("La tarjeta posee consumo sin pagar."); //Mando un mensaje al debugger
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modificarTarjetaDeCredito(int numeroTarjetaAModificar, float limite) //Todavía sin aplicación en el programa
        {
            try
            {
                Tarjeta TarjetaLimiteModificar = this.tarjetas.Find(tarjeta => tarjeta.numero == numeroTarjetaAModificar);//Modificando numero por id funciona perfecto.
                TarjetaLimiteModificar.limite = limite;
                return true;
            }
            catch
            {
                return false;
            }
        }

        //
        //PAGOS
        //

        public bool nuevoPago(Usuario Usuario, string Nombre, float Monto)
        {
            try
            {
                Random random = new Random();
                int nuevoId = random.Next(10000, 99999);
                while (this.pagos.Any(pago => pago.id == nuevoId))
                {  // Mientras haya alguna tarjeta con ese numero se crea otro numero
                    nuevoId = random.Next(10000, 99999);
                    Debug.WriteLine("El número de pago generado ya existe, creado uno nuevo...");
                }
                Pago nuevoPago = new Pago(nuevoId, Usuario, Nombre, Monto);
                this.pagos.Add(nuevoPago);
                Usuario.pagos.Add(nuevoPago);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool quitarPago(int IdpagoABorrar)
        {
            try
            {
                Pago pagoABorrar = this.pagos.Find(pago => pago.id == IdpagoABorrar);
                this.pagos.Remove(pagoABorrar);
                pagoABorrar.user.pagos.Remove(pagoABorrar);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarPago(int IdPagoAModificar)
        {
            try
            {
                Pago pagoAModificar = this.pagos.Find(pago => pago.id == IdPagoAModificar);
                pagoAModificar.pagado = true;
                return true;
            }
            catch
            {
                return false;
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
        public bool eliminarPlazoFijo(int idPlazoAEliminar)//Todavía sin aplicación en el programa
        {
            try
            {
                if (this.buscarPlazoFijo(idPlazoAEliminar).pagado == true && DateTime.Now >= this.buscarPlazoFijo(idPlazoAEliminar).fechaFin.AddMonths(1))
                {
                    this.buscarPlazoFijo(idPlazoAEliminar).titular.pf.Remove(this.buscarPlazoFijo(idPlazoAEliminar));
                    this.pfs.Remove(this.buscarPlazoFijo(idPlazoAEliminar));
                    return true;
                }
                else
                {
                    return false;
                    Debug.WriteLine("No se a realizado el pago o la fecha no es la correctas");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool crearPlazoFijo(int Id, float Monto)
        {
            try
            {
                if (Monto >= 1000)
                {
                    CajaDeAhorro caja = this.BuscarCajaDeAhorro(Id);
                    if (caja.saldo > Monto)
                    {
                        MessageBox.Show("Plazo Fijo creado con exito.", "Operacion exitosa 😏", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                        PlazoFijo nuevoPlazoFijo = new PlazoFijo(usuarioLogeado, Monto, DateTime.Now.AddMonths(1), 90);
                        nuevoPlazoFijo.LAcaja = caja;
                        this.agregarPlazoFijo(nuevoPlazoFijo);
                    }
                    else
                    {
                        MessageBox.Show("La cuenta no posee los fondos suficientes.", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                Debug.WriteLine("El monto del plazo fijo debe ser mayor o igual a 1000");
                MessageBox.Show("Error en el ingreso de datos", "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch
            {
                return false;
            }
        }


        //
        //METODOS PARA MOSTRAR DATOS
        //
        public Usuario buscarUsuarioLogeado()
        {
            return this.usuarioLogeado;
        }
        public List<CajaDeAhorro> obtenerCajaDeAhorro()
        {
            return usuarioLogeado.cajas.ToList();
        }
        public CajaDeAhorro BuscarCajaDeAhorro(int Id)
        {
            return this.cajas.Find(caja => caja.id == Id);
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
        public Tarjeta buscarTarjeta(int numero)
        {
            return this.tarjetas.Find(tarjeta => tarjeta.numero == numero);
        }
        public string mostrarUsuario()
        {
            return usuarioLogeado.nombre + " " + usuarioLogeado.apellido;
        }

        //
        //METODOS ACCIONES DEL USUARIO
        //
        public bool iniciarSesion(int Dni, string Pass)
        {
            Usuario user = this.usuarios.Find(usuario => usuario.dni == Dni);
            if (user == null)
            {
                MessageBox.Show("Usuario no encontrado", "Log in incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (user.bloqueado)
            {
                MessageBox.Show("Este usuario está bloqueado", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (user.password != Pass)
            {
                user.intentosFallidos++;
                if (user.intentosFallidos >= 3) //Si alcanza los 3 intentos se bloquea la cuenta
                {
                    MessageBox.Show("Se ha excedido el número de intentos\nEste usuario ahora está bloqueado", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    user.bloqueado = true;
                }
                else //Si todavia no se muestran los intentos restantes
                {
                    MessageBox.Show("La contraseña ingresada fue incorrecta \nTe quedan " + (3 - user.intentosFallidos) + " intentos.", "Contraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            this.usuarioLogeado = user;
            return true;
        }
        public void cerrarSesion()
        {
            this.usuarioLogeado = null;
        }
        public bool crearCajaDeAhorro()
        {
            Random random = new Random();
            int nuevoCbu = random.Next(100000000, 999999999);
            while (this.cajas.Any(caja => caja.cbu == nuevoCbu))
            {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                nuevoCbu = random.Next(100000000, 999999999);
                Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
            }
            CajaDeAhorro cajaNueva = new CajaDeAhorro(nuevoCbu, this.usuarioLogeado);
            cajaNueva.saldo = 0;
            try
            {
                this.altaCaja(this.usuarioLogeado, cajaNueva);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void depositar(CajaDeAhorro CajaDestino, float Monto)
        {
            CajaDestino.saldo += Monto;
            this.altaMovimiento(CajaDestino, "Deposito", Monto);
        }
        public bool retirar(CajaDeAhorro CajaSeleccionada, float Monto)
        {
            if (CajaSeleccionada.saldo < Monto)
            {
                return false;
            }
            CajaSeleccionada.saldo -= Monto;
            this.altaMovimiento(CajaSeleccionada, "Retiro", Monto);
            return true;
        }
        public bool transferir(CajaDeAhorro CajaOrigen, int CBU, float Monto)
        {
            CajaDeAhorro cajaDestino = this.cajas.Find(caja => caja.cbu == CBU);
            if (cajaDestino == null)
            {
                MessageBox.Show("No se encontro la cuenta destino con el Nro de CBU " + CBU, "Cuenta inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CajaOrigen.saldo < Monto)
            {
                return false;
            }
            else
            {
                CajaOrigen.saldo -= Monto;
                this.altaMovimiento(CajaOrigen, "Transferencia realizada", Monto);
                cajaDestino.saldo += Monto;
                this.altaMovimiento(cajaDestino, "Transferencia recibida", Monto);
                return true;
            }
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
        public bool pagarTarjeta(Tarjeta Tarjeta, CajaDeAhorro Caja)
        {
            if (Caja.saldo >= Tarjeta.consumo)
            {
                Caja.saldo = Caja.saldo - Tarjeta.consumo;
                this.altaMovimiento(Caja, "Pago de Tarjeta " + Tarjeta.numero, Tarjeta.consumo);
                Tarjeta.consumo = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool pagarPago(int idPago, int numero)
        {
            Pago pago = this.pagos.Find(pago => pago.id == idPago);
            CajaDeAhorro caja = this.cajas.Find(caja => caja.cbu == numero);
            if (pago.pagado)
            {
                MessageBox.Show("El pago selecionado ya ha sido realizado", "Pago ya realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (caja == null)
            {
                Tarjeta tarjeta = this.tarjetas.Find(tarjeta => tarjeta.numero == numero);
                if (tarjeta.limite - tarjeta.consumo > pago.monto)
                {
                    tarjeta.consumo += pago.monto;
                    this.modificarPago(idPago);
                    pago.metodo = "Tarjeta";
                    return true;
                }
                else
                {
                    MessageBox.Show("El saldo disponible no es suficiente para realizar el pago", "Pago no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                if (caja.saldo < pago.monto)
                {
                    MessageBox.Show("El saldo disponible no es suficiente para realizar el pago", "Pago no realizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                caja.saldo = caja.saldo - pago.monto;
                this.modificarPago(idPago);
                this.altaMovimiento(caja, "Pago de " + pago.nombre, pago.monto);
                pago.metodo = "Caja de ahorro";
                return true;
            }
        }
    }
}
