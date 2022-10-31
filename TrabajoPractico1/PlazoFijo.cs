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
        public Usuario titular { get; set; }
        public int id_banco { get; set; }
        public int id_usuario { get; set; }
        public CajaDeAhorro LAcaja { get; set; }
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
           this.LAcaja = new CajaDeAhorro();
        }

        public PlazoFijo(int id, float Monto, DateTime FechaFin, float Tasa)
        {
            this.titular = new Usuario();
            this.monto = Monto;
            this.fechaIni = DateTime.Now;
            this.fechaFin = FechaFin;
            this.tasa = Tasa;
            this.pagado = false;
            this.LAcaja = new CajaDeAhorro();
        }

        public override string ToString()
        {
            return string.Format("Monto: {0}, fechaIni: {1}, fechaFin: {2}, tasa: {3} ,pagado: {4} ,titular{5}", monto, fechaIni, fechaFin, tasa, pagado, titular);
        }

    }
}
