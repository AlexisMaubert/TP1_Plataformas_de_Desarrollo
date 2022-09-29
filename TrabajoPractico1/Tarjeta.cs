using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Tarjeta
    {
        public int id { get; set; }
        public Usuario titular { get; set; }
        public int numero { get; set; }
        public int codigoV { get; set; }
        public float limite { get; set; }
        public float consumo { get; set; }

        public Tarjeta()
        {

        }

        public Tarjeta( Usuario Titular, float Limite)
        {
            titular = Titular;
            Random rnd = new Random();
            numero = rnd.Next(100000000, 999999999);
            codigoV = rnd.Next(100, 999); ;
            limite = Limite;
            consumo = 0;
        }
    }
}
