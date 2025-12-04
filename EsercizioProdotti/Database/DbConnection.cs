using MySql.Data.MySqlClient;
using System;

namespace EsercizioProdotti.Database
{
    public sealed class DbConnection
    {
        private static DbConnection instance;


        public static DbConnection Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DbConnection();
                }
                return instance;
            }
        }

        private DbConnection() { }

        private string connectionString = "Server=localhost;Database=PuntiVendita;User=root;Password=Password123;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void SetConnectionString(string newConnectionString)
        {
            connectionString = newConnectionString;
        }

        public void TestConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connessione al database PuntiVendita riuscita!");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella connessione: {ex.Message}");
            }
        }
    }
}
