using System;
using System.Collections.Generic;
using System.Linq;
using GestioneStudenti.Model;
using GestioneStudenti.View;
using GestioneStudenti.Repository;

namespace GestioneStudenti.Controller
{
    public class StudenteController
    {
        private StudenteRepository repository;

        public StudenteController(StudenteRepository repository)
        {
            this.repository = repository;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                ConsoleView.MostraMenu();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiStudente();
                        break;
                    case "2":
                        CercaStudente();
                        break;
                    case "3":
                        AggiungiVoto();
                        break;
                    case "4":
                        VisualizzaTutti();
                        break;
                    case "5":
                        TrovaStudenteConMediaPiuAlta();
                        break;
                    case "6":
                        MostraLibretto();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        ConsoleView.Stampa("Opzione non valida.");
                        break;
                }
            }
        }

        private void AggiungiStudente()
        {
            string nome = ConsoleView.LeggiInput("Nome: ");
            string cognome = ConsoleView.LeggiInput("Cognome: ");
            string matricola = ConsoleView.LeggiInput("Matricola: ");

            Studente s = new Studente(nome, cognome, matricola, new List<int>());
            repository.Aggiungi(s);
            ConsoleView.Stampa("Studente aggiunto con successo!");
        }

        private void CercaStudente()
        {
            string mat = ConsoleView.LeggiInput("Inserisci matricola: ");
            Studente s = repository.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            ConsoleView.Stampa("\nStudente trovato:");
            ConsoleView.Stampa(s.ToString());
        }

        private void AggiungiVoto()
        {
            string mat = ConsoleView.LeggiInput("Matricola: ");
            Studente s = repository.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            int voto = int.Parse(ConsoleView.LeggiInput("Inserisci voto (18-30): "));
            s.AggiungiVoto(voto);
            ConsoleView.Stampa("Voto aggiunto!");
        }

        private void VisualizzaTutti()
        {
            var studenti = repository.OttieniTutti();
            
            if (studenti.Count == 0)
            {
                ConsoleView.Stampa("Nessuno studente presente.");
                return;
            }

            ConsoleView.Stampa("\nElenco studenti:");
            foreach (var s in studenti)
                ConsoleView.Stampa(s.ToString());
        }

        private void TrovaStudenteConMediaPiuAlta()
        {
            var studenti = repository.OttieniTutti();
            
            if (studenti.Count == 0)
            {
                ConsoleView.Stampa("Non ci sono studenti.");
                return;
            }

            Studente top = studenti.OrderByDescending(s => s.Media).First();
            ConsoleView.Stampa($"\nStudente con media più alta:\n{top} (Media: {top.Media:F2})");
        }

        private void MostraLibretto()
        {
            string mat = ConsoleView.LeggiInput("Matricola: ");
            Studente s = repository.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            s.StampaLibretto();
        }
    }
}