using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        public Usuario usuarioLogeado { get ;} //Se crea una variable para guardar al usuario que inicie sesión

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
        public bool altaCaja(List<Usuario> titulares) //Sin testear
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

        public bool agregarUsuarioACaja(CajaDeAhorro caja, Usuario usuario) //In CajaDeAhorro y Usuario, out Boolean
        {
            try
            {
                if (!caja.titulares.Contains(usuario))
                {
                    caja.titulares.Add(usuario);
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

        public bool eliminarUsuarioDeCaja(CajaDeAhorro caja, Usuario usuario) //In CajaDeAhorro y Usuario, out Boolean
        {
            try
            {
                if (caja.titulares.Contains(usuario) && caja.titulares.Count > 1)//El usuario debe estar en la lista de titulares y la caja debe tener mas de un titular
                {
                    caja.titulares.Remove(usuario);
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

        public List<CajaDeAhorro> obtenerCajaDeAhorro(int Dni)
        {
            return usuarioLogeado.cajas.ToList();
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
    }
}
