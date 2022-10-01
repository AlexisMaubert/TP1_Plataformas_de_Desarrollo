using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Movimiento
    {
        private CajaDeAhorro aCaja;

        public int id { get; set; }
        public string detalle { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }
        public CajaDeAhorro caja { get => aCaja; }//Supongo que acá falta algo como el ToList() para las listas para pasarle una copia de la variable.

        public Movimiento() { }

        public Movimiento(CajaDeAhorro Caja, string Detalle, float Monto)
        {
            this.aCaja = Caja;
            this.detalle = Detalle;
            this.monto = Monto;
            this.fecha = DateTime.Now;
        }
    }
}
