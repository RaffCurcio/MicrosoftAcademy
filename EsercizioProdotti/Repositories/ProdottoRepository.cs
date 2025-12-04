using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;
using EsercizioProdotti.Database;

namespace EsercizioProdotti.Repositories
{
    public class ProdottoRepository
    {
        private DbConnection connessioneDatabase;

        public ProdottoRepository(DbConnection connessioneDatabase)
        {
            this.connessioneDatabase = connessioneDatabase;
        }
        public bool Inserisci(Prodotto prodotto)
        {
            try
            {
                using (MySqlConnection connessione = connessioneDatabase.GetConnection())tConnection())
                {
                    connessione.Open();
                    string query = "INSERT INTO Prodotto (NomeProdotto, Giacenza, Prezzo) VALUES (@NomeProdotto, @Giacenza, @Prezzo)";
                    using (MySqlCommand comando = new MySqlCommand(query, connessione))
                    {
                        comando.Parameters.AddWithValue("@NomeProdotto", prodotto.NomeProdotto);
                        comando.Parameters.AddWithValue("@Giacenza", prodotto.Giacenza);
                        comando.Parameters.AddWithValue("@Prezzo", prodotto.Prezzo);
                        
                        int risultato = comando.ExecuteNonQuery();
                        return risultato > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'inserimento: {ex.Message}");
                return false;
            }
        }
        public List<Prodotto> OttieniTutti()
        {
            List<Prodotto> prodotti = new List<Prodotto>();
            try
            {
                using (MySqlConnection connessione = connessioneDatabase.GetConnection())
                {
                    connessione.Open();
                    string query = "SELECT Id, NomeProdotto, Giacenza, Prezzo FROM Prodotto";
                    using (MySqlCommand comando = new MySqlCommand(query, connessione))
                    {
                        using (MySqlDataReader lettore = comando.ExecuteReader())er())
                        {
                            while (lettore.Read())
                            {
                                Prodotto prodotto = new Prodotto(
                                    lettore.GetInt32("Id"),
                                    lettore.GetString("NomeProdotto"),
                                    lettore.GetInt32("Giacenza"),
                                    lettore.GetDecimal("Prezzo")
                                );
                                prodotti.Add(prodotto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura: {ex.Message}");
            }
            return prodotti;
        }

        public Prodotto? OttieniPerId(int id)
        {
            try
            {
                using (MySqlConnection connessione = connessioneDatabase.GetConnection())
                {
                    connessione.Open();
                    string query = "SELECT Id, NomeProdotto, Giacenza, Prezzo FROM Prodotto WHERE Id = @Id";
                    using (MySqlCommand comando = new MySqlCommand(query, connessione))
                    {
                        comando.Parameters.AddWithValue("@Id", id);
                        using (MySqlDataReader lettore = comando.ExecuteReader())er())
                        {
                            if (lettore.Read())
                            {
                                return new Prodotto(
                                    lettore.GetInt32("Id"),
                                    lettore.GetString("NomeProdotto"),
                                    lettore.GetInt32("Giacenza"),
                                    lettore.GetDecimal("Prezzo")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la ricerca: {ex.Message}");
            }
            return null;
        }

        public bool Aggiorna(Prodotto prodotto)
        {
            try
            {
                using (MySqlConnection connessione = connessioneDatabase.GetConnection())
                {
                    connessione.Open();
                    string query = "UPDATE Prodotto SET NomeProdotto = @NomeProdotto, Giacenza = @Giacenza, Prezzo = @Prezzo WHERE Id = @Id";
                    using (MySqlCommand comando = new MySqlCommand(query, connessione))
                    {
                        comando.Parameters.AddWithValue("@Id", prodotto.Id);
                        comando.Parameters.AddWithValue("@NomeProdotto", prodotto.NomeProdotto);
                        comando.Parameters.AddWithValue("@Giacenza", prodotto.Giacenza);
                        comando.Parameters.AddWithValue("@Prezzo", prodotto.Prezzo);
                        
                        int risultato = comando.ExecuteNonQuery();
                        return risultato > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'aggiornamento: {ex.Message}");
                return false;
            }
        }

        public bool Elimina(int id)
        {
            try
            {
                using (MySqlConnection connessione = connessioneDatabase.GetConnection())
                {
                    connessione.Open();
                    string query = "DELETE FROM Prodotto WHERE Id = @Id";
                    using (MySqlCommand comando = new MySqlCommand(query, connessione))
                    {
                        comando.Parameters.AddWithValue("@Id", id);
                        int risultato = comando.ExecuteNonQuery();
                        return risultato > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'eliminazione: {ex.Message}");
                return false;
            }
        }
    }
}
