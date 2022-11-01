using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TrabajoPractico1
{
    internal class DAL
    {

        private string connectionString;
        public DAL()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            connectionString = Properties.Resources.ConnectionStr;
            //connectionString = "Data Source=DESKTOP-LR8KJAR\\SQLEXPRESS;Initial Catalog=20221017;Integrated Security=True";
        }

        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "select * from usuario;";
            //string queryString = "select id, nombre, apellido, dni, mail, password from usuario;";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader.GetString(5).Trim(), reader.GetInt32(6), reader.GetBoolean(7), reader.GetInt32(8), reader.GetBoolean(9));
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                }
                catch (Exception ex)

                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;
        }

        public List<CajaDeAhorro> inicializarCajas()
        {
            List<CajaDeAhorro> cajas = new List<CajaDeAhorro>();
            string queryString = "select * from CajaAhorro;";
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    CajaDeAhorro cda;
                    while (reader.Read())
                    {
                        cda = new CajaDeAhorro(reader.GetInt32(0), reader.GetInt32(1), (float)reader.GetDouble(2), reader.GetInt32(3));
                        cajas.Add(cda);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return cajas;
        }
        //Este metodo se usa para poder completar la lista que representa la tabla intermedia entre el usuario
        //y caja de ahorro si es que la relacion es "MANY TO MANY":
        public List<UsuarioCaja> inicializarUsuarioCaja()
        {
            List<UsuarioCaja> usuarioCaja = new List<UsuarioCaja>();
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                //cargo las cajas-->
                string queryString = "SELECT * from CajaUsuario;";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarioCaja.Add(new UsuarioCaja(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return usuarioCaja;
        }

        public List<Tarjeta> inicializarTarjetas()
        {
            List<Tarjeta> misTarjetas = new List<Tarjeta>();
            string queryString = "select * from Tarjeta;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Tarjeta aux;
                    while (reader.Read())
                    {
                        aux = new Tarjeta(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), (float)reader.GetDouble(4), (float)reader.GetDouble(5), reader.GetInt32(6));
                        misTarjetas.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misTarjetas;
        }

        public List<Pago> inicializarPagos()
        {
            List<Pago> misPagos = new List<Pago>();
            string queryString = "select * from Pago;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Pago aux;
                    while (reader.Read())
                    {
                        aux = new Pago(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), (float)reader.GetDouble(3), reader.GetBoolean(4), reader.GetString(5).Trim(), reader.GetInt32(6));
                        misPagos.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misPagos;
        }

        public List<Movimiento> inicializarMovimientos()
        {
            List<Movimiento> misMov = new List<Movimiento>();
            string queryString = "select * from Movimiento;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Movimiento aux;
                    while (reader.Read())
                    {
                        aux = new Movimiento(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2).Trim(), (float)reader.GetDouble(3), reader.GetDateTime(4), reader.GetInt32(5));
                        misMov.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misMov;
        }


        public List<PlazoFijo> inicializarPlazoFijo()
        {
            List<PlazoFijo> pfs = new List<PlazoFijo>();
            string queryString = "select * from PlazoFijo;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    PlazoFijo aux;
                    while (reader.Read())
                    {
                        aux = new PlazoFijo(reader.GetInt32(0), reader.GetInt32(1), (float)reader.GetDouble(2), reader.GetDateTime(3), reader.GetDateTime(4), (float)reader.GetDouble(5), reader.GetBoolean(6), reader.GetInt32(7), reader.GetInt32(8));
                        pfs.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return pfs;
        }
        //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
        public int agregarUsuario(string Nombre, string Apellido, int Dni, string Mail, string Password, int IntentosFallidos = 0, bool Bloqueado = false, int IdBanco = 1, bool IsAdmin = false)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string queryString = "INSERT INTO [dbo].[Usuario] ([dni],[nombre],[apellido],[mail],[password],[intentos_fallidos],[bloqueado],[id_banco],[is_admin]) VALUES (@dni,@nombre,@apellido,@mail,@password,@intentos_fallidos,@bloqueado,@id_banco,@is_admin);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@intentos_fallidos", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@id_banco", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@is_admin", SqlDbType.Bit));
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@intentos_fallidos"].Value = IntentosFallidos;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@id_banco"].Value = IdBanco;
                command.Parameters["@is_admin"].Value = IsAdmin;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                    //***************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuario]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    return -1;
                }
                return idNuevoUsuario;
            }
        }
        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int eliminarUsuario(int Id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Usuarios] WHERE ID=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = Id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int modificarUsuario(int Id, int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuarios] SET Nombre=@nombre, Mail=@mail,Password=@password, EsADM=@esadm, Bloqueado=@bloqueado WHERE ID=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@esadm", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters["@id"].Value = Id;
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@esadm"].Value = EsADM;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int agregarCaja(int Cbu, float Saldo = 0, int IdBanco = 1)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevaCaja = -1;
            string queryString = "INSERT INTO [dbo].[CajaAhorro] ([cbu],[saldo],[id_banco]) VALUES (@cbu, @saldo, @id_banco);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@cbu", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@saldo", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@id_banco", SqlDbType.NVarChar));
                command.Parameters["@cbu"].Value = Cbu;
                command.Parameters["@saldo"].Value = Saldo;
                command.Parameters["@id_banco"].Value = IdBanco;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                    //***************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[CajaAhorro]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaCaja = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ex.Message: " + ex.Message);
                    return -1;
                }
                return idNuevaCaja;
            }
        }

        public int agregarUsuarioACaja(int IdCaja, int IdUsuario)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuarioCaja = -1;
            string queryString = "INSERT INTO [dbo].[CajaUsuario] ([id_caja],[id_usuario]) VALUES (@id_caja, @id_usuario);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_caja", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters["@id_caja"].Value = IdCaja;
                command.Parameters["@id_usuario"].Value = IdUsuario;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                    //***************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[CajaAhorro]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuarioCaja = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ex.Message: " + ex.Message);
                    return -1;
                }
                return idNuevoUsuarioCaja;
            }
        }
        public bool usuarioYaEstaEnCaja(int IdCaja, int IdUsuario)
        {
            string queryString = "SELECT id FROM CajaUsuario WHERE id_caja = @id_caja and id_usuario = @id_usuario;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_caja", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters["@id_caja"].Value = IdCaja;
                command.Parameters["@id_usuario"].Value = IdUsuario;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    return reader.Read();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine("ex.Message: " + ex.Message);
                    return false;
                }
            }
        }       
        public int eliminarUsuarioDeCaja(int IdCaja, int IdUsuario)
        {
            string queryString = "DELETE FROM CajaUsuario WHERE id_caja = @id_caja and id_usuario = @id_usuario;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_caja", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters["@id_caja"].Value = IdCaja;
                command.Parameters["@id_usuario"].Value = IdUsuario;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }
        public int eliminarCaja(int IdCaja)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            /////////////////////////////////////Elimino usuarios de la caja
            string queryString = "SELECT id_usuario from CajaUsuario where id_caja=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = IdCaja;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int IdUsuario = reader.GetInt32(0);
                        eliminarUsuarioDeCaja(IdCaja, IdUsuario);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return 0;
                }
            }
            /////////////////////////////////////Elimino caja
            queryString = "DELETE FROM [dbo].[CajaAhorro] WHERE ID=@id";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters["@id"].Value = IdCaja;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int agregarPlazoFijo(int IdUsuario, float Monto, DateTime FechaFin, float Tasa, int IdCajaAhorro, bool Pagado = false, int IdBanco = 1)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevaCaja = -1;
            string queryString = "INSERT INTO [dbo].[PlazoFijo] ([id_usuario],[monto],[fecha_ini],[fecha_fin],[tasa],[pagado],[id_banco],[id_caja_ahorro]) VALUES (@id_usuario, @monto, @fecha_ini, @fecha_fin, @tasa, @pagado, @id_banco, @id_caja_ahorro);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@monto", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@fecha_ini", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@fecha_fin", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@tasa", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@pagado", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@id_banco", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@id_caja_ahorro", SqlDbType.NVarChar));
                command.Parameters["@id_usuario"].Value = IdUsuario;
                command.Parameters["@monto"].Value = Monto;
                command.Parameters["@fecha_ini"].Value = DateTime.Now;
                command.Parameters["@fecha_fin"].Value = FechaFin;
                command.Parameters["@tasa"].Value = Tasa;
                command.Parameters["@pagado"].Value = Pagado;
                command.Parameters["@id_banco"].Value = IdBanco;
                command.Parameters["@id_caja_ahorro"].Value = IdCajaAhorro;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                    //***************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[CajaAhorro]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaCaja = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ex.Message: " + ex.Message);
                    return -1;
                }
                return idNuevaCaja;
            }
        }
        public int agregarTarjeta(int Id_usuario, int Numero, int CodigoV, float Limite, float Consumo,int Id_Banco = 1)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idTarjetaNueva = -1;
            string queryString = "INSERT INTO [dbo].[Tarjeta] ([id_usuario],[numero],[codigo_v],[limite],[consumo],[id_banco]) VALUES (@id_usuario,@numero,@codigo_v,@limite,@consumo,@id_banco);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                
                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@numero", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@codigo_v", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@limite", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@consumo", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@id_banco", SqlDbType.Int));
                command.Parameters["@id_usuario"].Value = Id_usuario;
                command.Parameters["@numero"].Value = Numero;
                command.Parameters["@codigo_v"].Value = CodigoV;
                command.Parameters["@limite"].Value = Limite;
                command.Parameters["@consumo"].Value = Consumo;
                command.Parameters["@id_banco"].Value = Id_Banco;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                    //***************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Tarjeta]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idTarjetaNueva = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    return -1;
                }
                return idTarjetaNueva;
            }

         }    
         public int agregarPago(int Id_usuario, string Nombre, float Monto, bool Pagado = false, string Metodo="", int Id_Banco = 1)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int Pago = -1;
            string queryString = "INSERT INTO [dbo].[Pago] ([id_usuario],[nombre],[monto],[pagado],[metodo],[id_banco]) VALUES (@id_usuario,@nombre,@monto,@pagado,@metodo,@id_banco);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add(new SqlParameter("@id_usuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@monto", SqlDbType.Float));
                command.Parameters.Add(new SqlParameter("@pagado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@metodo", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@id_banco", SqlDbType.Int));
               
               
                command.Parameters["@Id_usuario"].Value = Id_usuario;
                command.Parameters["@Nombre"].Value = Nombre;
                command.Parameters["@Monto"].Value = Monto;
                command.Parameters["@Pagado"].Value = Pagado;
                command.Parameters["@Metodo"].Value = Metodo;
                command.Parameters["@Id_banco"].Value = Id_Banco;
                
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                    //***************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Pago]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Pago = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    return -1;
                }
                return Pago;
            }
        }

    }
}

