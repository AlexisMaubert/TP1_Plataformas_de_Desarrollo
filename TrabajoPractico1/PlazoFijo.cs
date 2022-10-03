using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class PlazoFijo
    {
        public int id { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
        public float tasa { get; set; }
        public bool pagado { get; set; }
        public Usuario titular { get; } 

        public PlazoFijo()   
        {
            this.titular = new Usuario();
        }

        public PlazoFijo(Usuario Titular, float Monto, DateTime FechaFin, float Tasa)
        {
           this.titular= new Usuario();
           this.titular = Titular;
           this.monto = Monto;
           this.fechaIni = DateTime.Now;
           this.fechaFin = FechaFin;
           this.tasa = Tasa;
           this.pagado = false;
        }
    }
}
