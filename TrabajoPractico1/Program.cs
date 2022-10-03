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

            b.altaUsuario("Cosme","Fulanito",1234,"cosmefulanito@gmail.com","contraseņa indescifrable");
            b.altaUsuario("Tipo","De incognito",5689,"tipodeincognito@gmail.com","contraseņa indescifrable");
            foreach(Usuario u  in b.usuarios){Debug.WriteLine("Alta usuario: " + u);}

            b.modificarUsuario(5689,"tipo@gmail.com","contraseņa");
            foreach(Usuario u  in b.usuarios){Debug.WriteLine("Post-modificacion de usuario" + u);}
            
            //b.bajaUsuario(5689);
            //foreach(Usuario u  in b.usuarios){Debug.WriteLine(u);}

            b.altaCaja(b.usuarios);
            Debug.WriteLine("Caja de ahorro en lista de Banco: " + b.cajas[0]);
            Debug.WriteLine("Caja de ahorro en lista del Usuario: " + b.usuarios[0].cajas[0]);

            //b.bajaCaja(b.cajas[0].cbu);

            b.altaTarjeta(b.usuarios[0],50000);
            b.altaTarjeta(b.usuarios[0],25000);

            foreach(Tarjeta t  in b.tarjetas){Debug.WriteLine("Alta tarjeta en banco: " + t);}
            foreach(Tarjeta t  in b.usuarios[0].tarjetas){Debug.WriteLine("Alta tarjeta en usuario: " + t);}

            b.bajaTarjeta(b.usuarios[0].tarjetas[0].numero);

            foreach(Tarjeta t  in b.tarjetas){Debug.WriteLine("Post-baja en banco: " + t);}
            foreach(Tarjeta t  in b.usuarios[0].tarjetas){Debug.WriteLine("Post-baja en Usuario: " + t);}

            b.nuevoPago(b.usuarios[0],"Pago 1?", 300, "Efectivo");
            foreach(Pago p  in b.pagos){Debug.WriteLine("Nuevo pago en banco: " + p);}
            foreach(Pago p in b.usuarios[0].pagos){Debug.WriteLine("Nuevo pago en usuarios: " + p);}

            b.modificarPago(b.pagos[0].id);
            foreach(Pago p  in b.pagos){Debug.WriteLine("Post-modificacion de pago: " + p);}
            foreach(Pago p in b.usuarios[0].pagos){Debug.WriteLine("Post-baja en Usuario: " + p);}

            b.nuevoPago(b.usuarios[0],"Tiene que quedarse", 300, "Efectivo");
            b.quitarPago(b.pagos[0].id);
            foreach(Pago p  in b.pagos){Debug.WriteLine("Post-modificacion de pago en banco: " + p);}
            foreach(Pago p  in b.usuarios[0].pagos){Debug.WriteLine("Post-modificacion de pago en usuarios: " + p);}
        }
    }
}