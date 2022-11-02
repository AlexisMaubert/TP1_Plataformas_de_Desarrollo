using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Movimiento
    {
        public int id { get; set; }
        public string detalle { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }
        public CajaDeAhorro caja { get; set; }
        public int id_banco { get; set; }
        public int id_Caja { get; set; }

        public Movimiento() { }

        public Movimiento(int Id, int Id_Caja, string Detalle, float Monto, DateTime Fecha, int Id_Banco)
        {
            this.id = Id;
            this.id_Caja = Id_Caja;
            this.detalle = Detalle;
            this.monto = Monto;
            this.fecha = Fecha;
            this.id_banco = Id_Banco;  
        }

        public Movimiento(CajaDeAhorro Caja, string Detalle, float Monto)
        {
            this.caja = Caja;
            this.detalle = Detalle;
            this.monto = Monto;
            this.fecha = DateTime.Now;
        }
        public override string ToString()
        {
            return string.Format("Detalle: {0}, Monto: {1}, Fecha: {2}", this.detalle, this.monto, this.fecha);
        }
    }
}
