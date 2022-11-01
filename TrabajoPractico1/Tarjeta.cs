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
        public int id_usuario { get; set; }
        public int numero { get; set; }
        public int codigoV { get; set; }
        public float limite { get; set; }
        public float consumo { get; set; }
        public Usuario titular { get; set; }
        public int id_banco { get; set; }

        public Tarjeta() 
        { 
            this.titular = new Usuario();
        }

        public Tarjeta( int Numero, int CodigoV, Usuario Titular, float Limite)
        {
            this.titular = new Usuario();
            this.titular = Titular;
            this.numero = Numero;
            this.codigoV = CodigoV;
            this.limite = Limite;
            this.consumo = 0;
        }
        public Tarjeta(int Id, int Id_Usuario, int Numero, int CodigoV, float Limite, float Consumo, int Id_banco = 1)
        {
            this.id = Id;
            this.id_usuario = Id_Usuario;
            this.numero = Numero;
            this.codigoV = CodigoV;
            this.limite = Limite;
            this.consumo = Consumo;
            this.titular = new Usuario();
            this.id_banco = Id_banco;
        }
        public override string ToString()
        {
            return string.Format("Número: {0}, Código: {1}, Límite: {2}, Consumo: {3}", this.numero, this.codigoV, this.limite, this.consumo);
        }
    }
}
