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

        public CajaDeAhorro(int Id, int Cbu, List<Usuario> Titulares, float Saldo, List<Movimiento> Movimiento)
        {
            id= Id;
            cbu = Cbu;
            saldo = Saldo;
            titulares = Titulares;
            movimientos = Movimiento;
        }
    }
}
