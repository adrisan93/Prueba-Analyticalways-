using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;


namespace Prueba
{
    class Insertar
    {
        Conectar conectar = new Conectar();

        //Metodo para comprobar si en la tabla Stock hay registros previamente cargado.
        //El metodo devuelve TRUE en caso de que tenga registros y FALSE en caso de que esté vacía
        public bool ConsultarTabla()
        {
            //Hacemos consulta para ver si hay registros en la tabla Stock
            String sql_consulta = "SELECT COUNT(*) FROM Stock";
            SqlCommand cmd_consulta = new SqlCommand(sql_consulta, conectar.getConexion());
            cmd_consulta.ExecuteNonQuery();
            int count = Convert.ToInt32(cmd_consulta.ExecuteScalar());
            if (count == 0)
                return false; 
            else
                return true;
        }

        //Método para limpiar la tabla Stock
        //El método devuelve el número de filas afectadas
        public int LimpiarTabla()
        {
            //Borramos registros para dejar tabla vacía
            String sql_borrar = "TRUNCATE TABLE Stock";
            SqlCommand cmd_borrar = new SqlCommand(sql_borrar, conectar.getConexion());
            return cmd_borrar.ExecuteNonQuery();
            
        }

        // Metodo encargado de insertar elementos en la tabla Stock previamente creada
        //El método devuelve TRUE en caso de que la insercción se realice correctamente y FALSE en caso contrario
        public bool InsertarDatos(String PointOfSale, String Product, String Date, String Stock)
        {   
            try
            {
                //Insertamos valores recibidos como argumentos de la función previamente leidos del fichero CSV
                String sql_insertar = "INSERT INTO Stock VALUES ('" + PointOfSale + "', '" + Product + "', '" + Date + "', '" + Stock + "')";
                SqlCommand cmd_insertar = new SqlCommand(sql_insertar, conectar.getConexion());
                int n = cmd_insertar.ExecuteNonQuery();
                return n > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
