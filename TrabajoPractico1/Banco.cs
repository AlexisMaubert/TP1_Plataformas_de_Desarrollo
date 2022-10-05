using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{

    public class Banco
    {
        public List<Usuario> usuarios { get; set; }
        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pfs { get; set; }
        public List<Tarjeta> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }
        public List<Movimiento> movimientos { get; }

        public Banco() {
            usuarios = new List<Usuario>();
        }

        public Banco(List<Usuario> Usuarios, List<CajaDeAhorro> Cajas, List<PlazoFijo> Pfs, List<Tarjeta> Tarjetas, List<Pago> Pagos, List<Movimiento> Movimientos)
        {
            usuarios = Usuarios;
            cajas = Cajas;
            pfs = Pfs;
            tarjetas = Tarjetas;
            pagos = Pagos;
            movimientos = Movimientos;
        }

        public bool altaUsuario(int dni, string mail, string pass)
        {
            try
            {
                Usuario usuarioAAgregar = new Usuario(dni, mail, pass);
                usuarios.Add(usuarioAAgregar);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool bajaUsuario(int dni)
        {
            try
            {
                var usuarioARemover = usuarios.SingleOrDefault(i => i.dni == dni);
                usuarios.Remove(usuarioARemover);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool modificarUsuario(int dni, string mail, string pass)
        {
            try
            {
                var index = usuarios.FindIndex(i => i.dni == dni);
                usuarios[index] = new Usuario(dni, mail, pass);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Usuario> obtenerUsuarios()
        {
            return usuarios.ToList();
        }
        //modificar solamente el limite de la tarjeta de credito --> id y cbu por que id no es cbu duda con fran
        public bool modificarTarjetaDeCredito(int IdTarjetaAModificar, float limite)//Funcionando
        {
            try
            {
                Tarjeta TarjetaLimiteModificar = this.tarjetas.Find(tarjeta => tarjeta.id == IdTarjetaAModificar);
                TarjetaLimiteModificar.limite = limite;
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
