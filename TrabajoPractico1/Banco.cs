using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{

    public class Banco
    {
        public List<Usuario> usuarios { get; set; }
        public List<CajaDeAhorro> cajas { get; }
        public List<PlazoFijo> pfs { get; }
        public List<Tarjeta> tarjetas { set;  get; }
        public List<Pago> pagos { get; }
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

        //USUARIOS-------------------------------------------------

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

        public bool modificarTarjetasUsuario(List<Tarjeta> tarjetas,int dni)
        {
            try
            {
                var index = usuarios.FindIndex(i => i.dni == dni);
                usuarios[index].tarjetas = tarjetas;
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

        //CAJAS---------------------------------------------
        public bool altaCaja(List<Usuario> titulares)
        {
            try
            {
                CajaDeAhorro cajaAgregar = new CajaDeAhorro(titulares.ToList());
                cajas.Add(cajaAgregar);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool bajaCaja(int cbu)
        {
            try
            {
                var cajaARemover = cajas.SingleOrDefault(i => i.cbu == cbu);
                cajas.Remove(cajaARemover);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool darTarjetaAUsuario(Tarjeta tarjetita, int dni)
        {
            int index = usuarios.FindIndex(i => i.dni == dni);
            usuarios[index].tarjetas.Add(tarjetita);
            return true;
        }
        
    }
}
