using System;

namespace GestioneStudenti.View
{
    public static class ConsoleView
    {
        public static void MostraMenuPrincipale()
        {
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║     SISTEMA GESTIONE UNIVERSITARIA     ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("1. Gestione Studenti");
            Console.WriteLine("2. Gestione Professori");
            Console.WriteLine("3. Gestione Corsi di Laurea");
            Console.WriteLine("4. Gestione Amministrativo");
            Console.WriteLine("5. Sistema Log & Monitoraggio");
            Console.WriteLine("6. Gestione Admin Logs");
            Console.WriteLine("7. Esci");
            Console.Write("\nScegli un'opzione: ");
        }

        public static void MostraMenuStudenti()
        {
            Console.WriteLine("\n========== MENU STUDENTI ==========");
            Console.WriteLine("1. Aggiungi studente");
            Console.WriteLine("2. Iscrivi studente a corso");
            Console.WriteLine("3. Aggiungi voto a studente");
            Console.WriteLine("4. Cerca studente per matricola");
            Console.WriteLine("5. Visualizza tutti gli studenti");
            Console.WriteLine("6. Visualizza libretto studente");
            Console.WriteLine("7. Trova studente con media più alta");
            Console.WriteLine("0. Indietro");
            Console.Write("\nScegli un'opzione: ");
        }

        public static void MostraMenuProfessori()
        {
            Console.WriteLine("\n========== MENU PROFESSORI ==========");
            Console.WriteLine("1. Aggiungi professore");
            Console.WriteLine("2. Visualizza tutti i professori");
            Console.WriteLine("3. Cerca professore per codice");
            Console.WriteLine("0. Indietro");
            Console.Write("\nScegli un'opzione: ");
        }

        public static void MostraMenuCorsi()
        {
            Console.WriteLine("\n========== MENU CORSI DI LAUREA ==========");
            Console.WriteLine("1. Aggiungi corso di laurea");
            Console.WriteLine("2. Aggiungi professore a corso");
            Console.WriteLine("3. Visualizza tutti i corsi");
            Console.WriteLine("4. Visualizza dettagli corso");
            Console.WriteLine("5. Visualizza studenti per corso");
            Console.WriteLine("0. Indietro");
            Console.Write("\nScegli un'opzione: ");
        }

        public static void MostraMenuAmministrativo()
        {
            Console.WriteLine("\n========== MENU AMMINISTRATIVO ==========");
            Console.WriteLine("1. Richieste iscrizione studenti");
            Console.WriteLine("2. Approva prossima richiesta");
            Console.WriteLine("3. Visualizza prossimo studente in coda");
            Console.WriteLine("4. Visualizza storico operazioni");
            Console.WriteLine("5. Visualizza numero richieste in coda");
            Console.WriteLine("0. Indietro");
            Console.Write("\nScegli un'opzione: ");
        }

        //menu per disalibilitare o abilitare il log
        public static void MostraMenuLog()
        {
            Console.WriteLine("\n========== MENU LOG & MONITORAGGIO ==========");
            Console.WriteLine("1. Abilita log");
            Console.WriteLine("2. Disabilita log");
            Console.WriteLine("3. Disabilita log per classe");
            Console.WriteLine("0. Indietro");
            Console.Write("\nScegli un'opzione: ");
        }

        public static string LeggiInput(string messaggio)
        {
            Console.Write(messaggio);
            return Console.ReadLine();
        }

        public static void Stampa(object output)
        {
            Console.WriteLine(output);
        }
    }
}