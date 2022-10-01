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

        public Banco() {}

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
                }else
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
                if (usuarios.Any(usuario =>  usuario.dni == dni))//Condicional para saber si existe el usuario 
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
        public bool altaCaja(List<Usuario> titulares) //Funcionando
        {
            try
            {
                Random random = new Random(); 
                int nuevoCbu = random.Next(100000000, 999999999);
                while(cajas.Any(caja => caja.cbu == nuevoCbu)) {  // Mientras haya alguna caja con ese CBU se crea otro CBU
                    nuevoCbu = random.Next(100000000, 999999999);
                    Debug.WriteLine("El CBU generado ya existe, creado uno nuevo...");
                }
                CajaDeAhorro cajaAgregar = new CajaDeAhorro(nuevoCbu, titulares);
                this.aCajas.Add(cajaAgregar);
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
                this.aCajas.Remove(cajaARemover);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //TARJETAS-----------------------------------------
        public bool altaTarjeta(Usuario titular, float monto)//Sin chequear
        {
            try
            {
                Random random = new Random(); 
                int nuevoNumero = random.Next(100000000, 999999999);
                while(tarjetas.Any(tarjeta => tarjeta.numero == nuevoNumero)) {  // Mientras haya alguna tarjeta con ese numero se crea otro numero
                    nuevoNumero = random.Next(100000000, 999999999);
                    Debug.WriteLine("El número de tarjeta generado ya existe, creado uno nuevo...");
                }
                int nuevoCodigo = random.Next(100, 999);
                Tarjeta tarjetaNueva = new Tarjeta(nuevoNumero, nuevoCodigo, titular, monto);
                this.aTarjetas.Add(tarjetaNueva);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void bajaTarjeta(int numeroTarjeta)//Sin chequear
        {
            try
            {
                Tarjeta tarjetaARemover = tarjetas.SingleOrDefault(tarjeta => tarjeta.numero == numeroTarjeta);
                this.aTarjetas.Remove(tarjetaARemover);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
