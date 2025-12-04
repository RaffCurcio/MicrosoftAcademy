using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;

namespace EsercizioProdotti.Views
{
    public class ClienteView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("\n=== Menu Clienti ===");
            Console.WriteLine("1. Visualizza tutti i clienti");
            Console.WriteLine("2. Aggiungi cliente");
            Console.WriteLine("3. Modifica cliente");
            Console.WriteLine("4. Elimina cliente");
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

        public void DisplayClienti(List<Cliente> clienti)
        {
            Console.WriteLine("\n===== Elenco Clienti =====");
            if (clienti.Count == 0)
            {
                Console.WriteLine("Nessun cliente trovato.");
            }
            else
            {
                foreach (var c in clienti)
                {
                    Console.WriteLine(c);
                }
            }
        }

        public void DisplayCliente(Cliente cliente)
        {
            Console.WriteLine("\n" + cliente.ToString());
        }

        public Cliente GetClienteInput()
        {
            Console.WriteLine("\n=== Nuovo Cliente ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
            
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            
            string dataRegistrazione = DateTime.Now.ToString("yyyy-MM-dd");
            
            return new Cliente(0, nome, email, dataRegistrazione);
        }

        public Cliente GetClienteUpdateInput(int id)
        {
            Console.WriteLine("\n=== Modifica Cliente ===");
            Console.Write("Nuovo Nome: ");
            string nome = Console.ReadLine() ?? "";
            
            Console.Write("Nuova Email: ");
            string email = Console.ReadLine() ?? "";
            
            Console.Write("Data Registrazione (yyyy-MM-dd): ");
            string dataRegistrazione = Console.ReadLine() ?? "";
            
            return new Cliente(id, nome, email, dataRegistrazione);
        }

        public int GetClienteId(string message)
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
            Console.Write("Sei sicuro di voler eliminare questo cliente? (s/n): ");
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