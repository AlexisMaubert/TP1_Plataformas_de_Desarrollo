﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader.GetString(5).Trim(), reader.GetInt32(6), reader.GetBoolean(7), reader.GetInt32(8),reader.GetBoolean(9));
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

        //public List<Usuario> traerDatos()
        //{
        //    List<Usuario> misdatos = new List<Usuario>();

        //    //Defino el string con la consulta que quiero realizar
        //    string queryString = "select nombre, apellido, dni, mail, password from usuario;";
        //    //string queryString = "select id, nombre, apellido, dni, mail, password from usuario;";


        //    // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
        //    using (SqlConnection connection =
        //        new SqlConnection(connectionString))
        //    {
        //        // Defino el comando a enviar al motor SQL con la consulta y la conexión
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        try
        //        {
        //            //Abro la conexión
        //            connection.Open();
        //            //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
        //            SqlDataReader reader = command.ExecuteReader();
        //            Usuario aux;
        //            //mientras haya registros/filas en mi DataReader, sigo leyendo
        //            while (reader.Read())
        //            {
        //                aux = new Usuario(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
        //                misUsuarios.Add(aux);
        //            }
        //            //En este punto ya recorrí todas las filas del resultado de la query
        //            reader.Close();

        //            //YA cargué todos los domicilios, sólo me resta vincular
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return misUsuarios;
        //}

    }
}
