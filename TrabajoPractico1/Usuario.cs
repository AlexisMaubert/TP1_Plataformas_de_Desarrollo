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
        private List<PlazoFijo> aPf = new List<PlazoFijo>();
        private List<CajaDeAhorro> aCajas = new List<CajaDeAhorro>();
        private List<Tarjeta> aTarjetas = new List<Tarjeta>();
        private List<Pago> aPagos = new List<Pago>();

        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public string password { get; set; }
        public List<CajaDeAhorro> cajas { get => aCajas.ToList(); }
        public List<PlazoFijo> pf { get => aPf.ToList();}
        public List<Tarjeta> tarjetas { get=> aTarjetas.ToList(); }
        public List<Pago> pagos { get=> aPagos.ToList(); }

        public Usuario(int Dni, string Mail, string Password)
        {   
            this.dni = Dni;
            this.mail = Mail;
            this.password = Password;
        }

        public Usuario(int Id, int Dni, string Nombre, string Apellido, string Mail, string Password)
        {
            this.id = Id;
            this.dni = Dni;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.mail = Mail;
            this.password = Password;

        public override string ToString()
        {
            return string.Format("Nombre: {0}, Apellido: {1}, Email: {2}, Password: {3}", nombre, apellido, mail, password);
        }
    }
}