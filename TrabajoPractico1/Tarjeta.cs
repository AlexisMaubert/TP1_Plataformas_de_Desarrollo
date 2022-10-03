using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Tarjeta
    {
        private Usuario aTitular;

        public int id { get; set; }
        public int numero { get; set; }
        public int codigoV { get; set; }
        public float limite { get; set; }
        public float consumo { get; set; }
        public Usuario titular { get =>  aTitular; }//Supongo que acá falta algo como el ToList() para las listas para pasarle una copia de la variable.

        public Tarjeta() { }

        public Tarjeta( int Numero, int CodigoV, Usuario Titular, float Limite)
        {
            this.aTitular = Titular;
            this.numero = Numero;
            this.codigoV = CodigoV;
            this.limite = Limite;
            this.consumo = 0;
        }
        
    }
}
