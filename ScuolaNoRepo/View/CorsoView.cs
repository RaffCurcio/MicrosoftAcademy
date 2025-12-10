using System;
using ScuolaNoRepo.Controller;
using ScuolaNoRepo.Model;
using System.Collections.Generic;

namespace ScuolaNoRepo.View
{
    public class CorsoView
    {
        private CorsoController corsoController = new CorsoController();

        public void ShowMenu()
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestione Corsi");
                Console.WriteLine("1. Aggiungi Corso");
                Console.WriteLine("2. Visualizza Corsi");
                Console.WriteLine("0. Esci");
                Console.Write("Seleziona un'opzione: ");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiCorso();
                        break;
                    case "2":
                        VisualizzaCorsi();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida. Premi un tasto per continuare...");
                        Console.ReadKey();
                        break;
                }
            } while (!exit);
        }

        public void AggiungiCorso()
        {
            Console.Clear();
            Console.WriteLine("Aggiungi Nuovo Corso\n");
            Corso nuovoCorso = new Corso();
            Console.Write("Nome del Corso: ");
            nuovoCorso.Nome = Console.ReadLine();
            Console.Write("Codice ID del Corso: ");
            nuovoCorso.codiceId = Console.ReadLine();
            corsoController.AddCorso(nuovoCorso);
            Console.WriteLine("\nCorso aggiunto con successo! Premi un tasto per tornare al menu...");
            Console.ReadKey();
        }
        public void VisualizzaCorsi()
        {
            Console.Clear();
            Console.WriteLine("Lista Corsi\n");

            List<Corso> lista = corsoController.GetAll();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nessun corso presente nel database.");
            }
            else
            {
                foreach (var corso in lista)
                {
                    Console.WriteLine($"ID: {corso.Id}, Nome: {corso.Nome}");
                }
            }

            Console.WriteLine("\nPremi un tasto per tornare al menu...");
            Console.ReadKey();
        }
    }
}