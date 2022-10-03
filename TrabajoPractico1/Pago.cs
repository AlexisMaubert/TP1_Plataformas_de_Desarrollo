using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Pago
    {
        private Usuario aUser;

        public int id { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public string metodo { get; set; }
        public Usuario user { get=> aUser; }//Supongo que acá falta algo como el ToList() para las listas para pasarle una copia de la variable.

        public Pago() { }

        public Pago( int Id,Usuario User, string Nombre, float Monto, string Metodo)
        {
            this.id = Id;
            this.aUser = User;
            this.nombre = Nombre;
            this.monto = Monto;
            this.pagado = false;
            this.metodo = Metodo;
        }
        public void modificarEstado()
        {
            this.pagado=true;
        }
    }

    
}
