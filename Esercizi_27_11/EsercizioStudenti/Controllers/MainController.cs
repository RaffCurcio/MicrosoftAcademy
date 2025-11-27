using System;
using System.Linq;
using GestioneStudenti.Model;
using GestioneStudenti.View;
using GestioneStudenti.Repository;

namespace GestioneStudenti.Controller
{
    public class MainController
    {
        private StudenteRepository studenteRepo;
        private ProfessoreRepository professoreRepo;
        private CorsoLaureaRepository corsoRepo;

        public MainController(StudenteRepository studenteRepo, ProfessoreRepository professoreRepo, CorsoLaureaRepository corsoRepo)
        {
            this.studenteRepo = studenteRepo;
            this.professoreRepo = professoreRepo;
            this.corsoRepo = corsoRepo;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                ConsoleView.MostraMenuPrincipale();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        MenuStudenti();
                        break;
                    case "2":
                        MenuProfessori();
                        break;
                    case "3":
                        MenuCorsi();
                        break;
                    case "4":
                        exit = true;
                        ConsoleView.Stampa("Uscita");
                        break;
                    default:
                        ConsoleView.Stampa("Opzione non valida.");
                        break;
                }
            }
        }

        // ===== MENU STUDENTI =====
        private void MenuStudenti()
        {
            bool indietro = false;
            while (!indietro)
            {
                ConsoleView.MostraMenuStudenti();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiStudente();
                        break;
                    case "2":
                        IscriviStudenteACorso();
                        break;
                    case "3":
                        AggiungiVoto();
                        break;
                    case "4":
                        CercaStudente();
                        break;
                    case "5":
                        VisualizzaTuttiStudenti();
                        break;
                    case "6":
                        MostraLibretto();
                        break;
                    case "7":
                        TrovaStudenteConMediaPiuAlta();
                        break;
                    case "0":
                        indietro = true;
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

            Studente s = new Studente(nome, cognome, matricola);
            studenteRepo.Aggiungi(s);
            ConsoleView.Stampa("Studente aggiunto con successo!");
        }

        private void IscriviStudenteACorso()
        {
            string mat = ConsoleView.LeggiInput("Matricola studente: ");
            Studente s = studenteRepo.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            if (corsoRepo.ContaTotale() == 0)
            {
                ConsoleView.Stampa("Non ci sono corsi di laurea disponibili.");
                return;
            }

            ConsoleView.Stampa("\nCorsi disponibili:");
            foreach (var c in corsoRepo.OttieniTutti())
                ConsoleView.Stampa($"  - {c}");

            string codiceCorso = ConsoleView.LeggiInput("\nCodice corso: ");
            CorsoLaurea corso = corsoRepo.TrovaPerCodice(codiceCorso);

            if (corso == null)
            {
                ConsoleView.Stampa("Corso non trovato.");
                return;
            }

            s.IscriviACorso(corso);
        }

        private void AggiungiVoto()
        {
            string mat = ConsoleView.LeggiInput("Matricola studente: ");
            Studente s = studenteRepo.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            if (s.CorsoLaurea == null)
            {
                ConsoleView.Stampa("Lo studente non è iscritto a nessun corso.");
                return;
            }

            ConsoleView.Stampa($"\nMaterie disponibili nel corso {s.CorsoLaurea.Nome}:");
            foreach (var m in s.CorsoLaurea.GetMaterie())
                ConsoleView.Stampa($"  - {m}");

            string materia = ConsoleView.LeggiInput("\nInserisci materia: ");
            int voto = int.Parse(ConsoleView.LeggiInput("Inserisci voto (18–30): "));

            s.AggiungiVoto(voto, materia);
        }

        private void CercaStudente()
        {
            string mat = ConsoleView.LeggiInput("Inserisci matricola: ");
            Studente s = studenteRepo.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            ConsoleView.Stampa("\nStudente trovato:");
            ConsoleView.Stampa(s.ToString());
        }

        private void VisualizzaTuttiStudenti()
        {
            var studenti = studenteRepo.OttieniTutti();

            if (studenti.Count == 0)
            {
                ConsoleView.Stampa("Nessuno studente presente.");
                return;
            }

            ConsoleView.Stampa("\n===== ELENCO STUDENTI =====");
            foreach (var s in studenti)
                ConsoleView.Stampa(s.ToString());
        }

        private void MostraLibretto()
        {
            string mat = ConsoleView.LeggiInput("Matricola: ");
            Studente s = studenteRepo.TrovaPerMatricola(mat);

            if (s == null)
            {
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            s.StampaLibretto();
        }

        private void TrovaStudenteConMediaPiuAlta()
        {
            var studenti = studenteRepo.OttieniTutti();

            if (studenti.Count == 0)
            {
                ConsoleView.Stampa("Non ci sono studenti.");
                return;
            }

            Studente top = studenti.OrderByDescending(s => s.Media).First();
            ConsoleView.Stampa($"\nStudente con media più alta:");
            ConsoleView.Stampa($"{top.Nome} {top.Cognome} - Media: {top.Media:F2}");
        }

        // ===== MENU PROFESSORI =====
        private void MenuProfessori()
        {
            bool indietro = false;
            while (!indietro)
            {
                ConsoleView.MostraMenuProfessori();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiProfessore();
                        break;
                    case "2":
                        VisualizzaTuttiProfessori();
                        break;
                    case "3":
                        CercaProfessore();
                        break;
                    case "0":
                        indietro = true;
                        break;
                    default:
                        ConsoleView.Stampa("Opzione non valida.");
                        break;
                }
            }
        }

        private void AggiungiProfessore()
        {
            string nome = ConsoleView.LeggiInput("Nome: ");
            string cognome = ConsoleView.LeggiInput("Cognome: ");
            string codiceId = ConsoleView.LeggiInput("Codice ID: ");
            string materia = ConsoleView.LeggiInput("Materia insegnata: ");

            Professore p = new Professore(nome, cognome, codiceId, materia);
            professoreRepo.Aggiungi(p);
            ConsoleView.Stampa("Professore aggiunto con successo!");
        }

        private void VisualizzaTuttiProfessori()
        {
            var professori = professoreRepo.OttieniTutti();

            if (professori.Count == 0)
            {
                ConsoleView.Stampa("Nessun professore presente.");
                return;
            }

            ConsoleView.Stampa("\n===== ELENCO PROFESSORI =====");
            foreach (var p in professori)
                ConsoleView.Stampa(p.ToString());
        }

        private void CercaProfessore()
        {
            string codice = ConsoleView.LeggiInput("Codice ID professore: ");
            Professore p = professoreRepo.TrovaPerCodice(codice);

            if (p == null)
            {
                ConsoleView.Stampa("Professore non trovato.");
                return;
            }

            ConsoleView.Stampa("\nProfessore trovato:");
            ConsoleView.Stampa(p.ToString());
        }

        // ===== MENU CORSI =====
        private void MenuCorsi()
        {
            bool indietro = false;
            while (!indietro)
            {
                ConsoleView.MostraMenuCorsi();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiCorso();
                        break;
                    case "2":
                        AggiungiProfessoreACorso();
                        break;
                    case "3":
                        VisualizzaTuttiCorsi();
                        break;
                    case "4":
                        VisualizzaDettagliCorso();
                        break;
                    case "5":
                        VisualizzaStudentiPerCorso();
                        break;
                    case "0":
                        indietro = true;
                        break;
                    default:
                        ConsoleView.Stampa("Opzione non valida.");
                        break;
                }
            }
        }

        private void AggiungiCorso()
        {
            string codice = ConsoleView.LeggiInput("Codice corso: ");
            string nome = ConsoleView.LeggiInput("Nome corso: ");

            CorsoLaurea corso = new CorsoLaurea(codice, nome);
            corsoRepo.Aggiungi(corso);
            ConsoleView.Stampa("Corso di laurea aggiunto con successo!");
        }

        private void AggiungiProfessoreACorso()
        {
            if (professoreRepo.ContaTotale() == 0)
            {
                ConsoleView.Stampa("Non ci sono professori disponibili.");
                return;
            }

            if (corsoRepo.ContaTotale() == 0)
            {
                ConsoleView.Stampa("Non ci sono corsi disponibili.");
                return;
            }

            ConsoleView.Stampa("\nProfessori disponibili:");
            foreach (var p in professoreRepo.OttieniTutti())
                ConsoleView.Stampa($"  - {p}");

            string codiceProf = ConsoleView.LeggiInput("\nCodice ID professore: ");
            Professore prof = professoreRepo.TrovaPerCodice(codiceProf);

            if (prof == null)
            {
                ConsoleView.Stampa("Professore non trovato.");
                return;
            }

            ConsoleView.Stampa("\nCorsi disponibili:");
            foreach (var c in corsoRepo.OttieniTutti())
                ConsoleView.Stampa($"  - {c}");

            string codiceCorso = ConsoleView.LeggiInput("\nCodice corso: ");
            CorsoLaurea corso = corsoRepo.TrovaPerCodice(codiceCorso);

            if (corso == null)
            {
                ConsoleView.Stampa("Corso non trovato.");
                return;
            }

            corso.AggiungiProfessore(prof);
        }

        private void VisualizzaTuttiCorsi()
        {
            var corsi = corsoRepo.OttieniTutti();

            if (corsi.Count == 0)
            {
                ConsoleView.Stampa("Nessun corso presente.");
                return;
            }

            ConsoleView.Stampa("\n===== ELENCO CORSI DI LAUREA =====");
            foreach (var c in corsi)
                ConsoleView.Stampa(c.ToString());
        }

        private void VisualizzaDettagliCorso()
        {
            string codice = ConsoleView.LeggiInput("Codice corso: ");
            CorsoLaurea corso = corsoRepo.TrovaPerCodice(codice);

            if (corso == null)
            {
                ConsoleView.Stampa("Corso non trovato.");
                return;
            }

            corso.StampaDettagli();
        }

        private void VisualizzaStudentiPerCorso()
        {
            string codice = ConsoleView.LeggiInput("Codice corso: ");
            CorsoLaurea corso = corsoRepo.TrovaPerCodice(codice);

            if (corso == null)
            {
                ConsoleView.Stampa("Corso non trovato.");
                return;
            }

            var studenti = studenteRepo.TrovaPerCorso(codice);

            ConsoleView.Stampa($"\n===== Studenti iscritti a {corso.Nome} =====");
            if (studenti.Count == 0)
            {
                ConsoleView.Stampa("Nessuno studente iscritto.");
            }
            else
            {
                foreach (var s in studenti)
                    ConsoleView.Stampa(s.ToString());
            }
        }
    }
}