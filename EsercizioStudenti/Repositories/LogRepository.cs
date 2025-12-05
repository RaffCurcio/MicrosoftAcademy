using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using GestioneStudenti.Models;
using System.Data;

namespace GestioneStudenti.Repositories
{
    public class LogRepository
    {
        private readonly string connectionString = "Server=localhost;Database=Universita;User=root;Password=Password123;";

        public void TestConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connessione al database Universita per i log riuscita!");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella connessione per i log: {ex.Message}");
                Console.WriteLine("Suggerimento: Verifica che MySQL sia avviato e che il database 'Universita' esista.");
            }
        }

        public bool InserisciLog(LogOperazione log)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO LogOperazioni 
                        (DataOra, Operazione, Entita, IdEntita, Descrizione, Esito, DettagliErrore) 
                        VALUES 
                        (@DataOra, @Operazione, @Entita, @IdEntita, @Descrizione, @Esito, @DettagliErrore)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DataOra", log.DataOra);
                        command.Parameters.AddWithValue("@Operazione", log.Operazione);
                        command.Parameters.AddWithValue("@Entita", log.Entita);
                        command.Parameters.AddWithValue("@IdEntita", log.IdEntita.HasValue ? (object)log.IdEntita.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Descrizione", log.Descrizione);
                        command.Parameters.AddWithValue("@Esito", log.Esito);
                        command.Parameters.AddWithValue("@DettagliErrore", string.IsNullOrEmpty(log.DettagliErrore) ? (object)DBNull.Value : log.DettagliErrore);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Avviso: Impossibile salvare log nel database: {ex.Message}");
                return false;
            }
        }

        public void LogSuccesso(string operazione, string entita, int? idEntita, string descrizione)
        {
            LogOperazione log = new LogOperazione(operazione, entita, idEntita, descrizione, "SUCCESS");
            InserisciLog(log);
        }

        public void LogErrore(string operazione, string entita, int? idEntita, string descrizione, string dettagliErrore)
        {
            LogOperazione log = new LogOperazione(operazione, entita, idEntita, descrizione, "ERROR", dettagliErrore);
            InserisciLog(log);
        }

        public List<LogOperazione> OttieniTuttiLog()
        {
            List<LogOperazione> logs = new List<LogOperazione>();
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM LogOperazioni ORDER BY DataOra DESC LIMIT 100";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LogOperazione log = new LogOperazione
                                {
                                    Id = reader.GetInt32("Id"),
                                    DataOra = reader.GetDateTime("DataOra"),
                                    Operazione = reader.GetString("Operazione"),
                                    Entita = reader.GetString("Entita"),
                                    IdEntita = reader.IsDBNull("IdEntita") ? null : reader.GetInt32("IdEntita"),
                                    Descrizione = reader.GetString("Descrizione"),
                                    Esito = reader.GetString("Esito"),
                                    DettagliErrore = reader.IsDBNull("DettagliErrore") ? null : reader.GetString("DettagliErrore")
                                };
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura dei log: {ex.Message}");
            }

            return logs;
        }

        public List<LogOperazione> OttieniLogPerEntita(string entita)
        {
            List<LogOperazione> logs = new List<LogOperazione>();
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM LogOperazioni WHERE Entita = @Entita ORDER BY DataOra DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Entita", entita);
                        
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LogOperazione log = new LogOperazione
                                {
                                    Id = reader.GetInt32("Id"),
                                    DataOra = reader.GetDateTime("DataOra"),
                                    Operazione = reader.GetString("Operazione"),
                                    Entita = reader.GetString("Entita"),
                                    IdEntita = reader.IsDBNull("IdEntita") ? null : reader.GetInt32("IdEntita"),
                                    Descrizione = reader.GetString("Descrizione"),
                                    Esito = reader.GetString("Esito"),
                                    DettagliErrore = reader.IsDBNull("DettagliErrore") ? null : reader.GetString("DettagliErrore")
                                };
                                logs.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura dei log per entità: {ex.Message}");
            }

            return logs;
        }

        public void CreaTabellaSeDNonEsiste()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Verifica se la tabella esiste già
                    string checkTableQuery = "SHOW TABLES LIKE 'LogOperazioni'";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkTableQuery, connection))
                    {
                        var result = checkCommand.ExecuteScalar();
                        if (result != null)
                        {
                            Console.WriteLine("Tabella LogOperazioni già esistente.");
                            return;
                        }
                    }
                    
                    string createTableQuery = @"
                        CREATE TABLE LogOperazioni (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            DataOra DATETIME NOT NULL,
                            Operazione VARCHAR(50) NOT NULL,
                            Entita VARCHAR(50) NOT NULL,
                            IdEntita INT NULL,
                            Descrizione TEXT NOT NULL,
                            Esito ENUM('SUCCESS', 'ERROR') NOT NULL,
                            DettagliErrore TEXT NULL
                        )";

                    using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tabella LogOperazioni creata con successo!");
                        
                        LogSuccesso("SYSTEM_INIT", "Sistema", null, "Sistema di logging inizializzato con successo");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la creazione della tabella log: {ex.Message}");
                Console.WriteLine("Il sistema continuerà a funzionare senza logging su database.");
            }
        }

        public bool AbilitaLog()
        {
            return true;
        }
        public bool DisabilitaLog()
        {
            return false;
        }
        public bool DisabilitaLogPerClasse()
        {
            return true;
        }
    }
}