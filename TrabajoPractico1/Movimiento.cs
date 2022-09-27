using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Movimiento
    {
        public int id { get; set; }
        public CajaDeAhorro caja { get; set; }
        public string detalle { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }

        public Movimiento(int Id, CajaDeAhorro Caja, string Detalle, float Monto)
        {
            id = Id;
            caja = Caja;
            detalle = Detalle;
            monto = Monto;
            fecha = DateTime.Now;

        }
    }
}
