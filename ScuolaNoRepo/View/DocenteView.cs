using System;
using ScuolaNoRepo.Controller;
using ScuolaNoRepo.Model;

namespace ScuolaNoRepo.View
{
    public class DocenteView
    {
        DocenteController DocenteController = new DocenteController();
        CorsoController CorsoController = new CorsoController();
        public void ShowMenu()
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("GESTIONE DOCENTI");
                Console.WriteLine("1. Aggiungi Docente");
                Console.WriteLine("2. Visualizza Docenti");
                Console.WriteLine("3. Aggiungi Docente a Corso");
                Console.WriteLine("0. Torna al Menu Principale");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiDocente();
                        break;
                    case "2":
                        VisualizzaDocenti();
                        break;
                    case "3":
                        AggiungiDocenteACorso();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

            } while (!exit);
        }

        public void AggiungiDocente()
        {
            Console.Clear();
            Console.WriteLine("AGGIUNGI NUOVO DOCENTE\n");
            Docente nuovoDocente = new Docente();
            Console.Write("Nome: ");
            nuovoDocente.Nome = Console.ReadLine();
            Console.Write("Materia: ");
            nuovoDocente.Materia = Console.ReadLine();
            DocenteController.AddDocente(nuovoDocente);
            Console.WriteLine("\nDocente aggiunto con successo! Premi un tasto per tornare al menu...");
            Console.ReadKey();
        }

        public void VisualizzaDocenti()
        {
            Console.Clear();
            Console.WriteLine("LISTA DOCENTI\n");
            
            var lista = DocenteController.GetAll();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nessun docente presente nel database.");
            }
            else
            {
                foreach (var docente in lista)
                {
                    Console.WriteLine(docente);
                }
            }
            Console.WriteLine("\nPremi un tasto per tornare al menu...");
            Console.ReadKey();
        }

        public void AggiungiDocenteACorso()
        {
            Console.Clear();
            Console.WriteLine("AGGIUNGI DOCENTE A CORSO\n");

            var docenti = DocenteController.GetAll();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Nessun docente disponibile.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Docenti disponibili:");
            foreach (var d in docenti)
            {
                Console.WriteLine(d);
            }

            Console.Write("\nInserisci ID del docente: ");
            if (!int.TryParse(Console.ReadLine(), out int docenteId))
            {
                Console.WriteLine("ID non valido.");
                Console.ReadKey();
                return;
            }

            var corsi = CorsoController.GetAll();
            if (corsi.Count == 0)
            {
                Console.WriteLine("Nessun corso disponibile.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nCorsi disponibili:");
            foreach (var c in corsi)
            {
                Console.WriteLine(c);
            }

            Console.Write("\nInserisci ID del corso: ");
            if (!int.TryParse(Console.ReadLine(), out int corsoId))
            {
                Console.WriteLine("ID non valido.");
                Console.ReadKey();
                return;
            }

            var docenteAggiornato = DocenteController.AggiungiDocenteACorso(docenteId, corsoId);
            if (docenteAggiornato != null)
            {
                Console.WriteLine("\nDocente aggiunto al corso con successo!");
            }
            else
            {
                Console.WriteLine("\nErrore: Docente o corso non trovato.");
            }

            Console.WriteLine("Premi un tasto per tornare al menu...");
            Console.ReadKey();
        }
    }
}