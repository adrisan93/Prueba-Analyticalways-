using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Prueba
{
    class Conectar
    {
        //Método para conectarnos a la base de datos creada en Local (Ejercicio)
        public SqlConnection getConexion()
        {
            try
            {
                //Definimos la cadena para conectarnos a la base de datos (Ejercicio)
                String cadena = "Data Source=user-pc;Initial Catalog=Ejercicio;Integrated Security=True";
                SqlConnection con = new SqlConnection(cadena);
                con.Open(); // Abrimos conexión con base de datos
                return con;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
