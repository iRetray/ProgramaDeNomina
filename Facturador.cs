using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProgramaDeFactoracion
{
    public class Facturador
    {
        List<Producto> listaProductos = new List<Producto>();


        public void añadirProducto( Producto newProducto ){
            listaProductos.Add(newProducto);
        }

        public List<Producto> obtenerProductos() {
            return listaProductos;
        }

        public void conectarSQL(){
            Console.WriteLine("Prueba de texto");
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=test;";
            string query = "SELECT * FROM usuarios";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nameDB = reader.GetString(1);
                        Console.WriteLine(nameDB);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron datos.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                Console.WriteLine(ex.Message);  
            }
        }
    }
}
