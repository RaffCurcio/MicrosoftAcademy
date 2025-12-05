using System;
using System.Collections.Generic;
using GestioneStudenti.Models;
using GestioneStudenti.Repositories;

namespace GestioneStudenti.Controllers
{
    public class LogController
    {
        private readonly LogRepository logRepository;

        public LogController()
        {
            logRepository = new LogRepository();
        }

        public void MostraMenuLog()
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║           MENU LOG SISTEMA         ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.WriteLine("1. Visualizza tutti i log (ultimi 100)");
                Console.WriteLine("2. Visualizza log per Studenti");
                Console.WriteLine("3. Visualizza log per Professori");
                Console.WriteLine("4. Visualizza log per Corsi di Laurea");
                Console.WriteLine("5. Visualizza solo errori");
                Console.WriteLine("6. Statistiche log");
                Console.WriteLine("0. Torna al menu principale");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        VisualizzaTuttiLog();
                        break;
                    case "2":
                        VisualizzaLogPerEntita("Studente");
                        break;
                    case "3":
                        VisualizzaLogPerEntita("Professore");
                        break;
                    case "4":
                        VisualizzaLogPerEntita("CorsoDiLaurea");
                        break;
                    case "5":
                        VisualizzaSoloErrori();
                        break;
                    case "6":
                        MostraStatistiche();
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }

        private void VisualizzaTuttiLog()
        {
            Console.WriteLine("\n=== TUTTI I LOG (ULTIMI 100) ===");
            var logs = logRepository.OttieniTuttiLog();
            
            if (logs.Count == 0)
            {
                Console.WriteLine("Nessun log trovato.");
                return;
            }

            foreach (var log in logs)
            {
                Console.WriteLine(FormatLogPerVisualizzazione(log));
            }
        }

        private void VisualizzaLogPerEntita(string entita)
        {
            Console.WriteLine($"\n=== LOG PER {entita.ToUpper()} ===");
            var logs = logRepository.OttieniLogPerEntita(entita);
            
            if (logs.Count == 0)
            {
                Console.WriteLine($"Nessun log trovato per {entita}.");
                return;
            }

            foreach (var log in logs)
            {
                Console.WriteLine(FormatLogPerVisualizzazione(log));
            }
        }

        private void VisualizzaSoloErrori()
        {
            Console.WriteLine("\n=== SOLO ERRORI ===");
            var tuttiLog = logRepository.OttieniTuttiLog();
            var errori = tuttiLog.FindAll(l => l.Esito == "ERROR");
            
            if (errori.Count == 0)
            {
                Console.WriteLine("Nessun errore registrato!");
                return;
            }

            foreach (var errore in errori)
            {
                Console.WriteLine(FormatLogPerVisualizzazione(errore));
                if (!string.IsNullOrEmpty(errore.DettagliErrore))
                {
                    Console.WriteLine($"    ↳ Dettagli: {errore.DettagliErrore}");
                }
            }
        }

        private void MostraStatistiche()
        {
            Console.WriteLine("\n=== STATISTICHE LOG ===");
            var logs = logRepository.OttieniTuttiLog();
            
            if (logs.Count == 0)
            {
                Console.WriteLine("Nessun log disponibile per le statistiche.");
                return;
            }

            // Statistiche generali
            int totaleLogs = logs.Count;
            int successi = logs.FindAll(l => l.Esito == "SUCCESS").Count;
            int errori = logs.FindAll(l => l.Esito == "ERROR").Count;

            Console.WriteLine($"Totale operazioni registrate: {totaleLogs}");
            Console.WriteLine($"Successi: {successi} ({(successi * 100.0 / totaleLogs):F1}%)");
            Console.WriteLine($"Errori: {errori} ({(errori * 100.0 / totaleLogs):F1}%)");

            // Statistiche per entità
            Console.WriteLine("\n Operazioni per entità:");
            var entitaCount = new Dictionary<string, int>();
            foreach (var log in logs)
            {
                if (entitaCount.ContainsKey(log.Entita))
                    entitaCount[log.Entita]++;
                else
                    entitaCount[log.Entita] = 1;
            }

            foreach (var kvp in entitaCount)
            {
                Console.WriteLine($"   • {kvp.Key}: {kvp.Value} operazioni");
            }

            // Statistiche per operazioni
            Console.WriteLine("\nOperazioni più frequenti:");
            var operazioniCount = new Dictionary<string, int>();
            foreach (var log in logs)
            {
                if (operazioniCount.ContainsKey(log.Operazione))
                    operazioniCount[log.Operazione]++;
                else
                    operazioniCount[log.Operazione] = 1;
            }

            foreach (var kvp in operazioniCount)
            {
                Console.WriteLine($"   • {kvp.Key}: {kvp.Value} volte");
            }
        }

        private string FormatLogPerVisualizzazione(LogOperazione log)
        {
            string icona = log.Esito == "SUCCESS" ? "riuscito" : "non riuscito";
            return $"{icona} [{log.DataOra:dd/MM/yyyy HH:mm:ss}] {log.Operazione} su {log.Entita} - {log.Descrizione}";
        }
    }
}