using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico1;

namespace TrabajoPractico1
{
    public class Usuario 
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }
        public string password { get; set; }
        public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> pf { get; set;}
        public List<Tarjeta> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }
        public int id_banco { get; set; }
        public bool isAdmin { get; set; }

        public Usuario(int Id, int Dni, string Nombre, string Apellido, string Mail, string Password, int IntentosFallidos=0, bool Bloqueado=false, int Id_banco=1, bool Is_admin=false )
        {
            this.id = Id;
            this.dni = Dni;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.mail = Mail;
            this.password = Password;
            this.intentosFallidos = IntentosFallidos;
            this.bloqueado = Bloqueado;
            this.id_banco = Id_banco;
            this.isAdmin = Is_admin;
            this.pagos = new List<Pago>();
            this.cajas = new List<CajaDeAhorro>();
            this.pf = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
        }

        public Usuario( int Dni, string Nombre, string Apellido, string Mail, string Password, int IntentosFallidos, bool Bloqueado, int Id_banco, bool Is_admin)
        {
            this.dni = Dni;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.mail = Mail;
            this.password = Password;
            this.intentosFallidos = IntentosFallidos;
            this.bloqueado = Bloqueado;
            this.id_banco = Id_banco;
            this.isAdmin = Is_admin;
            this.pagos = new List<Pago>();
            this.cajas = new List<CajaDeAhorro>();
            this.pf = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
        }

        public Usuario()
        {
            this.pagos = new List<Pago>();
            this.cajas = new List<CajaDeAhorro>();
            this.pf = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
        }

        public Usuario(string Nombre, string Apellido, int Dni, string Mail, string Password)
        {  
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.dni = Dni;
            this.mail = Mail;
            this.password = Password;
            this.pagos = new List<Pago>();
            this.cajas = new List<CajaDeAhorro>();
            this.pf = new List<PlazoFijo>();
            this.tarjetas = new List<Tarjeta>();
        }

       

        public override string ToString()
        {
            return string.Format("Nombre: {0}, Apellido: {1}, Email: {2}, Password: {3}", nombre, apellido, mail, password);
        }
    }
}


//class UsuarioManager
//{user dom lista en banco de userdom.

//    private List<Usuario> misUsuarios;
//    private List<Domicilio> misDomicilios;
//    private List<UserDom> misUserDom;
//    private DAL DB;

//    public UsuarioManager()
//    {
//        misUsuarios = new List<Usuario>();
//        misDomicilios = new List<Domicilio>();
//        //PARA MANY TO MANY
//        //misUserDom = new List<UserDom>();
//        DB = new DAL();
//        inicializarAtributos();
//    }

//    private void inicializarAtributos()
//    {
     // SI FUESE MANY TO MANY
//        misUserDom = DB.inicializarUserDom();
//        foreach (UserDom ud in misUserDom)
//        {
//            foreach (Domicilio domicilio in misDomicilios)
//            {
//                foreach (Usuario u in misUsuarios)
//                    if (ud.idUser == u.id && ud.idDom == domicilio.id)
//                    {
//                        u.misDirecciones.Add(domicilio);
//                        domicilio.misUsuarios.Add(u);
//                    }
//            }
//        }

//    }