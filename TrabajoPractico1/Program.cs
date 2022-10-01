using System.Diagnostics;

namespace TrabajoPractico1
{
    internal static class Program
    {


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            Banco b = new Banco();

            Usuario user1 = new Usuario(111111,"user1@gmail.com","1234");
            Usuario user2 = new Usuario(111112,"user2@gmail.com","1234");

            Tarjeta visa = new Tarjeta(user1, 200);
            Tarjeta mastercard = new Tarjeta(user1, 300);

            List<Tarjeta> tarjetas = new List<Tarjeta>();
            tarjetas.Add(visa);
            tarjetas.Add(mastercard);

            b.altaUsuario(user1.dni, user1.mail, user1.password);
            b.altaUsuario(user2.dni, user2.mail, user2.password);

            b.altaCaja(b.usuarios);
            b.altaCaja(b.usuarios);
            b.altaCaja(b.usuarios);
            b.altaCaja(b.usuarios);

            b.bajaCaja(b.cajas[0].cbu);

            Debug.WriteLine("terminó");


            //b.modificarUsuario(42345645, "magali@gmail.com","Magalí");

            
            //b.darTarjetaAUsuario(visa, makuka.dni);
            //b.darTarjetaAUsuario(mastercard, makuka.dni);


            //b.modificarTarjetasUsuario(tarjetas, makuka.dni);


            //b.altaUsuario(333333,"elale@gmail.com", "tugatitosexy");
            //Debug.WriteLine("Agregar usuario");
            //b.usuarios.ForEach(p => Debug.WriteLine(p));
            //Debug.WriteLine("Modificar usuario");
            //b.modificarUsuario(333333,"alexis@gmail.com", "1234");
            //b.usuarios.ForEach(p => Debug.WriteLine(p));
            //Debug.WriteLine("Eliminar usuario");
            //b.bajaUsuario(333333);
            //b.usuarios.ForEach(p => Debug.WriteLine(p));



        }
    }
}