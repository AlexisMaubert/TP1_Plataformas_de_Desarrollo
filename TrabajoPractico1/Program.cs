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
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPadre());

            //Banco b = new Banco();

            //b.altaUsuario("Cosme","Fulanito",1234,"cosmefulanito@gmail.com","contraseña indescifrable");
            //b.altaUsuario("Tipo","De incognito",5689,"tipodeincognito@gmail.com","contraseña indescifrable");

            //foreach (Usuario u  in b.usuarios){Debug.WriteLine("Alta usuario: " + u);}

            //b.modificarUsuario(5689,"tipo@gmail.com","contraseña");
            //foreach(Usuario u  in b.usuarios){Debug.WriteLine("Post-modificacion de usuario" + u);}

            ////b.bajaUsuario(5689);
            ////foreach(Usuario u  in b.usuarios){Debug.WriteLine(u);}

            //b.altaCaja(b.usuarios);
            //Debug.WriteLine("Caja de ahorro en lista de Banco: " + b.cajas[0]);
            //Debug.WriteLine("Caja de ahorro en lista del Usuario: " + b.usuarios[0].cajas[0]);

            ////b.bajaCaja(b.cajas[0].cbu);

            //b.altaUsuario("Usuario", "Random", 1111, "ur@gmail.com", "contraseña random");
            //b.agregarUsuarioACaja(b.obtenerCajaDeAhorro(1234)[0] , b.usuarios[2]);
            //Debug.WriteLine("Titular agregado" + b.cajas[0].titulares[2]);

            //foreach (CajaDeAhorro u in b.cajas) {
            //    foreach (Usuario user in u.titulares)
            //    {
            //        Debug.WriteLine("tituales de la caja: "+ user);
            //    }
            //}

            //b.eliminarUsuarioDeCaja(b.obtenerCajaDeAhorro(1234)[0], b.usuarios[2]);
            //foreach (Usuario u in b.usuarios) { Debug.WriteLine("Verificando usuarios" + u); }


            //b.altaTarjeta(b.usuarios[0],50000);
            //b.altaTarjeta(b.usuarios[0],25000);

            //foreach(Tarjeta t  in b.tarjetas){Debug.WriteLine("Alta tarjeta en banco: " + t);}
            //foreach(Tarjeta t  in b.usuarios[0].tarjetas){Debug.WriteLine("Alta tarjeta en usuario: " + t);}

            //b.modificarTarjetaDeCredito(b.tarjetas[0].numero, 99999);
            //foreach (Tarjeta t in b.tarjetas) { Debug.WriteLine("Modificación tarjeta en banco: " + t); }
            //foreach (Tarjeta t in b.usuarios[0].tarjetas) { Debug.WriteLine("Modificación tarjeta en usuario: " + t); }

            //b.bajaTarjeta(b.usuarios[0].tarjetas[0].numero);

            //foreach(Tarjeta t  in b.tarjetas){Debug.WriteLine("Post-baja en banco: " + t);}
            //foreach(Tarjeta t  in b.usuarios[0].tarjetas){Debug.WriteLine("Post-baja en Usuario: " + t);}

            //b.nuevoPago(b.usuarios[0],"Pago 1?", 300, "Efectivo");
            //foreach(Pago p  in b.pagos){Debug.WriteLine("Nuevo pago en banco: " + p);}
            //foreach(Pago p in b.usuarios[0].pagos){Debug.WriteLine("Nuevo pago en usuarios: " + p);}

            //b.modificarPago(b.pagos[0].id);
            //foreach(Pago p  in b.pagos){Debug.WriteLine("Post-modificacion de pago: " + p);}
            //foreach(Pago p in b.usuarios[0].pagos){Debug.WriteLine("Post-baja en Usuario: " + p);}

            //b.nuevoPago(b.usuarios[0],"Tiene que quedarse", 300, "Efectivo");
            //b.quitarPago(b.pagos[0].id);
            //foreach(Pago p  in b.pagos){Debug.WriteLine("Post-modificacion de pago en banco: " + p);}
            //foreach(Pago p  in b.usuarios[0].pagos){Debug.WriteLine("Post-modificacion de pago en usuarios: " + p);}

            //DateTime fecha = new DateTime(2021, 11, 11);
            //DateTime fecha2 = new DateTime(2019, 11, 11);

            //PlazoFijo plazito = new PlazoFijo(b.usuarios[0], 1000, fecha, 2);
            //PlazoFijo plazito2 = new PlazoFijo(b.usuarios[1], 5000, fecha2, 5);

            //b.agregarPlazoFijo(plazito);
            //b.agregarPlazoFijo(plazito2);

            //plazito.id = 0;
            //plazito.pagado = true;
            //plazito2.id = 1;


            //foreach (PlazoFijo p in b.pfs)
            //{
            //    Debug.WriteLine("lista de plazos fijos: " + p);
            //}

            //b.eliminarPlazoFijo(0);
            //foreach (PlazoFijo p in b.pfs)
            //{
            //    Debug.WriteLine("lista de plazos fijos: " + p);
            //}
        }
    }
}