using System;
using System.Linq;
using GestioneStudenti.Model;
using GestioneStudenti.View;
using GestioneStudenti.Repository;
using GestioneStudenti.Services;
using GestioneStudenti.Controllers;

namespace GestioneStudenti.Controller
{
    public class MainController
    {
        private StudenteRepository studenteRepo;
        private ProfessoreRepository professoreRepo;
        private CorsoLaureaRepository corsoRepo;
        private StoricoOperazioni storicoOperazioni;
        private CodaIscrizioni codaIscrizioni;
        private LoggerServices loggerServices;
        private LogController logController;

        public MainController(StudenteRepository studenteRepo, ProfessoreRepository professoreRepo, CorsoLaureaRepository corsoRepo, StoricoOperazioni storicoOperazioni, CodaIscrizioni codaIscrizioni, LoggerServices loggerServices)
        {
            this.studenteRepo = studenteRepo;
            this.professoreRepo = professoreRepo;
            this.corsoRepo = corsoRepo;
            this.storicoOperazioni = storicoOperazioni;
            this.codaIscrizioni = codaIscrizioni;
            this.loggerServices = loggerServices;
            this.logController = new LogController();
            InizializzaCorsiPredefiniti();
        }

        private void InizializzaCorsiPredefiniti()
        {
            CorsoLaurea informatica = new CorsoLaurea("INF", "Informatica");
            Professore prof1 = new Professore("Mario", "Rossi", "P001", "Programmazione");
            Professore prof2 = new Professore("Luca", "Bianchi", "P002", "Database");
            informatica.AggiungiProfessore(prof1);
            informatica.AggiungiProfessore(prof2);
            corsoRepo.Aggiungi(informatica);
            professoreRepo.Aggiungi(prof1);
            professoreRepo.Aggiungi(prof2);

            CorsoLaurea matematica = new CorsoLaurea("MAT", "Matematica");
            Professore prof3 = new Professore("Anna", "Verdi", "P003", "Analisi");
            Professore prof4 = new Professore("Giulia", "Neri", "P004", "Geometria");
            matematica.AggiungiProfessore(prof3);
            matematica.AggiungiProfessore(prof4);
            corsoRepo.Aggiungi(matematica);
            professoreRepo.Aggiungi(prof3);
            professoreRepo.Aggiungi(prof4);

            CorsoLaurea fisica = new CorsoLaurea("FIS", "Fisica");
            Professore prof5 = new Professore("Paolo", "Blu", "P005", "Meccanica");
            fisica.AggiungiProfessore(prof5);
            corsoRepo.Aggiungi(fisica);
            professoreRepo.Aggiungi(prof5);
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
                        MenuAmministrativo();
                        break;
                    case "5":
                        logController.MostraMenuLog();
                        break;
                    case "6":
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

            if (corsoRepo.ContaTotale() == 0)
            {
                ConsoleView.Stampa("Nessun corso disponibile. Impossibile procedere con l'iscrizione.");
                return;
            }

            ConsoleView.Stampa("\nCorsi disponibili:");
            foreach (var c in corsoRepo.OttieniTutti())
                ConsoleView.Stampa($"  - {c}");

            string codiceCorso = ConsoleView.LeggiInput("\nScegli il codice del corso di laurea: ");
            CorsoLaurea corsoScelto = corsoRepo.TrovaPerCodice(codiceCorso);

            if (corsoScelto == null)
            {
                ConsoleView.Stampa("Corso non trovato. Iscrizione annullata.");
                return;
            }

            Studente s = new Studente(nome, cognome, matricola);
            s.IscriviACorso(corsoScelto); 

            codaIscrizioni.AggiungiRichiesta(s);
            ConsoleView.Stampa("Richiesta di iscrizione inviata con successo!");
            storicoOperazioni.Registra($"Inviata richiesta iscrizione per studente: {s.Nome} {s.Cognome}, Matricola: {s.Matricola}, Corso: {corsoScelto.Nome}");
            loggerServices.LogInfo($"Inviata richiesta iscrizione per studente: {s.Nome} {s.Cognome}, Matricola: {s.Matricola}, Corso: {corsoScelto.Nome}");
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
            storicoOperazioni.Registra($"Iscritto studente {s.Nome} {s.Cognome} al corso {corso.Nome}");
            loggerServices.LogInfo($"Iscritto studente {s.Nome} {s.Cognome} al corso {corso.Nome}");
        }

