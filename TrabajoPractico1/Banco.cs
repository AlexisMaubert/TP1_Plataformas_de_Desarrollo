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
        private List<Usuario> pusuarios = new List<Usuario>();
        private List<CajaDeAhorro> pcajas = new List<CajaDeAhorro>();
        private List<PlazoFijo> ppfs = new List<PlazoFijo>();
        private List<Tarjeta> ptarjetas = new List<Tarjeta>();
        private List<Pago> ppagos = new List<Pago>();
        private List<Movimiento> pmovimientos = new List<Movimiento>();
        public List<Usuario> usuarios { get => pusuarios.ToList(); }
        public List<CajaDeAhorro> cajas { get => pcajas.ToList(); }
        public List<PlazoFijo> pfs { get => ppfs.ToList(); }
        public List<Tarjeta> tarjetas { get => ptarjetas.ToList(); }
        public List<Pago> pagos { get => ppagos.ToList(); }
        public List<Movimiento> movimientos { get => pmovimientos.ToList(); }

        public Banco() {}

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
                this.pusuarios.Add(usuarioAAgregar);
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
                this.pusuarios.Remove(usuarioARemover);
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
                this.pusuarios[index].dni = dni;
                this.pusuarios[index].mail = mail;
                this.pusuarios[index].password = pass;
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
