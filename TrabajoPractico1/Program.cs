using System.Diagnostics;

namespace TrabajoPractico1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(mainForm: new FormPadre());

        }
    }
}