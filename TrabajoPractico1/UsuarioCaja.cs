using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico1
{
    public class UsuarioCaja
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idCaja { get; set; }

        public UsuarioCaja(int Id, int IdCaja, int IdUsuario)
        {
            this.id = Id;
            this.idUsuario = IdUsuario;
            this.idCaja = IdCaja;
        }
    }
}