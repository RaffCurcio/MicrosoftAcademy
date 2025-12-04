using EsercizioProdotti.Models;
using EsercizioProdotti.Repositories;
using EsercizioProdotti.Views;
using System;

namespace EsercizioProdotti.Controllers
{
    public class CittaController
    {
        private readonly CittaRepository repositoryCitta;
        private readonly ViewGenerica<Citta> vista;

        public CittaController(CittaRepository repositoryCitta, ViewGenerica<Citta> vista)
        {
            this.repositoryCitta = repositoryCitta;
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
                        vista.MostraMessaggio("Uscita dal menu città...");
                        break;
                    default:
                        vista.MostraOpzioneNonValida();
                        break;
                }
            }
        }

        private void VisualizzaTutteCitta()
        {
            var citta = repositoryCitta.OttieniTutti();
            vista.MostraLista(citta);
        }

        private void AggiungiCitta()
        {
            vista.MostraTitolo("Nuova Città");
            string nome = vista.OttieniInput("Nome");
            string regione = vista.OttieniInput("Regione");
            
            Citta citta = new Citta(nome, regione);
            
            if (repositoryCitta.Inserisci(citta))
            {
                vista.MostraMessaggio("Città aggiunta con successo!");
            }
            else
            {
                vista.MostraMessaggio("Errore durante l'aggiunta della città.");
            }
        }

        private void AggiornaCitta()
        {
            int id = vista.OttieniId("Inserisci l'ID della città da modificare: ");
            var citta = repositoryCitta.OttieniPerId(id);
            
            if (citta != null)
            {
                vista.MostraElemento(citta);
                
                vista.MostraTitolo("Modifica Città");
                string nome = vista.OttieniInput("Nuovo Nome");
                string regione = vista.OttieniInput("Nuova Regione");
                
                Citta cittaAggiornata = new Citta(id, nome, regione);
                
                if (repositoryCitta.Aggiorna(cittaAggiornata))
                {
                    vista.MostraMessaggio("Città aggiornata con successo!");
                }
                else
                {
                    vista.MostraMessaggio("Errore durante l'aggiornamento della città.");
                }
            }
            else
            {
                vista.MostraMessaggio("Città non trovata.");
            }
        }

        private void EliminaCitta()
        {
            int id = vista.OttieniId("Inserisci l'ID della città da eliminare: ");
            var citta = repositoryCitta.OttieniPerId(id);
            
            if (citta != null)
            {
                vista.MostraElemento(citta);
                if (vista.ConfermaEliminazione())
                {
                    if (repositoryCitta.Elimina(id))
                    {
                        vista.MostraMessaggio("Città eliminata con successo!");
                    }
                    else
                    {
                        vista.MostraMessaggio("Errore durante l'eliminazione della città.");
                    }
                }
                else
                {
                    vista.MostraMessaggio("Operazione annullata.");
                }
            }
            else
            {
                vista.MostraMessaggio("Città non trovata.");
            }
        }
    }
}
