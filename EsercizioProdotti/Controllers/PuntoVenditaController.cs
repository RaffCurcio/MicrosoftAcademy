using EsercizioProdotti.Models;
using EsercizioProdotti.Repositories;
using EsercizioProdotti.Views;
using System;

namespace EsercizioProdotti.Controllers
{
    public class PuntoVenditaController
    {
        private readonly PuntoVenditaRepository repositoryPuntoVendita;
        private readonly CittaRepository repositoryCitta;
        private readonly ViewGenerica<PuntoVendita> vista;
        private readonly ViewGenerica<Citta> vistaCitta;

        public PuntoVenditaController(PuntoVenditaRepository repositoryPuntoVendita, CittaRepository repositoryCitta, ViewGenerica<PuntoVendita> vista, ViewGenerica<Citta> vistaCitta)
        {
            this.repositoryPuntoVendita = repositoryPuntoVendita;
            this.repositoryCitta = repositoryCitta;
            this.vista = vista;
            this.vistaCitta = vistaCitta;
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
                        VisualizzaTuttiPuntiVendita();
                        break;
                    case 2:
                        AggiungiPuntoVendita();
                        break;
                    case 3:
                        AggiornaPuntoVendita();
                        break;
                    case 4:
                        EliminaPuntoVendita();
                        break;
                    case 5:
                        esci = true;
                        vista.MostraMessaggio("Uscita dal menu punti vendita...");
                        break;
                    default:
                        vista.MostraOpzioneNonValida();
                        break;
                }
            }
        }

        private void VisualizzaTuttiPuntiVendita()
        {
            var puntiVendita = repositoryPuntoVendita.OttieniTutti();
            vista.MostraLista(puntiVendita);
        }

        private void AggiungiPuntoVendita()
        {
            // Mostra le città disponibili
            var citta = repositoryCitta.OttieniTutti();
            if (citta.Count == 0)
            {
                vista.MostraMessaggio("Nessuna città disponibile. Aggiungi prima una città.");
                return;
            }

            Console.WriteLine("\n===== Città Disponibili =====");
            vistaCitta.MostraLista(citta);
            
            int idCitta = vista.OttieniId("Seleziona l'ID della città: ");

            // Verifica che la città esista
            var cittaSelezionata = repositoryCitta.OttieniPerId(idCitta);
            if (cittaSelezionata == null)
            {
                vista.MostraMessaggio("Città non trovata.");
                return;
            }

            vista.MostraTitolo("Nuovo Punto Vendita");
            string ragioneSociale = vista.OttieniInput("Ragione Sociale");
            string telefono = vista.OttieniInput("Telefono");
            string email = vista.OttieniInput("Email");
            string indirizzo = vista.OttieniInput("Indirizzo");
            
            PuntoVendita puntoVendita = new PuntoVendita(ragioneSociale, telefono, email, indirizzo, idCitta);
            
            if (repositoryPuntoVendita.Inserisci(puntoVendita))
            {
                vista.MostraMessaggio("Punto vendita aggiunto con successo!");
            }
            else
            {
                vista.MostraMessaggio("Errore durante l'aggiunta del punto vendita.");
            }
        }

        private void AggiornaPuntoVendita()
        {
            int id = vista.OttieniId("Inserisci l'ID del punto vendita da modificare: ");
            var puntoVendita = repositoryPuntoVendita.OttieniPerId(id);
            
            if (puntoVendita != null)
            {
                vista.MostraElemento(puntoVendita);

                // Mostra le città disponibili per cambio città
                var citta = repositoryCitta.OttieniTutti();
                Console.WriteLine("\n===== Città Disponibili =====");
                vistaCitta.MostraLista(citta);
                
                int idCitta = vista.OttieniId("Seleziona l'ID della nuova città: ");

                // Verifica che la città esista
                var cittaSelezionata = repositoryCitta.OttieniPerId(idCitta);
                if (cittaSelezionata == null)
                {
                    vista.MostraMessaggio("Città non trovata.");
                    return;
                }

                vista.MostraTitolo("Modifica Punto Vendita");
                string ragioneSociale = vista.OttieniInput("Nuova Ragione Sociale");
                string telefono = vista.OttieniInput("Nuovo Telefono");
                string email = vista.OttieniInput("Nuova Email");
                string indirizzo = vista.OttieniInput("Nuovo Indirizzo");
                
                PuntoVendita puntoVenditaAggiornato = new PuntoVendita(id, ragioneSociale, telefono, email, indirizzo, idCitta);
                
                if (repositoryPuntoVendita.Aggiorna(puntoVenditaAggiornato))
                {
                    vista.MostraMessaggio("Punto vendita aggiornato con successo!");
                }
                else
                {
                    vista.MostraMessaggio("Errore durante l'aggiornamento del punto vendita.");
                }
            }
            else
            {
                vista.MostraMessaggio("Punto vendita non trovato.");
            }
        }

        private void EliminaPuntoVendita()
        {
            int id = vista.OttieniId("Inserisci l'ID del punto vendita da eliminare: ");
            var puntoVendita = repositoryPuntoVendita.OttieniPerId(id);
            
            if (puntoVendita != null)
            {
                vista.MostraElemento(puntoVendita);
                if (vista.ConfermaEliminazione())
                {
                    if (repositoryPuntoVendita.Elimina(id))
                    {
                        vista.MostraMessaggio("Punto vendita eliminato con successo!");
                    }
                    else
                    {
                        vista.MostraMessaggio("Errore durante l'eliminazione del punto vendita.");
                    }
                }
                else
                {
                    vista.MostraMessaggio("Operazione annullata.");
                }
            }
            else
            {
                vista.MostraMessaggio("Punto vendita non trovato.");
            }
        }
    }
}
