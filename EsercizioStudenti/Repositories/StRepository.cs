using MySql.Data.MySqlClient;
using System;

namespace GestioneStudenti.Repositories
{
    public class StRepository
    {
        private string connectionString = "Server=localhost;Database=Universita;User=root;Password=Password123;";

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
                    string query = "SELECT COUNT(*) FROM Studente";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        long count = (long)cmd.ExecuteScalar();
                        Console.WriteLine($"Connessione riuscita! Numero di studenti nel DB: {count}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella connessione: {ex.Message}");
            }
        }
    }
}