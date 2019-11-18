
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Prueba
{
    class Program
    {

        static void Main(string[] args)
        {
            Insertar insertar = new Insertar();
            Program programa = new Program();

            try
            {
                //Descargamos fichero CSV
                System.Console.WriteLine("Descargando fichero...");
                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://interview2208.blob.core.windows.net/interview/Stock.CSV?st=2019-08-22T08%3A44%3A29Z&se=2019-12-31T21%3A59%3A00Z&sp=rl&sv=2018-03-28&sr=b&sig=5pSTVUKmUcoCrROqlzNcoV4po6t6R4h5QwU0QXMuBgc%3D", "data.csv");
                System.Console.WriteLine("Fichero descargado con exito!");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Problema al descargar fichero: " + ex.Message);
            }

            try
            {
               
                //Leemos los datos del fichero y los escribimos por consola
                String st = File.ReadAllText("data.csv");
                Console.WriteLine(st);

                //Escribimos registros en la base de datos
                System.Console.WriteLine("Escribiendo registros en Base de datos...");
                //Leemos fichero CSV y almacenamos cada una de las lineas en un Array
                String[] lineas = File.ReadAllLines("data.csv");
                
                //Si la tabla contiene registros, la limpiamos
                if (insertar.ConsultarTabla())
                {
                    insertar.LimpiarTabla();
                }
                //Inicializamos contador a 0
                int contador = 0;
                foreach (var linea in lineas)
                {
                    //Solo insertaremos datos en la base de datos cuando el contador sea mayor que 0 para asi evitar escribir la cabecera del fichero CSV
                    if (contador > 0)
                    {
                        var valores = linea.Split(';'); //Cada linea tiene 4 columnas y se separan por ;
                        insertar.InsertarDatos(valores[0], valores[1], valores[2], valores[3]); // Insertamos valores leidos
                    }
                    contador++;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Problema al leer: " + ex.Message);
            }

        }
    }
}

