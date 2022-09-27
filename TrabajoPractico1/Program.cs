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

            b.altaUsuario(333333,"elale@gmail.com", "tugatitosexy");
            Debug.WriteLine("Agregar usuario");
            b.usuarios.ForEach(p => Debug.WriteLine(p));
            Debug.WriteLine("Modificar usuario");
            b.modificarUsuario(333333,"alexis@gmail.com", "1234");
            b.usuarios.ForEach(p => Debug.WriteLine(p));
            Debug.WriteLine("Eliminar usuario");
            b.bajaUsuario(333333);
            b.usuarios.ForEach(p => Debug.WriteLine(p));


        }
    }
}