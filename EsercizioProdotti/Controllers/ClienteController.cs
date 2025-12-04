using EsercizioProdotti.Models;
using EsercizioProdotti.Repositories;
using EsercizioProdotti.Views;
using System;

namespace EsercizioProdotti.Controllers
{
    public class ClienteController
    {
        private readonly ClienteRepository repositoryCliente;
        private readonly ViewGenerica<Cliente> vista;

        public ClienteController(ClienteRepository repositoryCliente, ViewGenerica<Cliente> vista)
        {
            this.repositoryCliente = repositoryCliente;
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
                        VisualizzaTuttiClienti();
                        break;
                    case 2:
                        AggiungiCliente();
                        break;
                    case 3:
                        AggiornaCliente();
                        break;
                    case 4:
                        EliminaCliente();
                        break;
                    case 5:
                        esci = true;
                        vista.MostraMessaggio("Uscita dal menu clienti...");
                        break;
                    default:
                        vista.MostraOpzioneNonValida();
                        break;
                }
            }
        }

        private void VisualizzaTuttiClienti()
        {
            var clienti = repositoryCliente.OttieniTutti();
            vista.MostraLista(clienti);
        }

        private void AggiungiCliente()
        {
            vista.MostraTitolo("Nuovo Cliente");
            string nome = vista.OttieniInput("Nome");
            string email = vista.OttieniInput("Email");
            string dataRegistrazione = DateTime.Now.ToString("yyyy-MM-dd");
            
            Cliente cliente = new Cliente(0, nome, email, dataRegistrazione);
            
            if (repositoryCliente.Inserisci(cliente))
            {
                vista.MostraMessaggio("Cliente aggiunto con successo!");
            }
            else
            {
                vista.MostraMessaggio("Errore durante l'aggiunta del cliente.");
            }
        }

        private void AggiornaCliente()
        {
            int id = vista.OttieniId("Inserisci l'ID del cliente da modificare: ");
            var cliente = repositoryCliente.OttieniPerId(id);
            
            if (cliente != null)
            {
                vista.MostraElemento(cliente);
                
                vista.MostraTitolo("Modifica Cliente");
                string nome = vista.OttieniInput("Nuovo Nome");
                string email = vista.OttieniInput("Nuova Email");
                string dataRegistrazione = vista.OttieniInput("Data Registrazione (yyyy-MM-dd)");
                
                Cliente clienteAggiornato = new Cliente(id, nome, email, dataRegistrazione);
                
                if (repositoryCliente.Aggiorna(clienteAggiornato))
                {
                    vista.MostraMessaggio("Cliente aggiornato con successo!");
                }
                else
                {
                    vista.MostraMessaggio("Errore durante l'aggiornamento del cliente.");
                }
            }
            else
            {
                vista.MostraMessaggio("Cliente non trovato.");
            }
        }

        private void EliminaCliente()
        {
            int id = vista.OttieniId("Inserisci l'ID del cliente da eliminare: ");
            var cliente = repositoryCliente.OttieniPerId(id);
            
            if (cliente != null)
            {
                vista.MostraElemento(cliente);
                if (vista.ConfermaEliminazione())
                {
                    if (repositoryCliente.Elimina(id))
                    {
                        vista.MostraMessaggio("Cliente eliminato con successo!");
                    }
                    else
                    {
                        vista.MostraMessaggio("Errore durante l'eliminazione del cliente.");
                    }
                }
                else
                {
                    vista.MostraMessaggio("Operazione annullata.");
                }
            }
            else
            {
                vista.MostraMessaggio("Cliente non trovato.");
            }
        }
    }
}