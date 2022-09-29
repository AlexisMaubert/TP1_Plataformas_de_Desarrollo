using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class CajaDeAhorro
    {
        public int id { get; set; }
        public int cbu { get; set; }
        public List<Usuario> titulares { get; set; }
        public float saldo { get; set; }
        public List<Movimiento> movimientos { get;  }

        public CajaDeAhorro() { }

        public CajaDeAhorro( List<Usuario> Titulares)
        {
            Random rnd = new Random();
            cbu = rnd.Next(100000000, 999999999);
            saldo = 0;
            titulares = Titulares;
            movimientos = new List<Movimiento>();
        }
    }
}