        private void AggiungiVoto()
        {
            try
            {
                string mat = ConsoleView.LeggiInput("Matricola studente: ");
                Studente s = studenteRepo.TrovaPerMatricola(mat);

                if (s == null)
                {
                    loggerServices.LogWarning($"Tentativo di aggiungere voto a studente non esistente. Matricola: {mat}");
                    ConsoleView.Stampa("Studente non trovato.");
                    return;
                }

                if (s.CorsoLaurea == null)
                {
                    loggerServices.LogWarning($"Studente {s.Nome} {s.Cognome} non iscritto a nessun corso.");
                    ConsoleView.Stampa("Lo studente non è iscritto a nessun corso.");
                    return;
                }

                ConsoleView.Stampa($"\nMaterie disponibili nel corso {s.CorsoLaurea.Nome}:");
                foreach (var m in s.CorsoLaurea.GetMaterie())
                    ConsoleView.Stampa($"  - {m}");

                string materia = ConsoleView.LeggiInput("\nInserisci materia: ");
                int voto = int.Parse(ConsoleView.LeggiInput("Inserisci voto (18–30): "));

                s.AggiungiVoto(voto, materia);
                if(voto < 18 || voto > 30)
                {
                    loggerServices.LogWarning($"Voto fuori range inserito per studente {s.Nome} {s.Cognome}: {voto} in {materia}");
                    ConsoleView.Stampa("Attenzione: il voto inserito è fuori dal range valido (18-30).");
                }   
                loggerServices.LogInfo($"Aggiunto voto {voto} in {materia} per studente {s.Nome} {s.Cognome}");
            }
            catch (FormatException ex)
            {
                loggerServices.LogError($"Formato voto non valido: {ex.Message}");
                ConsoleView.Stampa("Errore: inserisci un numero valido per il voto.");
            }
            catch (Exception ex)
            {
                loggerServices.LogError($"Errore imprevisto durante l'aggiunta del voto: {ex.Message}");
                ConsoleView.Stampa("Si è verificato un errore imprevisto.");
            }
        }

        private void CercaStudente()
        {
            string mat = ConsoleView.LeggiInput("Inserisci matricola: ");
            Studente s = studenteRepo.TrovaPerMatricola(mat);

            if (s == null)
            {
                loggerServices.LogWarning($"Studente non trovato con matricola: {mat}");
                ConsoleView.Stampa("Studente non trovato.");
                return;
            }

            ConsoleView.Stampa("\nStudente trovato:");
            ConsoleView.Stampa(s.ToString());
            storicoOperazioni.Registra($"Cercato studente: {s.Nome} {s.Cognome}, Matricola: {s.Matricola}");
            loggerServices.LogInfo($"Cercato studente: {s.Nome} {s.Cognome}, Matricola: {s.Matricola}");
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

            storicoOperazioni.Registra("Visualizzati tutti gli studenti.");
            loggerServices.LogInfo("Visualizzati tutti gli studenti.");
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
            loggerServices.LogInfo($"Visualizzato libretto studente: {s.Nome} {s.Cognome}, Matricola: {s.Matricola}");
            storicoOperazioni.Registra($"Visualizzato libretto studente: {s.Nome} {s.Cognome}, Matricola: {s.Matricola}");
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
            storicoOperazioni.Registra($"Trovato studente con media più alta: {top.Nome} {top.Cognome}, Media: {top.Media:F2}");
            loggerServices.LogInfo($"Trovato studente con media più alta: {top.Nome} {top.Cognome}, Media: {top.Media:F2}");
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
            storicoOperazioni.Registra($"Aggiunto professore: {p.Nome} {p.Cognome}, Codice ID: {p.CodiceId}");
            loggerServices.LogInfo($"Aggiunto professore: {p.Nome} {p.Cognome}, Codice ID: {p.CodiceId}");
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
            storicoOperazioni.Registra("Visualizzati tutti i professori.");
            loggerServices.LogInfo("Visualizzati tutti i professori.");
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
            storicoOperazioni.Registra($"Cercato professore: {p.Nome} {p.Cognome}, Codice ID: {p.CodiceId}");
            loggerServices.LogInfo($"Cercato professore: {p.Nome} {p.Cognome}, Codice ID: {p.CodiceId}");
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
            storicoOperazioni.Registra($"Aggiunto corso di laurea: {corso.Nome}, Codice: {corso.Codice}");
            loggerServices.LogInfo($"Aggiunto corso di laurea: {corso.Nome}, Codice: {corso.Codice}");
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
            storicoOperazioni.Registra($"Assegnato professore {prof.Nome} {prof.Cognome} al corso {corso.Nome}");
            loggerServices.LogInfo($"Assegnato professore {prof.Nome} {prof.Cognome} al corso {corso.Nome}");
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
            
            storicoOperazioni.Registra("Visualizzati tutti i corsi di laurea.");
            loggerServices.LogInfo("Visualizzati tutti i corsi di laurea.");
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
            storicoOperazioni.Registra($"Visualizzati dettagli corso: {corso.Nome}, Codice: {corso.Codice}");
            loggerServices.LogInfo($"Visualizzati dettagli corso: {corso.Nome}, Codice: {corso.Codice}");
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
            storicoOperazioni.Registra($"Visualizzati studenti iscritti al corso: {corso.Nome}, Codice: {corso.Codice}");
            loggerServices.LogInfo($"Visualizzati studenti iscritti al corso: {corso.Nome}, Codice: {corso.Codice}");
        }

