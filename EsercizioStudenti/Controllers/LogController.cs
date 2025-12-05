using System;
using System.Collections.Generic;
using GestioneStudenti.Models;
using GestioneStudenti.Repositories;
using GestioneStudenti.Utilities;

namespace GestioneStudenti.Controllers
{
    public class LogController
    {
        private bool stato = true;

        private int classe = 0;
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

                if (stato)
                {
                    switch (scelta)
                    {
                        case "1":
                                VisualizzaTuttiLog();
                            break;
                        case "2":
                            if(classe == 1){
                                Console.WriteLine("Il logging per la classe Studente è disabilitato.");
                            } else {
                                VisualizzaLogPerEntita("Studente");
                            }
                            break;
                        case "3":
                            if(classe == 2){
                                Console.WriteLine("Il logging per la classe Professore è disabilitato.");
                            } else {
                                VisualizzaLogPerEntita("Professore");
                            }
                            break;
                        case "4":
                            if(classe == 3){
                                Console.WriteLine("Il logging per la classe CorsoDiLaurea è disabilitato.");
                            } else {
                                VisualizzaLogPerEntita("CorsoDiLaurea");
                            }
                            break;
                        case "5":
                            if(stato){
                                VisualizzaSoloErrori();
                            } else {
                                Console.WriteLine("Il sistema di logging è disabilitato.");
                            }
                            break;
                        case "6":
                        if(stato){
                                MostraStatistiche();
                            } else {
                                Console.WriteLine("Il sistema di logging è disabilitato.");
                            }
                            break;
                        case "0":
                            continua = false;
                            break;
                        default:
                            Console.WriteLine("Opzione non valida.");
                            break;
                        
                    }
                } else if (scelta == "0")
                {
                    continua = false;
                }
                else
                {
                    Console.WriteLine("Il sistema di logging è disabilitato.");
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



        //GESTIONE LOG ADMIN
        public void GestisciLog()
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║        GESTIONE LOG ADMIN          ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.WriteLine("1. Abilita log");
                Console.WriteLine("2. Disabilita log");
                Console.WriteLine("3. Disabilita log per classe");
                Console.WriteLine("0. Torna al menu principale");
                Console.Write("\nScegli un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AbilitaLogMenu();
                        break;
                    case "2":
                        DisabilitaLogMenu();
                        break;
                    case "3":
                        //metodo per scegliere la classe
                        classe = ScegliClasse();
                        //disabilitare il log per la classe scelta
                        logRepository.DisabilitaLogPerClasse();
                        Console.WriteLine($"Log disabilitato per la classe {classe}.");
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

        //metodo per scegliere la classe da disabilitare
        private int ScegliClasse()
        {
            Console.WriteLine("\nScegli la classe per disabilitare il log:");
            Console.WriteLine("1. Studente");
            Console.WriteLine("2. Professore");
            Console.WriteLine("3. CorsoDiLaurea");
            Console.Write("Inserisci il numero della classe: ");
            int sceltaClasse;
            while (!int.TryParse(Console.ReadLine(), out sceltaClasse) || sceltaClasse < 1 || sceltaClasse > 3)
            {
                Console.Write("Scelta non valida. Riprova: ");
            }
            return sceltaClasse;
        }

        private void AbilitaLogMenu()
        {
            Console.WriteLine("\nScegli quale log abilitare:");
            Console.WriteLine("1. Log Database");
            Console.WriteLine("2. Log File");
            Console.Write("Scelta: ");
            
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    stato = logRepository.AbilitaLog();
                    Console.WriteLine("Log database abilitato.");
                    break;
                case "2":
                    Logger.Instance.EnableLogging();
                    Console.WriteLine("Log file abilitato.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        private void DisabilitaLogMenu()
        {
            Console.WriteLine("\nScegli quale log disabilitare:");
            Console.WriteLine("1. Log Database");
            Console.WriteLine("2. Log File");
            Console.Write("Scelta: ");
            
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    stato = logRepository.DisabilitaLog();
                    Console.WriteLine("Log database disabilitato.");
                    break;
                case "2":
                    Logger.Instance.DisableLogging();
                    Console.WriteLine("Log file disabilitato.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}