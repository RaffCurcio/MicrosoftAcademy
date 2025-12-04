using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;

namespace EsercizioProdotti.Views
{
    public class CittaView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\n=== Menu Città ===");
            Console.WriteLine("1. Visualizza tutte le città");
            Console.WriteLine("2. Aggiungi città");
            Console.WriteLine("3. Modifica città");
            Console.WriteLine("4. Elimina città");
            Console.WriteLine("5. Esci");
            Console.Write("Seleziona un'opzione: ");
        }

        public int GetUserChoice()
        {
            try
            {
                return int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                return 0;
            }
        }

        public void DisplayCitta(List<Citta> citta)
        {
            Console.WriteLine("\n===== Elenco Città =====");
            if (citta.Count == 0)
            {
                Console.WriteLine("Nessuna città trovata.");
            }
            else
            {
                foreach (var c in citta)
                {
                    Console.WriteLine(c);
                }
            }
        }

        public void DisplayCittaSingola(Citta citta)
        {
            Console.WriteLine("\n" + citta.ToString());
        }

        public Citta GetCittaInput()
        {
            Console.WriteLine("\n=== Nuova Città ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
            
            Console.Write("Regione: ");
            string regione = Console.ReadLine() ?? "";
            
            return new Citta(nome, regione);
        }

        public Citta GetCittaUpdateInput(int id)
        {
            Console.WriteLine("\n=== Modifica Città ===");
            Console.Write("Nuovo Nome: ");
            string nome = Console.ReadLine() ?? "";
            
            Console.Write("Nuova Regione: ");
            string regione = Console.ReadLine() ?? "";
            
            return new Citta(id, nome, regione);
        }

        public int GetCittaId(string message)
        {
            Console.Write(message);
            try
            {
                return int.Parse(Console.ReadLine() ?? "0");
            }
            catch
            {
                return 0;
            }
        }

        public bool ConfirmDelete()
        {
            Console.Write("Sei sicuro di voler eliminare questa città? (s/n): ");
            string response = Console.ReadLine()?.ToLower() ?? "n";
            return response == "s" || response == "si";
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayInvalidOption()
        {
            Console.WriteLine("Opzione non valida. Riprova.");
        }
    }
}
