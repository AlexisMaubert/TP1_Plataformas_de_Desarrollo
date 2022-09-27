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
        public Usuario titular { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
        public float tasa { get; set; }
        public bool pagado { get; set; }
    

        public PlazoFijo()   {   }

        public PlazoFijo(int Id, Usuario Titular, float Monto, DateTime FechaFin, float Tasa)
        {
           id = Id;
           titular = Titular;
           monto = Monto;
           fechaIni = DateTime.Now;
           fechaFin = FechaFin;
           tasa = Tasa;
           pagado = false;
        }
       
    }
}
