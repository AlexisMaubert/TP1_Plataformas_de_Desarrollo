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
        public string nombre { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public string metodo { get; set; }
        public Usuario user { get ; }

        public Pago() 
        {
            
        }

        public Pago( int Id,Usuario User, string Nombre, float Monto)
        {
            this.id = Id;
            user = new Usuario();
            this.user = User;
            this.nombre = Nombre;
            this.monto = Monto;
            this.pagado = false;
        }
        public override string ToString()
        {
            return string.Format("Nombre: {0}, Monto: {1}, Pagado: {2}, Método: {3}, Id: {4}", this.nombre, this.monto, this.pagado, this.metodo, this.id);
        }
    }

    
}
