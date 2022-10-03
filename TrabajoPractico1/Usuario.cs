using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Usuario 
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public string password { get; set; }
        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pf { get; set;}
        public List<Tarjeta> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }

        public Usuario()
        {
            this.pagos = new List<Pago>();
            this.cajas = new List<CajaDeAhorro>();
            this.pf = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
        }
        public Usuario(string Nombre, string Apellido, int Dni, string Mail, string Password)
        {  
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.dni = Dni;
            this.mail = Mail;
            this.password = Password;
            this.pagos = new List<Pago>();
            this.cajas = new List<CajaDeAhorro>();
            this.pf = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
        }
        public override string ToString()
        {
            return string.Format("Nombre: {0}, Apellido: {1}, Email: {2}, Password: {3}", nombre, apellido, mail, password);
        }
    }
}