using System;
using System.Collections.Generic;
using EsercizioProdotti.Models;

namespace EsercizioProdotti.Views
{
    public class ProdottoView
    {
        public void MostraMenuPrincipale()
        {
            Console.WriteLine("\n===== GESTIONE PRODOTTI =====");
            Console.WriteLine("1. Visualizza tutti i prodotti");
            Console.WriteLine("2. Cerca prodotto per ID");
            Console.WriteLine("3. Aggiungi nuovo prodotto");
            Console.WriteLine("4. Aggiorna prodotto");
            Console.WriteLine("5. Elimina prodotto");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");
        }

        public void MostraElencoProdotti(List<Prodotto> prodotti)
        {
            Console.WriteLine("\n===== ELENCO PRODOTTI =====");
            if (prodotti.Count == 0)
            {
                Console.WriteLine("Nessun prodotto trovato.");
            }
            else
            {
                foreach (var p in prodotti)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public void MostraProdotto(Prodotto prodotto)
        {
            if (prodotto != null)
            {
                Console.WriteLine($"\nProdotto trovato: {prodotto}");
            }
            else
            {
                Console.WriteLine("Prodotto non trovato.");
            }
        }

        public int LeggiId(string messaggio)
        {
            Console.Write(messaggio);
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }
            Console.WriteLine("ID non valido.");
            return -1;
        }

        public Prodotto LeggiDatiProdotto()
        {
            Console.WriteLine("\n===== INSERISCI DATI PRODOTTO =====");
            Console.Write("Nome Prodotto: ");
            string nome = Console.ReadLine() ?? "";
            
            Console.Write("Giacenza: ");
            if (!int.TryParse(Console.ReadLine(), out int giacenza))
            {
                Console.WriteLine("Giacenza non valida.");
                return null;
            }

            Console.Write("Prezzo: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal prezzo))
            {
                Console.WriteLine("Prezzo non valido.");
                return null;
            }

            return new Prodotto(nome, giacenza, prezzo);
        }

        public Prodotto LeggiDatiAggiornamento(Prodotto prodottoEsistente)
        {
            Console.WriteLine($"Prodotto attuale: {prodottoEsistente}");
            Console.WriteLine("\n===== AGGIORNA PRODOTTO =====");
            
            Console.Write($"Nuovo nome [{prodottoEsistente.NomeProdotto}]: ");
            string nome = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(nome))
                prodottoEsistente.NomeProdotto = nome;

            Console.Write($"Nuova giacenza [{prodottoEsistente.Giacenza}]: ");
            string giacenzaInput = Console.ReadLine() ?? "";
            if (int.TryParse(giacenzaInput, out int giacenza))
                prodottoEsistente.Giacenza = giacenza;

            Console.Write($"Nuovo prezzo [{prodottoEsistente.Prezzo}]: ");
            string prezzoInput = Console.ReadLine() ?? "";
            if (decimal.TryParse(prezzoInput, out decimal prezzo))
                prodottoEsistente.Prezzo = prezzo;

            return prodottoEsistente;
        }

        public bool ConfermaEliminazione(Prodotto prodotto)
        {
            Console.WriteLine($"Stai per eliminare: {prodotto}");
            Console.Write("Sei sicuro? (s/n): ");
            string conferma = Console.ReadLine()?.ToLower() ?? "";
            return conferma == "s";
        }

        public void MostraMessaggio(string messaggio)
        {
            Console.WriteLine(messaggio);
        }

        public string LeggiScelta()
        {
            return Console.ReadLine() ?? "";
        }
    }
}
