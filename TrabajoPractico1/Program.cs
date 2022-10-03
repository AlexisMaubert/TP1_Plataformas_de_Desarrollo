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

            


            b.altaUsuario(42419527, "agustin.giudice@davinci.edu.ar", "ContraseniaSecreta");
            b.altaTarjeta(b.usuarios[0], 20);


            Console.WriteLine("funciono bro");


        }
    }
}