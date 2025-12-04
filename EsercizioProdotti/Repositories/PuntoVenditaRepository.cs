using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;
using EsercizioProdotti.Database;

namespace EsercizioProdotti.Repositories
{
    public class PuntoVenditaRepository
    {
        private DbConnection connessioneDatabase;

        public PuntoVenditaRepository(DbConnection connessioneDatabase)
        {
            this.connessioneDatabase = connessioneDatabase;
        }

        public bool Inserisci(PuntoVendita puntoVendita)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO PuntoVendita (RagioneSociale, Telefono, Email, Indirizzo, IdCitta) VALUES (@RagioneSociale, @Telefono, @Email, @Indirizzo, @IdCitta)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RagioneSociale", puntoVendita.RagioneSociale);
                        cmd.Parameters.AddWithValue("@Telefono", puntoVendita.Telefono);
                        cmd.Parameters.AddWithValue("@Email", puntoVendita.Email);
                        cmd.Parameters.AddWithValue("@Indirizzo", puntoVendita.Indirizzo);
                        cmd.Parameters.AddWithValue("@IdCitta", puntoVendita.IdCitta);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'inserimento del punto vendita: {ex.Message}");
                return false;
            }
        }

        public List<PuntoVendita> OttieniTutti()
        {
            List<PuntoVendita> puntiVendita = new List<PuntoVendita>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, RagioneSociale, Telefono, Email, Indirizzo, IdCitta FROM PuntoVendita";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PuntoVendita pv = new PuntoVendita(
                                    reader.GetInt32("Id"),
                                    reader.GetString("RagioneSociale"),
                                    reader.GetString("Telefono"),
                                    reader.GetString("Email"),
                                    reader.GetString("Indirizzo"),
                                    reader.GetInt32("IdCitta")
                                );
                                puntiVendita.Add(pv);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura dei punti vendita: {ex.Message}");
            }
            return puntiVendita;
        }

        public PuntoVendita? OttieniPerId(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, RagioneSociale, Telefono, Email, Indirizzo, IdCitta FROM PuntoVendita WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new PuntoVendita(
                                    reader.GetInt32("Id"),
                                    reader.GetString("RagioneSociale"),
                                    reader.GetString("Telefono"),
                                    reader.GetString("Email"),
                                    reader.GetString("Indirizzo"),
                                    reader.GetInt32("IdCitta")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la ricerca del punto vendita: {ex.Message}");
            }
            return null;
        }

        public bool Aggiorna(PuntoVendita puntoVendita)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE PuntoVendita SET RagioneSociale = @RagioneSociale, Telefono = @Telefono, Email = @Email, Indirizzo = @Indirizzo, IdCitta = @IdCitta WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", puntoVendita.Id);
                        cmd.Parameters.AddWithValue("@RagioneSociale", puntoVendita.RagioneSociale);
                        cmd.Parameters.AddWithValue("@Telefono", puntoVendita.Telefono);
                        cmd.Parameters.AddWithValue("@Email", puntoVendita.Email);
                        cmd.Parameters.AddWithValue("@Indirizzo", puntoVendita.Indirizzo);
                        cmd.Parameters.AddWithValue("@IdCitta", puntoVendita.IdCitta);
                        
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'aggiornamento del punto vendita: {ex.Message}");
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
                    string query = "DELETE FROM PuntoVendita WHERE Id = @Id";
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
                Console.WriteLine($"Errore durante l'eliminazione del punto vendita: {ex.Message}");
                return false;
            }
        }
    }
}
