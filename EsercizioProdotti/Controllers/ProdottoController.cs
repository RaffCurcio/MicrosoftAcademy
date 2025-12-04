using System;
using EsercizioProdotti.Models;
using EsercizioProdotti.Repositories;
using EsercizioProdotti.Views;

namespace EsercizioProdotti.Controllers
{
    public class ProdottoController
    {
        private ProdottoRepository repositoryProdotto;
        private ViewGenerica<Prodotto> vista;

        public ProdottoController(ProdottoRepository repositoryProdotto, ViewGenerica<Prodotto> vista)
        {
            this.repositoryProdotto = repositoryProdotto;
            this.vista = vista;
        }

        public void Esegui()
        {
            bool esci = false;

            while (!esci)
            {
                vista.MostraMenu();
                int scelta = vista.OttieniSceltaUtente();

                switch (scelta)
                {
                    case 1:
                        VisualizzaTuttiProdotti();
                        break;
                    case 2:
                        AggiungiProdotto();
                        break;
                    case 3:
                        AggiornaProdotto();
                        break;
                    case 4:
                        EliminaProdotto();
                        break;
                    case 5:
                        esci = true;
                        vista.MostraMessaggio("Uscita dal menu prodotti...");
                        break;
                    default:
                        vista.MostraOpzioneNonValida();
                        break;
                }
            }
        }

        private void VisualizzaTuttiProdotti()
        {
            var prodotti = repositoryProdotto.OttieniTutti();
            vista.MostraLista(prodotti);
        }

        private void AggiungiProdotto()
        {
            vista.MostraTitolo("Nuovo Prodotto");
            string nomeProdotto = vista.OttieniInput("Nome Prodotto");
            
            int giacenza = vista.OttieniId("Giacenza: ");
            
            Console.Write("Prezzo: ");
            decimal prezzo;
            if (!decimal.TryParse(Console.ReadLine(), out prezzo))
            {
                vista.MostraMessaggio("Prezzo non valido.");
                return;
            }

            Prodotto prodotto = new Prodotto(nomeProdotto, giacenza, prezzo);
            
            if (repositoryProdotto.Inserisci(prodotto))
            {
                vista.MostraMessaggio("Prodotto aggiunto con successo!");
            }
            else
            {
                vista.MostraMessaggio("Errore durante l'aggiunta del prodotto.");
            }
        }

        private void AggiornaProdotto()
        {
            int id = vista.OttieniId("Inserisci l'ID del prodotto da modificare: ");
            var prodotto = repositoryProdotto.OttieniPerId(id);
            
            if (prodotto != null)
            {
                vista.MostraElemento(prodotto);
                
                vista.MostraTitolo("Modifica Prodotto");
                string nomeProdotto = vista.OttieniInput("Nuovo Nome Prodotto");
                int giacenza = vista.OttieniId("Nuova Giacenza: ");
                
                Console.Write("Nuovo Prezzo: ");
                decimal prezzo;
                if (!decimal.TryParse(Console.ReadLine(), out prezzo))
                {
                    vista.MostraMessaggio("Prezzo non valido.");
                    return;
                }
                
                Prodotto prodottoAggiornato = new Prodotto(id, nomeProdotto, giacenza, prezzo);
                
                if (repositoryProdotto.Aggiorna(prodottoAggiornato))
                {
                    vista.MostraMessaggio("Prodotto aggiornato con successo!");
                }
                else
                {
                    vista.MostraMessaggio("Errore durante l'aggiornamento del prodotto.");
                }
            }
            else
            {
                vista.MostraMessaggio("Prodotto non trovato.");
            }
        }

        private void EliminaProdotto()
        {
            int id = vista.OttieniId("Inserisci l'ID del prodotto da eliminare: ");
            var prodotto = repositoryProdotto.OttieniPerId(id);
            
            if (prodotto != null)
            {
                vista.MostraElemento(prodotto);
                if (vista.ConfermaEliminazione())
                {
                    if (repositoryProdotto.Elimina(id))
                    {
                        vista.MostraMessaggio("Prodotto eliminato con successo!");
                    }
                    else
                    {
                        vista.MostraMessaggio("Errore durante l'eliminazione del prodotto.");
                    }
                }
                else
                {
                    vista.MostraMessaggio("Operazione annullata.");
                }
            }
            else
            {
                vista.MostraMessaggio("Prodotto non trovato.");
            }
        }
    }
}
