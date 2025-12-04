using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;
using EsercizioProdotti.Database;

namespace EsercizioProdotti.Repositories
{
    public class ClienteRepository
    {
        private DbConnection connessioneDatabase;

        public ClienteRepository(DbConnection connessioneDatabase)
        {
            this.connessioneDatabase = connessioneDatabase;
        }

        public bool Inserisci(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Cliente (Nome, Email, DataRegistrazione) VALUES (@Nome, @Email, @DataRegistrazione)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@DataRegistrazione", cliente.DataRegistrazione);
                        
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'inserimento del cliente: {ex.Message}");
                return false;
            }
        }

        public List<Cliente> OttieniTutti()
        {
            List<Cliente> clienti = new List<Cliente>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, Nome, Email, DataRegistrazione FROM Cliente";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cliente c = new Cliente(
                                    reader.GetInt32("Id"),
                                    reader.GetString("Nome"),
                                    reader.GetString("Email"),
                                    reader.GetString("DataRegistrazione")
                                );
                                clienti.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura dei clienti: {ex.Message}");
            }
            return clienti;
        }

        public Cliente? OttieniPerId(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, Nome, Email, DataRegistrazione FROM Cliente WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Cliente(
                                    reader.GetInt32("Id"),
                                    reader.GetString("Nome"),
                                    reader.GetString("Email"),
                                    reader.GetString("DataRegistrazione")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la ricerca del cliente: {ex.Message}");
            }
            return null;
        }

        public bool Aggiorna(Cliente cliente)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Cliente SET Nome = @Nome, Email = @Email, DataRegistrazione = @DataRegistrazione WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", cliente.Id);
                        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@DataRegistrazione", cliente.DataRegistrazione);
                        
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'aggiornamento del cliente: {ex.Message}");
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
                    string query = "DELETE FROM Cliente WHERE Id = @Id";
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
                Console.WriteLine($"Errore durante l'eliminazione del cliente: {ex.Message}");
                return false;
            }
        }
    }
}