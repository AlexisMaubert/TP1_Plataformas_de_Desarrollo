using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico1
{
public class UsuarioCaja
{
    public int idUsuario { get; set; }
    public int idUsuarioCaja { get; set; }
    public UsuarioCaja( int idUsuario, int idUsuarioCaja)
{
    this.idUsuario = idUsuario;
    this.idUsuarioCaja = idUsuarioCaja;
}
}
}