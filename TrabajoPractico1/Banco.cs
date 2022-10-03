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
        //Cambie la "p" del nombre de las variables por la "a" haciendo referencia a que son atributos
        // una boludes pero para no confundir
        private List<Usuario> aUsuarios = new List<Usuario>();
        private List<CajaDeAhorro> aCajas = new List<CajaDeAhorro>();
        private List<PlazoFijo> aPfs = new List<PlazoFijo>();
        private List<Tarjeta> aTarjetas = new List<Tarjeta>();
        private List<Pago> aPagos = new List<Pago>();
        private List<Movimiento> aMovimientos = new List<Movimiento>();

        //En las properties que tienen valor por referencia vamos a necesitar atributos
        //En el get de las properties vamos a pasar una copia del valor de los atributos y el set no va
        public List<Usuario> usuarios { get => aUsuarios.ToList(); }
        public List<CajaDeAhorro> cajas { get => aCajas.ToList(); }
        public List<PlazoFijo> pfs { get => aPfs.ToList(); }
        public List<Tarjeta> tarjetas { get => aTarjetas.ToList(); }
        public List<Pago> pagos { get => aPagos.ToList(); }
        public List<Movimiento> movimientos { get => aMovimientos.ToList(); }

        public Banco() { }

        public Banco(List<Usuario> Usuarios, List<CajaDeAhorro> Cajas, List<PlazoFijo> Pfs, List<Tarjeta> Tarjetas, List<Pago> Pagos, List<Movimiento> Movimientos)
        {
            //Cargamos los atributos con lo que le pasamos por parámetro.
            this.aUsuarios = Usuarios;
            this.aCajas = Cajas;
            this.aPfs = Pfs;
            this.aTarjetas = Tarjetas;
            this.aPagos = Pagos;
            this.aMovimientos = Movimientos; //El banco no empezaría con los movimientos en 0??
        }

        //MOVIMIENTOS
        public bool altaMovimiento(CajaDeAhorro Caja, string Detalle, float Monto)
        {
            try
            {
                Movimiento movimientoNuevo = new Movimiento( Caja, Detalle, Monto);
                this.aMovimientos.Add(movimientoNuevo);
                Caja.agregarMovimiento(movimientoNuevo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //USUARIOS-------------------------------------------------
        public bool altaUsuario(int dni, string mail, string pass) //Funcionando
        {
            try
            {
                if (!usuarios.Any(usuario => usuario.dni == dni)) //Agregue la condición de que no exista el usuario
                {
                    Usuario usuarioNuevo = new Usuario(dni, mail, pass);
                    this.aUsuarios.Add(usuarioNuevo);
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
                if (!usuarios.Any(usuario => usuario.dni == nuevoUsuario.dni)) //Agregue la condición de que no exista el usuario
                {
                    this.aUsuarios.Add(nuevoUsuario);
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
                this.aUsuarios.Remove(usuarioARemover);
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
                if (usuarios.Any(usuario => usuario.dni == dni))//Condicional para saber si existe el usuario 
                {
                    Usuario usuarioAModificar = usuarios.Find(usuario => usuario.dni == dni);
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
                while (cajas.Any(caja => caja.cbu == nuevoCbu))
                {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                    nuevoCbu = random.Next(100000000, 999999999);
                    Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
                }
                CajaDeAhorro cajaAgregar = new CajaDeAhorro(nuevoCbu, titulares);
                this.aCajas.Add(cajaAgregar);
                foreach (Usuario titular in usuarios)
                {
                    titular.agregarCaja(cajaAgregar); // Agrego a la lista de cajas de ahorro de todos los titulares la caja de ahorro
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool bajaCaja(int cbu)//Funcionando
        {
            try
            {
                CajaDeAhorro cajaARemover = cajas.SingleOrDefault(caja => caja.cbu == cbu);
                if (cajaARemover.saldo == 0)
                {
                    this.aCajas.Remove(cajaARemover);
                    foreach (Usuario titular in cajaARemover.titulares) //Itero entre los titulares de la caja de ahorro
                    {
                        titular.quitarCaja(cajaARemover);  //Saco la caja de ahorro.
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
        //TARJETAS-----------------------------------------
        public bool altaTarjeta(Usuario titular, float monto)//Funcionando
        {
            try
            {
                Random random = new Random();
                int nuevoNumero = random.Next(100000000, 999999999);
                while (tarjetas.Any(tarjeta => tarjeta.numero == nuevoNumero))
                {  // Mientras haya alguna tarjeta con ese numero se crea otro numero
                    nuevoNumero = random.Next(100000000, 999999999);
                    Debug.WriteLine("El número de tarjeta generado ya existe, creado uno nuevo...");
                }
                int nuevoCodigo = random.Next(100, 999); //Creo un codigo de tarjeta aleatorio
                Tarjeta tarjetaNueva = new Tarjeta(nuevoNumero, nuevoCodigo, titular, monto);
                this.aTarjetas.Add(tarjetaNueva); //Agrego la tarjeta a la lista de tarjetas del banco
                titular.agregarTarjeta(tarjetaNueva); //Agrego la tarjeta a la lista de tarjetas del usuario

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool bajaTarjeta(int numeroTarjeta)//Sin chequear
        {
            try
            {
                
                Tarjeta tarjetaARemover = tarjetas.SingleOrDefault(tarjeta => tarjeta.numero == numeroTarjeta);
                if (tarjetaARemover.consumo == 0) // La condición para eliminar es que no tenga consumos sin pagar.
                {
                    this.aTarjetas.Remove(tarjetaARemover); //Borro la tarjeta de la lista de tarjetas del Banco
                    tarjetaARemover.titular.quitarTarjeta(tarjetaARemover);//Borro la tarjeta de la lista de tarjetas del usuario.
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
        public bool nuevoPago(Usuario Usuario, string Nombre, float Monto, string Metodo)//No está chequeado
        {
            try
            {
                int nuevoId = this.pagos.Count() + 1;
                Pago nuevoPago = new Pago(nuevoId, Usuario, Nombre, Monto, Metodo);
                nuevoPago.pagado = true;
                this.aPagos.Add(nuevoPago);
                Usuario.agregarPago(nuevoPago);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool quitarPago(int IdpagoABorrar)//No está chequeado
        {
            try
            {
                Pago pagoABorrar = pagos.Find(pago => pago.id == IdpagoABorrar);
                this.pagos.Remove(pagoABorrar);
                pagoABorrar.user.quitarPago(pagoABorrar);
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
                Pago pagoAModificar = pagos.Find(pago => pago.id == IdPagoAModificar);
                pagoAModificar.modificarEstado();
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
                NuevoPlazoFijo.titular.agregarPF(NuevoPlazoFijo);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
