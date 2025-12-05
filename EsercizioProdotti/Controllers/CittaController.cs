using EsercizioProdotti.Models;
using EsercizioProdotti.Repositories;
using EsercizioProdotti.Views;
using System;

namespace EsercizioProdotti.Controllers
{
    public class CittaController
    {
        private readonly CittaRepository repositoryCitta;
        private readonly ViewGenerica<Citta> view;

        public CittaController(CittaRepository repositoryCitta, ViewGenerica<Citta> view)
        {
            this.repositoryCitta = repositoryCitta;
            this.view = view;
        }

        public void Esegui()
        {
            bool esci = false;
            while (!esci)
            {
                view.MostraMenu();
                int scelta = view.OttieniSceltaUtente();

                switch (scelta)
                {
                    case 1:
                        VisualizzaTutteCitta();
                        break;
                    case 2:
                        AggiungiCitta();
                        break;
                    case 3:
                        AggiornaCitta();
                        break;
                    case 4:
                        EliminaCitta();
                        break;
                    case 5:
                        esci = true;
                        view.MostraMessaggio("Uscita dal menu città...");
                        break;
                    default:
                        view.MostraOpzioneNonValida();
                        break;
                }
            }
        }

        private void VisualizzaTutteCitta()
        {
            var citta = repositoryCitta.OttieniTutti();
            view.MostraLista(citta);
        }

        private void AggiungiCitta()
        {
            view.MostraTitolo("Nuova Città");
            string nome = view.OttieniInput("Nome");
            string regione = view.OttieniInput("Regione");
            
            Citta citta = new Citta(nome, regione);
            
            if (repositoryCitta.Inserisci(citta))
            {
                view.MostraMessaggio("Città aggiunta con successo!");
            }
            else
            {
                view.MostraMessaggio("Errore durante l'aggiunta della città.");
            }
        }

        private void AggiornaCitta()
        {
            int id = view.OttieniId("Inserisci l'ID della città da modificare: ");
            var citta = repositoryCitta.OttieniPerId(id);
            
            if (citta != null)
            {
                view.MostraElemento(citta);
                
                view.MostraTitolo("Modifica Città");
                string nome = view.OttieniInput("Nuovo Nome");
                string regione = view.OttieniInput("Nuova Regione");
                
                Citta cittaAggiornata = new Citta(id, nome, regione);
                
                if (repositoryCitta.Aggiorna(cittaAggiornata))
                {
                    view.MostraMessaggio("Città aggiornata con successo!");
                }
                else
                {
                    view.MostraMessaggio("Errore durante l'aggiornamento della città.");
                }
            }
            else
            {
                view.MostraMessaggio("Città non trovata.");
            }
        }

        private void EliminaCitta()
        {
            int id = view.OttieniId("Inserisci l'ID della città da eliminare: ");
            var citta = repositoryCitta.OttieniPerId(id);
            
            if (citta != null)
            {
                view.MostraElemento(citta);
                if (view.ConfermaEliminazione())
                {
                    if (repositoryCitta.Elimina(id))
                    {
                        view.MostraMessaggio("Città eliminata con successo!");
                    }
                    else
                    {
                        view.MostraMessaggio("Errore durante l'eliminazione della città.");
                    }
                }
                else
                {
                    view.MostraMessaggio("Operazione annullata.");
                }
            }
            else
            {
                view.MostraMessaggio("Città non trovata.");
            }
        }
    }
}
