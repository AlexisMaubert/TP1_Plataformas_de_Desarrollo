using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class CajaDeAhorro
    {
        private List<Usuario> aTitulares = new List<Usuario>();
        private List<Movimiento> aMovimiento = new List<Movimiento>();

        public int id { get; set; }
        public int cbu { get; set; }
        public float saldo { get; set; }
        public List<Usuario> titulares { get => aTitulares.ToList();  }
        public List<Movimiento> movimientos { get => aMovimiento.ToList(); }

        public CajaDeAhorro() { }

        public CajaDeAhorro( int Cbu, List<Usuario> Titulares)
        {
            this.cbu = Cbu;
            this.saldo = 0;
            this.aTitulares = Titulares;
        }
        public void agregarMovimiento(Movimiento NuevoMovimiento)
        {
            this.aMovimiento.Add(NuevoMovimiento);
        }
    }
}
