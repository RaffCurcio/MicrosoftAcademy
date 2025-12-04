using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;

namespace EsercizioProdotti.Views
{
    public class PuntoVenditaView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\n=== Menu Punti Vendita ===");
            Console.WriteLine("1. Visualizza tutti i punti vendita");
            Console.WriteLine("2. Aggiungi punto vendita");
            Console.WriteLine("3. Modifica punto vendita");
            Console.WriteLine("4. Elimina punto vendita");
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

        public void DisplayPuntiVendita(List<PuntoVendita> puntiVendita)
        {
            Console.WriteLine("\n===== Elenco Punti Vendita =====");
            if (puntiVendita.Count == 0)
            {
                Console.WriteLine("Nessun punto vendita trovato.");
            }
            else
            {
                foreach (var pv in puntiVendita)
                {
                    Console.WriteLine(pv);
                }
            }
        }

        public void DisplayPuntoVendita(PuntoVendita puntoVendita)
        {
            Console.WriteLine("\n" + puntoVendita.ToString());
        }

        public void DisplayCittaDisponibili(List<Citta> citta)
        {
            Console.WriteLine("\n===== Città Disponibili =====");
            foreach (var c in citta)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
        }

        public PuntoVendita GetPuntoVenditaInput(int idCitta)
        {
            Console.WriteLine("\n=== Nuovo Punto Vendita ===");
            Console.Write("Ragione Sociale: ");
            string ragioneSociale = Console.ReadLine() ?? "";
            
            Console.Write("Telefono: ");
            string telefono = Console.ReadLine() ?? "";
            
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            
            Console.Write("Indirizzo: ");
            string indirizzo = Console.ReadLine() ?? "";
            
            return new PuntoVendita(ragioneSociale, telefono, email, indirizzo, idCitta);
        }

        public PuntoVendita GetPuntoVenditaUpdateInput(int id, int idCitta)
        {
            Console.WriteLine("\n=== Modifica Punto Vendita ===");
            Console.Write("Nuova Ragione Sociale: ");
            string ragioneSociale = Console.ReadLine() ?? "";
            
            Console.Write("Nuovo Telefono: ");
            string telefono = Console.ReadLine() ?? "";
            
            Console.Write("Nuova Email: ");
            string email = Console.ReadLine() ?? "";
            
            Console.Write("Nuovo Indirizzo: ");
            string indirizzo = Console.ReadLine() ?? "";
            
            return new PuntoVendita(id, ragioneSociale, telefono, email, indirizzo, idCitta);
        }

        public int GetPuntoVenditaId(string message)
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
            Console.Write("Sei sicuro di voler eliminare questo punto vendita? (s/n): ");
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