        // ===== MENU AMMINISTRATIVO =====
        private void MenuAmministrativo()
        {
            bool indietro = false;
            while (!indietro)
            {
                ConsoleView.MostraMenuAmministrativo();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        //vedere le richieste di iscrizione studenti
                        foreach (var studente in codaIscrizioni.ottieniRichiesteInAttesa())
                        {
                            ConsoleView.Stampa(studente.ToString());
                        }
                        loggerServices.LogInfo("Visualizzate tutte le richieste di iscrizione studenti.");
                        break;
                    case "2":
                        //approva la prossima richiesta di iscrizione
                        var studenteApprovato = codaIscrizioni.ApprovaProssimaRichiesta();
                        if (studenteApprovato != null)
                        {
                            studenteRepo.Aggiungi(studenteApprovato);
                            ConsoleView.Stampa($"Studente {studenteApprovato.Nome} {studenteApprovato.Cognome} approvato e aggiunto al sistema.");
                            storicoOperazioni.Registra($"Approvata iscrizione studente: {studenteApprovato.Nome} {studenteApprovato.Cognome}, Matricola: {studenteApprovato.Matricola}");
                            loggerServices.LogInfo($"Approvata iscrizione studente: {studenteApprovato.Nome} {studenteApprovato.Cognome}, Matricola: {studenteApprovato.Matricola}");
                        }
                        else
                        {
                            loggerServices.LogWarning("Tentativo di approvare richiesta ma la coda è vuota.");
                            ConsoleView.Stampa("Nessuna richiesta in coda.");
                        }
                        break;
                    case "3":
                        //visualizza il prossimo studente in coda
                        var prossimoStudente = codaIscrizioni.prossimoStudente();
                        if (prossimoStudente != null)
                        {
                            ConsoleView.Stampa($"Prossimo studente in coda: {prossimoStudente.Nome} {prossimoStudente.Cognome}, Matricola: {prossimoStudente.Matricola}");
                            loggerServices.LogInfo($"Visualizzato prossimo studente in coda: {prossimoStudente.Nome} {prossimoStudente.Cognome}");
                        }
                        else
                        {
                            loggerServices.LogWarning("Coda iscrizioni vuota durante visualizzazione prossimo studente.");
                            ConsoleView.Stampa("Nessuna richiesta in coda.");
                        }
                        break;
                    case "4":
                        //visualizza lo storico delle operazioni
                        var storico = storicoOperazioni.OttieniTutte();
                        foreach (var operazione in storico)
                        {
                            ConsoleView.Stampa(operazione);
                        }
                        loggerServices.LogInfo("Visualizzato lo storico delle operazioni.");
                        break;
                    case "5":
                        //visualizza il numero di richieste in coda
                        int numeroRichieste = codaIscrizioni.NumeroRichieste;
                        ConsoleView.Stampa($"Numero di richieste in coda: {numeroRichieste}");
                        loggerServices.LogInfo("Visualizzato il numero di richieste in coda.");
                        break;
                    case "0":
                        indietro = true;
                        loggerServices.LogInfo("Uscito dal menu amministrativo.");
                        break;
                    default:
                        loggerServices.LogWarning("Selezionata un'opzione non valida nel menu amministrativo.");
                        ConsoleView.Stampa("Opzione non valida.");
                        break;
                }
            }
        }
    }
}