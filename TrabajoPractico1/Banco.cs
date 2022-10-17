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
        public List<Usuario> usuarios { get ; }
        public List<CajaDeAhorro> cajas { get ; }
        public List<PlazoFijo> pfs { get ; }
        public List<Tarjeta> tarjetas { get ; }
        public List<Pago> pagos { get ; }
        public List<Movimiento> movimientos { get ; }
        public Usuario usuarioLogeado { get; set; } //Se crea una variable para guardar al usuario que inicie sesión

        public Banco() 
        { 
            this.usuarios = new List<Usuario>();
            this.cajas = new List<CajaDeAhorro>();
            this.pfs = new List<PlazoFijo>();    
            this.tarjetas = new List<Tarjeta>();
            this.pagos = new List<Pago>();
            this.movimientos = new List<Movimiento>();
        }

        //MOVIMIENTOS
        public bool altaMovimiento(CajaDeAhorro Caja, string Detalle, float Monto)
        {
            try
            {
                Movimiento movimientoNuevo = new Movimiento( Caja, Detalle, Monto);
                this.movimientos.Add(movimientoNuevo);
                Caja.movimientos.Add(movimientoNuevo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //USUARIOS-------------------------------------------------
        public bool altaUsuario(string Nombre, string Apellido, int Dni, string Mail, string Pass) //Funcionando
        {
            try
            {
                if (!this.usuarios.Any(usuario => usuario.dni == Dni)) //Agregue la condición de que no exista el usuario
                {
                    Usuario usuarioNuevo = new Usuario( Nombre, Apellido,Dni, Mail, Pass);
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

        public bool altaUsuario(Usuario nuevoUsuario) //No está testeado... Se hizo por sí las dudas.
        {
            try
            {
                if (!this.usuarios.Any(usuario => usuario.dni == nuevoUsuario.dni)) //Agregue la condición de que no exista el usuario
                {
                    Usuario usuarioNuevo = new Usuario(nuevoUsuario.nombre, nuevoUsuario.apellido, nuevoUsuario.dni, nuevoUsuario.mail, nuevoUsuario.password);
                    this.usuarios.Add(nuevoUsuario); //arreglar esto!!!
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

        public bool bajaUsuario(int dni)//Funcionando
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

        public bool modificarUsuario(int dni, string mail, string pass)//Funcionando
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

        //CAJAS---------------------------------------------
        public bool altaCaja(List<Usuario> titulares) //Funcionando
        {
            try
            {
                Random random = new Random();
                int nuevoCbu = random.Next(100000000, 999999999);
                while (this.cajas.Any(caja => caja.cbu == nuevoCbu))
                {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                    nuevoCbu = random.Next(100000000, 999999999);
                    Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
                }
                CajaDeAhorro cajaAgregar = new CajaDeAhorro(nuevoCbu, titulares);
                this.cajas.Add(cajaAgregar);
                foreach (Usuario titular in titulares)
                {
                    titular.cajas.Add(cajaAgregar); // Agrego a la lista de cajas de ahorro de todos los titulares la caja de ahorro
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool altaCaja(Usuario Titular, CajaDeAhorro Caja) //Método alternativo para agregar cajas de ahorros a la lista del banco y del usuario
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

        public bool bajaCaja(int cbu)//Funcionando, todavía no se probó tratar de eliminar una con saldo !=0
        {
            try
            {
                CajaDeAhorro cajaARemover = this.cajas.SingleOrDefault(caja => caja.cbu == cbu);
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

        public bool eliminarUsuarioDeCaja(CajaDeAhorro caja, int Dni) //In CajaDeAhorro y Usuario, out Boolean
        {
            Usuario titular = this.usuarios.Find(usuario => usuario.dni == Dni);
            if(titular == null)
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

        //TARJETAS-----------------------------------------
        public bool altaTarjeta(Usuario titular, float monto)//Funcionando
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
                Tarjeta tarjetaNueva = new Tarjeta(nuevoNumero, nuevoCodigo, titular, monto);
                this.tarjetas.Add(tarjetaNueva); //Agrego la tarjeta a la lista de tarjetas del banco
                titular.tarjetas.Add(tarjetaNueva); //Agrego la tarjeta a la lista de tarjetas del usuario

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bajaTarjeta(int numeroTarjeta)//Funciona, todavía no se probó tratar de eliminar una con consumos
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
        
        //modificar solamente el limite de la tarjeta de credito --> id y cbu por que id no es cbu duda con fran
        //10-10 => Estabamos usando el número de la tarjeta como identificador xq todavía no sabemos como manejar el tema del id sin base de datos.
       
        public bool modificarTarjetaDeCredito(int numeroTarjetaAModificar, float limite)//Funcionando
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

        //PAGOS-----------------------------
        public bool nuevoPago(Usuario Usuario, string Nombre, float Monto, string Metodo)//Funcionando
        {
            try
            {
                int nuevoId = this.pagos.Count() + 1;
                Pago nuevoPago = new Pago(nuevoId, Usuario, Nombre, Monto, Metodo);
                this.pagos.Add(nuevoPago);
                Usuario.pagos.Add(nuevoPago);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool quitarPago(int IdpagoABorrar)//Funcionando
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

        public bool modificarPago(int IdPagoAModificar)//Funcionando
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

        //PLAZO FIJO--------------------------------------------------
        public bool agregarPlazoFijo(PlazoFijo NuevoPlazoFijo)
        {
            try
            {
                this.pfs.Add(NuevoPlazoFijo);
                NuevoPlazoFijo.titular.pf.Add(NuevoPlazoFijo);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool eliminarPlazoFijo(int idPlazoAEliminar)
        {

            PlazoFijo plazoFijoAEliminar = this.pfs.Find(pf => pf.id == idPlazoAEliminar);
            try
            {
                if (plazoFijoAEliminar.pagado == true && DateTime.Now >= plazoFijoAEliminar.fechaFin.AddMonths(1))
                {
                    plazoFijoAEliminar.titular.pf.Remove(plazoFijoAEliminar);
                    this.pfs.Remove(plazoFijoAEliminar);
                    return true;
                }
                else
                {
                    return false;
                    Debug.WriteLine("No se a realizado el pago o la fecha no es la correctas");
                }
            }
            catch
            {
                return false;
            }

        }

        //
        //METODOS PARA MOSTRAR DATOS
        //
        public List<CajaDeAhorro> obtenerCajaDeAhorro()
        {
            return usuarioLogeado.cajas.ToList();
        }
        public List<CajaDeAhorro> obtenerCajaDeAhorro(int Dni) //Se crea este método para ir testeando pasar valores por referencia
                                                                                            //no se si se va a usar en el proyecto final
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.dni == Dni)
                {
                    return usuario.cajas.ToList();
                }
            }
            return null;
        }

        public List<Movimiento> obtenerMovimientos(int Cbu)
        {
            foreach(CajaDeAhorro caja in usuarioLogeado.cajas)
            {
                if (caja.cbu == Cbu) 
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

        public List<PlazoFijo> obtenerPlzFijo()
        {
            return usuarioLogeado.pf.ToList();
        }

        public List<Tarjeta> obtenerTarjetas()
        {
            return usuarioLogeado.tarjetas.ToList();
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
            if(user == null) 
            {
                MessageBox.Show("Usuario no encontrado", "Log in incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(user.bloqueado)
            {
                MessageBox.Show("Este usuario está bloqueado", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(user.password != Pass) 
            {
                user.intentosFallidos++; 
                if(user.intentosFallidos >= 3) //Si alcanza los 3 intentos se bloquea la cuenta
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
        public bool crearCajaDeAhorro(float Saldo)
        {
            Random random = new Random();
            int nuevoCbu = random.Next(100000000, 999999999);
            while (this.cajas.Any(caja => caja.cbu == nuevoCbu))
            {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                nuevoCbu = random.Next(100000000, 999999999);
                Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
            }
            CajaDeAhorro cajaNueva = new CajaDeAhorro(nuevoCbu, this.usuarioLogeado);
            cajaNueva.saldo = Saldo;
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
            if(CajaOrigen.saldo < Monto)
            {
                return false;
            } 
            else
            {
                CajaOrigen.saldo -= Monto;
                this.altaMovimiento(CajaOrigen, "Transferencia realizada" , Monto);
                cajaDestino.saldo += Monto;
                this.altaMovimiento(cajaDestino, "Transferencia recibida" , Monto);
                return true;
            }
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
            if(Caja.saldo >= Tarjeta.consumo)
            {
                Caja.saldo = Caja.saldo - Tarjeta.consumo;
                this.altaMovimiento(Caja, "Pago de Tarjeta " + Tarjeta.numero, Tarjeta.consumo);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
