using System;
using EsercizioProdotti.Database;
using EsercizioProdotti.Repositories;
using EsercizioProdotti.Controllers;
using EsercizioProdotti.Views;
using EsercizioProdotti.Models;

namespace EsercizioProdotti
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inizializzazione connessione al DB
            DbConnection connessioneDb = DbConnection.Instance;
            connessioneDb.TestConnection();

            // Inizializzazione Repositories
            ProdottoRepository repositoryProdotto = new ProdottoRepository(connessioneDb);
            ClienteRepository repositoryCliente = new ClienteRepository(connessioneDb);
            CittaRepository repositoryCitta = new CittaRepository(connessioneDb);
            PuntoVenditaRepository repositoryPuntoVendita = new PuntoVenditaRepository(connessioneDb);

            // Inizializzazione Views Generiche
            ViewGenerica<Prodotto> vistaProdotto = new ViewGenerica<Prodotto>("Prodotti");
            ViewGenerica<Cliente> vistaCliente = new ViewGenerica<Cliente>("Clienti");
            ViewGenerica<Citta> vistaCitta = new ViewGenerica<Citta>("Città");
            ViewGenerica<PuntoVendita> vistaPuntoVendita = new ViewGenerica<PuntoVendita>("Punti Vendita");

            // Inizializzazione Controllers
            ProdottoController controllerProdotto = new ProdottoController(repositoryProdotto, vistaProdotto);
            ClienteController controllerCliente = new ClienteController(repositoryCliente, vistaCliente);
            CittaController controllerCitta = new CittaController(repositoryCitta, vistaCitta);
            PuntoVenditaController controllerPuntoVendita = new PuntoVenditaController(repositoryPuntoVendita, repositoryCitta, vistaPuntoVendita, vistaCitta);

            // Menu principale
            bool esci = false;
            while (!esci)
            {
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║      MENU PRINCIPALE GESTIONE      ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.WriteLine("1. Gestione Prodotti");
                Console.WriteLine("2. Gestione Clienti");
                Console.WriteLine("3. Gestione Città");
                Console.WriteLine("4. Gestione Punti Vendita");
                Console.WriteLine("5. Esci");
                Console.Write("\nSeleziona un'opzione: ");

                try
                {
                    int scelta = int.Parse(Console.ReadLine() ?? "0");

                    switch (scelta)
                    {
                        case 1:
                            controllerProdotto.Esegui();
                            break;
                        case 2:
                            controllerCliente.Esegui();
                            break;
                        case 3:
                            controllerCitta.Esegui();
                            break;
                        case 4:
                            controllerPuntoVendita.Esegui();
                            break;
                        case 5:
                            esci = true;
                            Console.WriteLine("\n👋 Arrivederci!");
                            break;
                        default:
                            Console.WriteLine("\n❌ Opzione non valida. Riprova.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\n❌ Input non valido. Inserisci un numero.");
                }
            }
        }
    }
}
