using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Pago
    {
        public Usuario user { get; set; }
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public string metodo { get; set; }
        public int id_banco { get; set; }

        public Pago( int Id, int Id_usuario, string Nombre, float Monto, bool Pagado, string Metodo, int Id_banco)
        {
            
            this.id = Id;
            this.id_usuario = Id_usuario;
            this.nombre = Nombre;
            this.monto = Monto;
            this.pagado = Pagado;
            this.metodo = Metodo;
            this.id_banco = Id_banco;
        }

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
