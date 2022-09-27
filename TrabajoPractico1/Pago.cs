using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Pago
    {
        public int id { get; set; }
        public Usuario user { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public string metodo { get; set; }

        public Pago() { }

        public Pago(int Id, Usuario User, string Nombre, float Monto, string Metodo)
        {
            id = Id;
            user = User;
            nombre = Nombre;
            monto = Monto;
            pagado = false;
            metodo = Metodo;
        }

    }

    
}
