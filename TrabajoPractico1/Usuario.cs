using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Usuario
    {
        private List<PlazoFijo> aPf = new List<PlazoFijo>();

        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public string password { get; set; }
        public List<CajaDeAhorro> cajas { get; }
        public List<PlazoFijo> pf { get => aPf.ToList();}
        public List<Tarjeta> tarjetas { set;  get; }
        public List<Pago> pagos { get; }

        public Usuario(int Dni, string Mail, string Password)
        {   
            dni = Dni;
            mail = Mail;
            password = Password;
            cajas = new List<CajaDeAhorro>(); 
            tarjetas = new List<Tarjeta>();
            pagos = new List<Pago>();
        }



        public Usuario(int Id, int Dni, string Nombre, string Apellido, string Mail, string Password)
        {
            id = Id;
            dni = Dni;
            nombre = Nombre;
            apellido = Apellido;
            mail = Mail;
            password = Password;
            cajas = new List<CajaDeAhorro>();
            tarjetas = new List<Tarjeta>();
            pagos = new List<Pago>();
        }
        public override string ToString()
        {
            return string.Format("Nombre: {0}, Apellido: {1}, Email: {2}, Password: {3}", nombre, apellido, mail, password);
        }
    }
}