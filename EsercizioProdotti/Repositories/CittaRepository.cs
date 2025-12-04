using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;
using EsercizioProdotti.Database;

namespace EsercizioProdotti.Repositories
{
    public class CittaRepository
    {
        private DbConnection connessioneDatabase;

        public CittaRepository(DbConnection connessioneDatabase)
        {
            this.connessioneDatabase = connessioneDatabase;
        }

        public bool Inserisci(Citta citta)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Citta (Nome, Regione) VALUES (@Nome, @Regione)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", citta.Nome);
                        cmd.Parameters.AddWithValue("@Regione", citta.Regione);
                        
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'inserimento della città: {ex.Message}");
                return false;
            }
        }

        public List<Citta> OttieniTutti()
        {
            List<Citta> citta = new List<Citta>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, Nome, Regione FROM Citta";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Citta c = new Citta(
                                    reader.GetInt32("Id"),
                                    reader.GetString("Nome"),
                                    reader.GetString("Regione")
                                );
                                citta.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura delle città: {ex.Message}");
            }
            return citta;
        }

        public Citta? OttieniPerId(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, Nome, Regione FROM Citta WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Citta(
                                    reader.GetInt32("Id"),
                                    reader.GetString("Nome"),
                                    reader.GetString("Regione")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la ricerca della città: {ex.Message}");
            }
            return null;
        }

        public bool Aggiorna(Citta citta)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Citta SET Nome = @Nome, Regione = @Regione WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", citta.Id);
                        cmd.Parameters.AddWithValue("@Nome", citta.Nome);
                        cmd.Parameters.AddWithValue("@Regione", citta.Regione);
                        
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'aggiornamento della città: {ex.Message}");
                return false;
            }
        }

        public bool Elimina(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Citta WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'eliminazione della città: {ex.Message}");
                return false;
            }
        }
    }
}
